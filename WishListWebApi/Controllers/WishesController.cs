using CrossCutting.Pagination;
using Domain.WishList.Entity;
using Domain.WishList.Interface;
using Infra.Repository.WishList.Repositories;
using Service.WishList.Services;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WishListWebApi.Models;

namespace WishListWebApi.Controllers
{
    public class WishesController : ApiController
    {
        static readonly IWishRepository _repositorio = new WishRepository();
        static readonly WishService _servico = new WishService(_repositorio);

        [HttpGet]
        [Route("wishes/{userId}")]
        public IEnumerable<WishModel> GetAllWishes(int userId, [FromUri]int page_size, [FromUri]int page)
        {
            List<WishModel> wishesModel = new List<WishModel>();
            PaginationParameter paginationParameter = new PaginationParameter(page, page_size);

            IList<Wish> wishes = _servico.ListWishes(paginationParameter, userId);

            // Faz a troca de dados da classe de dominio para a classe de exibicao
            if (wishes != null && wishes.Count > 0)
            {
                foreach (Wish wish in wishes)
                {
                    if (wish.User == null || wish.Product == null)
                        continue;

                    WishModel wm = new WishModel();
                    wm.id = userId;
                    wm.name = wish.Product.Name;
                    wishesModel.Add(wm);
                }
            }
            return wishesModel;
        }

        [HttpPost]
        [Route("wishes/{userId}")]
        public HttpResponseMessage CreateWish(int userId, List<ProductModel> produtos)
        {
            bool criado = false;

            if (produtos != null)
                foreach (ProductModel produtoModelo in produtos)
                {
                    criado = _servico.Create(userId, produtoModelo.idProduct);
                    if (!criado)
                        break;
                }

            if (criado)
                return new HttpResponseMessage(HttpStatusCode.Created);
            else
                return new HttpResponseMessage(HttpStatusCode.NoContent);
        }

        [HttpPut]
        [Route("wishes/{userId}")]
        public HttpResponseMessage UpdateWish(int userId, List<ProductModel> produtos)
        {
            bool atualizado = false;

            if (produtos != null)
            {
                _servico.RemoveAll(userId);

                foreach (ProductModel produtoModelo in produtos)
                {
                    atualizado = _servico.Create(userId, produtoModelo.idProduct);
                    if (!atualizado)
                        break;
                }
            }

            if (atualizado)
                return new HttpResponseMessage(HttpStatusCode.Created);
            else
                return new HttpResponseMessage(HttpStatusCode.NoContent);
        }

        [HttpDelete]
        [Route("{userId}/{productId}")]
        public HttpResponseMessage DeleteWish(int userId, int productId)
        {
            Wish wishExiste = _servico.GetWish(userId, productId);

            if (wishExiste == null)
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            else
            {
                bool removido = _servico.Remove(userId, productId);
                if (removido)
                    return new HttpResponseMessage(HttpStatusCode.OK);
                else
                    return new HttpResponseMessage(HttpStatusCode.NoContent);
            }
        }
    }
}
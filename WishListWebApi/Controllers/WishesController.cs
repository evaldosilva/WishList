using CrossCutting.Pagination;
using Domain.WishList.Entity;
using Domain.WishList.Interface;
using Infra.Repository.WishList.Repositories;
using Service.WishList.Services;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WishListWebApi.ModelsDTO;

namespace WishListWebApi.Controllers
{
    public class WishesController : ApiController
    {
        static readonly IWishRepository _repositorio = new WishRepository();
        static readonly WishService _servico = new WishService(_repositorio);

        [HttpGet]
        [Route("wishes/{userId}")]
        public async Task<IEnumerable<WishDTO>> GetAllWishes(int userId, [FromUri]int page_size, [FromUri]int page)
        {
            List<WishDTO> wishesModel = new List<WishDTO>();
            PaginationParameter paginationParameter = new PaginationParameter(page, page_size);

            IList<Wish> wishes = await _servico.ListWishesAsync(paginationParameter, userId);

            // Faz a troca de dados da classe de dominio para a classe de exibicao
            if (wishes != null && wishes.Count > 0)
            {
                foreach (Wish wish in wishes)
                {
                    if (wish.User == null || wish.Product == null)
                        continue;

                    WishDTO wm = new WishDTO();
                    wm.id = userId;
                    wm.name = wish.Product.Name;
                    wishesModel.Add(wm);
                }
            }
            return wishesModel;
        }

        [HttpPost]
        [Route("wishes/{userId}")]
        public async Task<IHttpActionResult> CreateWish(int userId, List<ProductDTO> produtos)
        {
            bool criado = false;

            if (produtos != null)
                foreach (ProductDTO produtoModelo in produtos)
                {
                    criado = await _servico.CreateWishAsync(userId, produtoModelo.idProduct);
                    if (!criado)
                        break;
                }

            if (criado)
                return Content(HttpStatusCode.Created, string.Empty);
            else
                return Content(HttpStatusCode.NoContent, string.Empty);
        }

        [HttpPut]
        [Route("wishes/{userId}")]
        public async Task<IHttpActionResult> UpdateWish(int userId, List<ProductDTO> produtos)
        {
            bool atualizado = false;

            if (produtos != null)
            {
                bool allRemoved = await _servico.RemoveAllWishesAsync(userId);

                foreach (ProductDTO produtoModelo in produtos)
                {
                    atualizado = await _servico.CreateWishAsync(userId, produtoModelo.idProduct);
                    if (!atualizado)
                        break;
                }
            }

            if (atualizado)
                return Content(HttpStatusCode.OK, string.Empty);
            else
                return Content(HttpStatusCode.NoContent, string.Empty);
        }

        [HttpDelete]
        [Route("{userId}/{productId}")]
        public async Task<IHttpActionResult> DeleteWish(int userId, int productId)
        {
            Wish wishExiste = await _servico.GetWishAsync(userId, productId);

            if (wishExiste == null)
                return Content(HttpStatusCode.NotFound, string.Empty);
            else
            {
                bool removido = await _servico.RemoveWishAsync(userId, productId);
                if (removido)
                    return Content(HttpStatusCode.OK, string.Empty);
                else
                    return Content(HttpStatusCode.NoContent, string.Empty);
            }
        }
    }
}
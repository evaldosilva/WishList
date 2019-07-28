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
    public class ProductsController : ApiController
    {
        static readonly IProductRepository _repositorio = new ProductRepository();
        static readonly ProductService _servico = new ProductService(_repositorio);

        [HttpPost]
        public HttpResponseMessage PostProduct(Product product)
        {
            bool criado = _servico.CreateProduct(product.Name);
            if (criado)
                return new HttpResponseMessage(HttpStatusCode.Created);
            else
                return new HttpResponseMessage(HttpStatusCode.NoContent);
        }

        [HttpGet]
        public IEnumerable<GetAllProductsViewModel> GetAllProducts([FromUri]int page_size, [FromUri]int page)
        {
            PaginationParameter paginationParameter = new PaginationParameter(page, page_size);
            IList<Product> produtos = _servico.ListProducts(paginationParameter);
            List<GetAllProductsViewModel> listGetAllProductsViewModel = new List<GetAllProductsViewModel>();

            // Faz a troca de dados da classe de dominio para a classe de exibicao
            if (produtos != null && produtos.Count > 0)
                foreach (Product produto in produtos)
                {
                    GetAllProductsViewModel produtoModel = new GetAllProductsViewModel();
                    produtoModel.id = produto.Id;
                    produtoModel.name = produto.Name;
                    listGetAllProductsViewModel.Add(produtoModel);
                }
            return listGetAllProductsViewModel;
        }
    }
}
using CrossCutting.Pagination;
using Domain.WishList.Entity;
using Domain.WishList.Interface;
using Infra.Repository.WishList.Repositories;
using Service.WishList.Services;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using WishListWebApi.ModelsDTO;

namespace WishListWebApi.Controllers
{
    public class ProductsController : ApiController
    {
        static readonly IProductRepository _repositorio = new ProductRepository();
        static readonly ProductService _servico = new ProductService(_repositorio);

        [HttpPost]
        public async Task<IHttpActionResult> PostProduct(Product product)
        {
            bool criado = await _servico.CreateProductAsync(product.Name);
            if (criado)
                return Content(HttpStatusCode.Created, string.Empty);
            else
                return Content(HttpStatusCode.NoContent, string.Empty);
        }

        [HttpGet]
        public async Task<IEnumerable<GetAllProductsDTO>> GetAllProducts([FromUri]int page_size, [FromUri]int page)
        {
            PaginationParameter paginationParameter = new PaginationParameter(page, page_size);
            IList<Product> produtos = await _servico.ListProductsAsync(paginationParameter);
            List<GetAllProductsDTO> listGetAllProductsDTO = new List<GetAllProductsDTO>();

            // Faz a troca de dados da classe de dominio para a classe de exibicao
            if (produtos != null && produtos.Count > 0)
                foreach (Product produto in produtos)
                {
                    GetAllProductsDTO produtoModel = new GetAllProductsDTO();
                    produtoModel.id = produto.Id;
                    produtoModel.name = produto.Name;
                    listGetAllProductsDTO.Add(produtoModel);
                }
            return listGetAllProductsDTO;
        }
    }
}
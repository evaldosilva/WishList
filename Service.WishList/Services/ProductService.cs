using CrossCutting.Pagination;
using Domain.WishList.Entity;
using Domain.WishList.Interface;
using Service.WishList.Validators;
using System.Collections.Generic;
using System.Linq;

namespace Service.WishList.Services
{
    /// <summary>
    /// Classe de servico para administrar as funcionalidades relacionadas ao Product
    /// </summary>
    public class ProductService
    {
        /// <summary>
        /// Interface de acesso as funcionalidades do Product
        /// </summary>
        private IProductRepository _productRepository;

        /// <summary>
        /// Cria um novo servico de Product
        /// </summary>
        /// <param name="productRepository">Repositorio do servico</param>
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        /// <summary>
        /// Cria um novo Product na base de dados
        /// </summary>
        /// <param name="Name">Nome do produto</param>
        /// <returns>True se a operacao deu certo, False ao contrario</returns>
        public bool CreateProduct(string name)
        {
            if (BasicValidator.isNameValido(name))
                return _productRepository.Create(name);
            else
                return false;
        }

        /// <summary>
        /// Lista os Products da base de dados
        /// </summary>
        /// <param name="paginationParameter">Filtros para uma exibicao paginada</param>
        /// <returns>Lista de Products filtrada pelos parametros de paginacao</returns>
        public IList<Product> ListProducts(PaginationParameter paginationParameter)
        {
            // Neste caso, obtem todos os produtos para fazer a paginação, mas poderia ser criada uma 
            // nova função na intreface para refinar mais a lista passando filtros direto para a consulta
            // na camada de persistencia, para melhorar a performance.
            List<Product> products = new List<Product>(_productRepository.GetAll());

            // Realiza a paginação da lista
            List<Product> productsPage = products.
                Skip((paginationParameter.numeroPagina - 1) * paginationParameter.numeroRegistrosPorPagina).
                Take(paginationParameter.numeroRegistrosPorPagina)
                .ToList();

            return productsPage;
        }
    }
}
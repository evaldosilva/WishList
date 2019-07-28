using Domain.WishList.Entity;
using Domain.WishList.Interface;
using Infra.Database.WishList.Persistence;
using System.Collections.Generic;

namespace Infra.Repository.WishList.Repositories
{
    /// <summary>
    /// Classe repository de Product
    /// </summary>
    public class ProductRepository : IProductRepository
    {
        /// <summary>
        /// Cria um novo Product
        /// </summary>
        /// <param name="Name">Nome do produto</param>
        /// <returns>True se a operacao deu certo, False ao contrario</returns>
        public bool Create(string name)
        {
            // Cria um novo produto
            Product product = new Product();
            product.Name = name;

            // Persiste na base de dados o novo produto
            ProductPersistence productPersistence = new ProductPersistence();
            bool result = productPersistence.Insert(product);

            return result;
        }

        /// <summary>
        /// Obtem um Product
        /// </summary>
        /// <param name="Id">ID do produto</param>
        /// <returns>Retorna um Product encontrado pelo Id ou nulo se nao encontrar</returns>
        public Product Get(int id)
        {
            ProductPersistence productPersistence = new ProductPersistence();
            return productPersistence.Get(id);
        }

        /// <summary>
        /// Lista todos os produtos do sistema
        /// </summary>
        /// <returns>Uma lista de produtos</returns>
        public IList<Product> GetAll()
        {
            ProductPersistence productPersistence = new ProductPersistence();
            return productPersistence.GetAll<Product>();
        }
    }
}
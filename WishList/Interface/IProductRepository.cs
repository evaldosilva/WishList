using Domain.WishList.Entity;
using System.Collections.Generic;

namespace Domain.WishList.Interface
{
    /// <summary>
    /// Interface de acesso as funcionalidades de um Product no repositorio
    /// </summary>
    public interface IProductRepository
    {
        /// <summary>
        /// Cria um novo Product
        /// </summary>
        /// <param name="name">Nome do produto</param>
        /// <returns>True se a operacao deu certo, False ao contrario</returns>
        bool Create(string name);

        /// <summary>
        /// Lista todos os produtos do sistema
        /// </summary>
        /// <returns>Uma lista de produtos</returns>
        IList<Product> GetAll();

        /// <summary>
        /// Obtem um Product
        /// </summary>
        /// <param name="id">Id do produto</param>
        /// <returns>Retorna um Product encontrado pelo Id ou nulo se nao encontrar</returns>
        Product Get(int id);
    }
}
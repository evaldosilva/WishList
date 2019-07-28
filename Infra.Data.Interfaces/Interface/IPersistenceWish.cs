using Domain.WishList.Entity;
using System.Collections.Generic;

namespace Infra.Data.Interfaces
{
    /// <summary>
    /// Interface para as operacoes de persistencia de Wish.
    /// </summary>
    public interface IPersistenceWish
    {
        /// <summary>
        /// Insere um novo Wish
        /// </summary>
        /// <param name="record">Registro a ser inserido</param>
        /// <returns>True se a operacao deu certo, False ao contrario</returns>
        bool Insert(Wish record);

        /// <summary>
        /// Remove todos os Wishes de um usuario da base de dados
        /// </summary>
        /// <param name="UserId">Id do usuario</param>
        /// <returns>True se a operacao deu certo, False ao contrario</returns>
        bool RemoveAll(int UserId);

        /// <summary>
        /// Apaga um Wish
        /// </summary>
        /// <param name="UserId">Id do usuario</param>
        /// <param name="ProductId">Id do produto</param>
        /// <returns>True se a operacao deu certo, False ao contrario</returns>
        bool Delete(int UserId, int ProductId);

        /// <summary>
        /// Lista de Wishes de um usuario
        /// </summary>
        /// <param name="UserId">Id do usuario</param>
        /// <returns>Uma lista de wishes de um dado usuario</returns>
        IList<Wish> GetAll(int UserId);

        /// <summary>
        /// Obtem um Wish existente
        /// </summary>
        /// <param name="UserId">Id do Usuario</param>
        /// <param name="ProductId">Id do Produto</param>
        /// <returns>O desejo de um usuario sobre um produto</returns>
        Wish Get(int UserId, int ProductId);
    }
}
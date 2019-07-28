using Domain.WishList.Entity;
using System.Collections.Generic;

namespace Domain.WishList.Interface
{
    public interface IWishRepository
    {
        /// <summary>
        /// Cria um novo Wish
        /// </summary>
        /// <param name="UserId">Id do Usuario</param>
        /// <param name="ProductId">Id do Produto</param>
        /// <returns>True se a operacao deu certo, False ao contrario</returns>
        bool Create(int UserId, int ProductId);

        /// <summary>
        /// Remove todos os Wishes de um usuario
        /// </summary>
        /// <param name="UserId">Id do Usuario</param>
        /// <returns>True se a operacao deu certo, False ao contrario</returns>
        bool RemoveAll(int UserId);

        /// <summary>
        /// Remove um Wish existente
        /// </summary>
        /// <param name="UserId">Id do Usuario</param>
        /// <param name="ProductId">Id do Produto</param>
        /// <returns>True se a operacao deu certo, False ao contrario</returns>
        bool Remove(int UserId, int ProductId);

        /// <summary>
        /// Obtem todos os desejos de um usuario
        /// </summary>
        /// <param name="UserId">Id do usuario</param>
        /// <returns>A lista de desejos do usuario</returns>
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
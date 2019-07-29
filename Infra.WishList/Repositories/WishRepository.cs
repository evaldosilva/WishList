using Domain.WishList.Entity;
using Domain.WishList.Factory;
using Domain.WishList.Interface;
using Infra.Database.WishList.Persistence;
using System.Collections.Generic;

namespace Infra.Repository.WishList.Repositories
{
    public class WishRepository : IWishRepository
    {
        /// <summary>
        /// Cria um novo Wish
        /// </summary>
        /// <param name="UserId">Id do Usuario</param>
        /// <param name="ProductId">Id do Produto</param>
        /// <returns>True se a operacao deu certo, False ao contrario</returns>
        public bool Create(int UserId, int ProductId)
        {
            IUserRepository _userRepository = new UserRepository();
            IProductRepository _productRepository = new ProductRepository();

            // Busca o usuario e o product na base de dados
            User user = _userRepository.Get(UserId);
            Product product = _productRepository.Get(ProductId);

            if (user == null || product == null)
                return false;
            else
            {
                Wish wish = WishFactory.CreateWish(user, product);

                // Persiste na base de dados o novo wish
                WishPersistence wishPersistence = new WishPersistence();
                bool result = wishPersistence.Insert(wish);

                return result;
            }
        }

        /// <summary>
        /// RemoveWishAsync um Wish existente
        /// </summary>
        /// <param name="UserId">Id do Usuario</param>
        /// <param name="ProductId">Id do Produto</param>
        /// <returns>True se a operacao deu certo, False ao contrario</returns>
        public bool Remove(int UserId, int ProductId)
        {
            WishPersistence wishPersistence = new WishPersistence();
            return wishPersistence.Delete(UserId, ProductId);
        }

        /// <summary>
        /// Lista de Wishes de um usuario
        /// </summary>
        /// <param name="UserId">Id do usuario</param>
        /// <returns>Uma lista de wishes de um dado usuario</returns>
        public IList<Wish> GetAll(int UserId)
        {
            WishPersistence wishPersistence = new WishPersistence();
            return wishPersistence.GetAll(UserId);
        }

        /// <summary>
        /// Obtem um Wish existente
        /// </summary>
        /// <param name="UserId">Id do Usuario</param>
        /// <param name="ProductId">Id do Produto</param>
        /// <returns>O desejo de um usuario sobre um produto</returns>
        public Wish Get(int UserId, int ProductId)
        {
            WishPersistence wishPersistence = new WishPersistence();
            return wishPersistence.Get(UserId, ProductId);
        }

        /// <summary>
        /// RemoveWishAsync todos os Wishes de um usuario
        /// </summary>
        /// <param name="UserId">Id do Usuario</param>
        /// <returns>True se a operacao deu certo, False ao contrario</returns>
        public bool RemoveAll(int UserId)
        {
            WishPersistence wishPersistence = new WishPersistence();
            bool result = wishPersistence.RemoveAll(UserId);
            return result;
        }
    }
}
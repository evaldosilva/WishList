using Domain.WishList.Entity;
using Domain.WishList.Interface;
using Infra.Database.WishList.Persistence;
using System.Collections.Generic;

namespace Infra.Repository.WishList.Repositories
{
    /// <summary>
    /// Classe repository de User
    /// </summary>
    public class UserRepository : IUserRepository
    {
        /// <summary>
        /// Cria um novo User
        /// </summary>
        /// <param name="Name">Nome do usuario</param>
        /// <param name="Email">Email do usuario</param>
        /// <returns>True se a operacao deu certo, False ao contrario</returns>
        public bool Create(string name, string email)
        {
            // Cria um novo usuario
            User user = new User();
            user.Name = name;
            user.Email = email;

            // Persiste na base de dados o novo usuario
            UserPersistence userPersistence = new UserPersistence();
            bool result = userPersistence.Insert(user);

            return result;
        }

        /// <summary>
        /// Obtem um User
        /// </summary>
        /// <param name="Id">ID do usuario</param>
        /// <returns>Retorna um User encontrado pelo Id ou nulo se nao encontrar</returns>
        public User Get(int id)
        {
            UserPersistence userPersistence = new UserPersistence();
            return userPersistence.Get(id);
        }

        /// <summary>
        /// Lista todos os usuarios do sistema
        /// </summary>
        /// <returns>Uma lista de usuarios</returns>
        public IList<User> GetAll()
        {
            UserPersistence userPersistence = new UserPersistence();
            return userPersistence.GetAll<User>();
        }
    }
}
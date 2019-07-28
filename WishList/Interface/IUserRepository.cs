using Domain.WishList.Entity;
using System.Collections.Generic;

namespace Domain.WishList.Interface
{
    /// <summary>
    /// Interface de acesso as funcionalidades de um User no repositorio
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Cria um novo User
        /// </summary>
        /// <param name="name">Nome do usuario</param>
        /// <param name="email">Email do usuario</param>
        /// <returns>True se a operacao deu certo, False ao contrario</returns>
        bool Create(string name, string email);

        /// <summary>
        /// Lista todos os usuarios do sistema
        /// </summary>
        /// <returns>Uma lista de usuarios</returns>
        IList<User> GetAll();

        /// <summary>
        /// Obtem um User
        /// </summary>
        /// <param name="id">Id do usuario</param>
        /// <returns>Retorna um User encontrado pelo Id ou nulo se nao encontrar</returns>
        User Get(int id);
    }
}
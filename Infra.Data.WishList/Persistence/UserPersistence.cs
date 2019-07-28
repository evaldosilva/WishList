using Domain.WishList.Entity;
using Infra.Data.Interfaces;
using System.Collections.Generic;

namespace Infra.Database.WishList.Persistence
{
    /// <summary>
    /// Classe responsável pela persistencia de dados do User
    /// </summary>
    public class UserPersistence : IPersistence<User>
    {
        /* A fins de teste, criei uma lista estatica como base de dados, mas poderia ser 
         * um banco de dados tradicional, um NOSQL, uma implementacao ORM, arquivos texto, 
         * ou qualquer outro modo de persistencia.*/
        public static int fakeId = 1;
        public static List<User> TabelaUsers = new List<User>();

        /// <summary>
        /// Obtem um usuario
        /// </summary>
        /// <param name="id">Id do usuario</param>
        /// <returns>Obtem um registro de usuario</returns>
        public User Get(int id)
        {
            return TabelaUsers.Find(u => u.Id == id);
        }

        /// <summary>
        /// Lista de Users
        /// </summary>
        /// <returns>Uma lista de usuarios</returns>
        public IList<User> GetAll<User>()
        {
            return TabelaUsers as IList<User>;
        }

        /// <summary>
        /// Insere um novo User na base de dados
        /// </summary>
        /// <typeparam name="T">Classe de usuario</typeparam>
        /// <param name="record">Usuario a ser adicionado</param>
        /// <returns>True se a operacao deu certo, False ao contrario</returns>
        public bool Insert<T>(T record)
        {
            // Verifica se o tipo generico e um User
            User user = record as User;

            // Se nao for, termina a operacao
            if (user == null)
                return false;
            else
            {
                // Senao, adiciona uma chave fake controlada, simulando uma geracao de PK via sequence, por exemplo
                user.Id = fakeId++;

                // Adiciona o novo usuario na base de dados
                TabelaUsers.Add(record as User);

                return true;
            }
        }
    }
}
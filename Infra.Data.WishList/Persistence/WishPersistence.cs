using Domain.WishList.Entity;
using Infra.Data.Interfaces;
using System;
using System.Collections.Generic;

namespace Infra.Database.WishList.Persistence
{
    public class WishPersistence : IPersistenceWish
    {
        /* A fins de teste, criei uma lista estatica como base de dados, mas poderia ser 
         * um banco de dados tradicional, um NOSQL, uma implementacao ORM, arquivos texto, 
         * ou qualquer outro modo de persistencia.*/
        public static List<Wish> TabelaWishes = new List<Wish>();

        /// <summary>
        /// Apaga um Wish da base de dados
        /// </summary>
        /// <param name="wishId">Id do wish</param>
        /// <returns>True se a operacao deu certo, False ao contrario</returns>
        public bool Delete(int UserId, int ProductId)
        {
            try
            {
                // Verifica se o wish a ser apagado existe no sistema
                Wish wish = FindWish(UserId, ProductId);

                // Se nao existir, termina a operacao
                if (wish == null)
                    return false;
                else
                {
                    // Se existir, remove o registro da base de dados 
                    TabelaWishes.Remove(wish);
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Obtem um Wish existente
        /// </summary>
        /// <param name="UserId">Id do Usuario</param>
        /// <param name="ProductId">Id do Produto</param>
        /// <returns>O desejo de um usuario sobre um produto</returns>
        public Wish Get(int UserId, int ProductId)
        {
            return TabelaWishes.Find(w => w.User.Id == UserId && w.Product.Id == ProductId);
        }

        /// <summary>
        /// Lista de Wishes de um usuario
        /// </summary>
        /// <param name="UserId">Id do usuario</param>
        /// <returns>Uma lista de wishes de um dado usuario</returns>
        public IList<Wish> GetAll(int UserId)
        {
            return TabelaWishes.FindAll(w => w.User.Id == UserId);
        }

        /// <summary>
        /// Insere um novo Wish
        /// </summary>
        /// <param name="record">Registro a ser inserido</param>
        /// <returns>True se a operacao deu certo, False ao contrario</returns>
        public bool Insert(Wish record)
        {
            if (record == null)
                return false;
            else
            {
                // Adiciona o novo wish na base de dados
                TabelaWishes.Add(record);

                return true;
            }
        }

        /// <summary>
        /// Remove todos os Wishes de um usuario da base de dados
        /// </summary>
        /// <param name="UserId">Id do usuario</param>
        /// <returns>True se a operacao deu certo, False ao contrario</returns>
        public bool RemoveAll(int UserId)
        {
            return TabelaWishes.RemoveAll(wish => wish.User != null && wish.User.Id == UserId) > 0;
        }

        /// <summary>
        /// Encontra um wish na base de dados
        /// </summary>
        /// <param name="UserId">Id do usuario</param>
        /// <param name="ProductId">Id do produto</param>
        /// <returns>O Wish com o  fornecido. Nulo caso contrario.</returns>
        private Wish FindWish(int UserId, int ProductId)
        {
            Wish foundUser = TabelaWishes.Find(item => item.User.Id == UserId && item.Product.Id == ProductId);
            return foundUser;
        }
    }
}
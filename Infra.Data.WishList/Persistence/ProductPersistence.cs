using Domain.WishList.Entity;
using Infra.Data.Interfaces;
using System.Collections.Generic;

namespace Infra.Database.WishList.Persistence
{
    /// <summary>
    /// Classe responsável pela persistencia de dados do Product
    /// </summary>
    public class ProductPersistence : IPersistence<Product>
    {
        /* A fins de teste, criei uma lista estatica como base de dados, mas poderia ser 
         * um banco de dados tradicional, um NOSQL, uma implementacao ORM, arquivos texto, 
         * ou qualquer outro modo de persistencia.*/
        public static int fakeId = 1;
        public static List<Product> TabelaProducts = new List<Product>();

        /// <summary>
        /// Obtem um produto
        /// </summary>
        /// <param name="id">Id do produto</param>
        /// <returns>Obtem um registro de produto</returns>
        public Product Get(int id)
        {
            return TabelaProducts.Find(p => p.Id == id);
        }

        /// <summary>
        /// Lista de Products
        /// </summary>
        /// <returns>Uma lista de produtos</returns>
        public IList<Product> GetAll<Product>()
        {
            return TabelaProducts as IList<Product>;
        }

        /// <summary>
        /// Insere um novo Product na base de dados
        /// </summary>
        /// <typeparam name="T">Classe de produto</typeparam>
        /// <param name="record">Produto a ser adicionado</param>
        /// <returns>True se a operacao deu certo, False ao contrario</returns>
        public bool Insert<T>(T record)
        {
            // Verifica se o tipo generico e um Product
            Product product = record as Product;

            // Se nao for, termina a operacao
            if (product == null)
                return false;
            else
            {
                // Senao, adiciona uma chave fake controlada, simulando uma geracao de PK via sequence, por exemplo
                product.Id = fakeId++;

                // Adiciona o novo produto na base de dados
                TabelaProducts.Add(record as Product);

                return true;
            }
        }
    }
}
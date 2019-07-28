using System.Collections.Generic;

namespace Infra.Data.Interfaces
{
    /// <summary>
    /// Interface generica para as operacoes de persistencia
    /// </summary>
    public interface IPersistence<T>
    {
        /// <summary>
        /// Insere um novo registro
        /// </summary>
        /// <typeparam name="T">Tipo de registro a ser inserido</typeparam>
        /// <param name="record">Registro a ser inserido</param>
        /// <returns>True se a operacao deu certo, False ao contrario</returns>
        bool Insert<T>(T record);

        /// <summary>
        /// Obtem todos os registros de uma entidade
        /// </summary>
        /// <returns>Uma lista de usuarios</returns>
        IList<T> GetAll<T>();

        /// <summary>
        /// Obtem um registro
        /// </summary>
        /// <returns>Obtem um registro</returns>
        T Get(int id);
    }
}
using CrossCutting.Pagination;
using Domain.WishList.Entity;
using Domain.WishList.Interface;
using System.Collections.Generic;
using System.Linq;

namespace Service.WishList.Services
{
    /// <summary>
    /// Classe de servico para administrar as funcionalidades relacionadas ao Wish
    /// </summary>
    public class WishService
    {
        /// <summary>
        /// Interface de acesso as funcionalidades do Wish
        /// </summary>
        IWishRepository _wishListRepository;

        /// <summary>
        /// Cria um novo servico de Wish
        /// </summary>
        /// <param name="wishRepository">Repositorio do servico</param>
        public WishService(IWishRepository wishRepository)
        {
            _wishListRepository = wishRepository;
        }

        /// <summary>
        /// Cria um novo Wish
        /// </summary>
        /// <param name="UserId">Id do Usuario</param>
        /// <param name="ProductId">Id do Produto</param>
        /// <returns>True se a operacao deu certo, False ao contrario</returns>
        public bool Create(int UserId, int ProductId)
        {
            return _wishListRepository.Create(UserId, ProductId);
        }

        /// <summary>
        /// Remove todos os Wishes de um usuario
        /// </summary>
        /// <param name="UserId">Id do usuario</param>
        /// <returns>True se a operacao deu certo, False ao contrario</returns>
        public bool RemoveAll(int UserId)
        {
            return _wishListRepository.RemoveAll(UserId);
        }

        /// <summary>
        /// Remove um Wish
        /// </summary>
        /// <param name="UserId">Id do Usuario</param>
        /// <param name="ProductId">Id do Produto</param>
        /// <returns>True se a operacao deu certo, False ao contrario</returns>
        public bool Remove(int UserId, int ProductId)
        {
            return _wishListRepository.Remove(UserId, ProductId);
        }

        /// <summary>
        /// Obtem um Wish existente
        /// </summary>
        /// <param name="UserId">Id do Usuario</param>
        /// <param name="ProductId">Id do Produto</param>
        /// <returns>O desejo de um usuario sobre um produto</returns>
        public Wish GetWish(int UserId, int ProductId)
        {
            return _wishListRepository.Get(UserId, ProductId);
        }

        /// <summary>
        /// Lista os Wishes da base de dados
        /// </summary>
        /// <param name="paginationParameter">Filtros para uma exibicao paginada</param>
        /// <param name="UserId">Id do usuario</param>
        /// <returns>Lista de Users filtrada pelos parametros de paginacao</returns>
        public IList<Wish> ListWishes(PaginationParameter paginationParameter, int UserId)
        {
            // Neste caso, obtem todos os desejos para fazer a paginação, mas poderia ser criada uma 
            // nova função na intreface para refinar mais a lista passando filtros direto para a consulta
            // na camada de persistencia, para melhorar a performance.
            List<Wish> wishes = new List<Wish>(_wishListRepository.GetAll(UserId));

            // Realiza a paginação da lista
            List<Wish> wishesPage = wishes.
                Skip((paginationParameter.numeroPagina - 1) * paginationParameter.numeroRegistrosPorPagina).
                Take(paginationParameter.numeroRegistrosPorPagina)
                .ToList();

            return wishesPage;
        }
    }
}
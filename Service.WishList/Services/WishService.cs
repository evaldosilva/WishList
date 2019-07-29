using CrossCutting.Pagination;
using Domain.WishList.Entity;
using Domain.WishList.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public async Task<bool> CreateWishAsync(int UserId, int ProductId)
        {
            Task<bool> tCreateWish = new Task<bool>(() => { return _wishListRepository.Create(UserId, ProductId); });
            tCreateWish.Start();
            return await tCreateWish;
        }

        /// <summary>
        /// RemoveWishAsync todos os Wishes de um usuario
        /// </summary>
        /// <param name="UserId">Id do usuario</param>
        /// <returns>True se a operacao deu certo, False ao contrario</returns>
        public async Task<bool> RemoveAllWishesAsync(int UserId)
        {
            Task<bool> tRemoveAllWish = new Task<bool>(() => { return _wishListRepository.RemoveAll(UserId); });
            tRemoveAllWish.Start();
            return await tRemoveAllWish;
        }

        /// <summary>
        /// RemoveWishAsync um Wish
        /// </summary>
        /// <param name="UserId">Id do Usuario</param>
        /// <param name="ProductId">Id do Produto</param>
        /// <returns>True se a operacao deu certo, False ao contrario</returns>
        public async Task<bool> RemoveWishAsync(int UserId, int ProductId)
        {
            Task<bool> tRemove = new Task<bool>(() => { return _wishListRepository.Remove(UserId, ProductId); });
            tRemove.Start();
            return await tRemove;
        }

        /// <summary>
        /// Obtem um Wish existente
        /// </summary>
        /// <param name="UserId">Id do Usuario</param>
        /// <param name="ProductId">Id do Produto</param>
        /// <returns>O desejo de um usuario sobre um produto</returns>
        public async Task<Wish> GetWishAsync(int UserId, int ProductId)
        {
            Task<Wish> tWish = new Task<Wish>(() => { return _wishListRepository.Get(UserId, ProductId); });
            tWish.Start();
            return await tWish;
        }

        /// <summary>
        /// Lista os Wishes da base de dados
        /// </summary>
        /// <param name="paginationParameter">Filtros para uma exibicao paginada</param>
        /// <param name="UserId">Id do usuario</param>
        /// <returns>Lista de Users filtrada pelos parametros de paginacao</returns>
        public async Task<IList<Wish>> ListWishesAsync(PaginationParameter paginationParameter, int UserId)
        {
            Task<IList<Wish>> tListWish = new Task<IList<Wish>>(() =>
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
            });
            tListWish.Start();
            return await tListWish;
        }
    }
}
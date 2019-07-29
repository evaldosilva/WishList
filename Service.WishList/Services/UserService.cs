using CrossCutting.Pagination;
using Domain.WishList.Entity;
using Domain.WishList.Interface;
using Service.WishList.Validators;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.WishList.Services
{
    /// <summary>
    /// Classe de servico para administrar as funcionalidades relacionadas ao User
    /// </summary>
    public class UserService
    {
        /// <summary>
        /// Interface de acesso as funcionalidades do User
        /// </summary>
        IUserRepository _userRepository;

        /// <summary>
        /// Cria um novo servico de User
        /// </summary>
        /// <param name="productRepository">Repositorio do servico</param>
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// Cria um novo User na base de dados
        /// </summary>
        /// <param name="Name">Nome do usuario</param>
        /// <param name="Email">Email do usuario</param>
        /// <returns>True se a operacao deu certo, False ao contrario</returns>
        public async Task<bool> CreateUserAsync(string name, string email)
        {
            Task<bool> tCreateUser = new Task<bool>(() =>
            {
                if (BasicValidator.isNameValido(name) && BasicValidator.isEmailValido(email))
                    return _userRepository.Create(name, email);
                else
                    return false;
            });
            tCreateUser.Start();
            return await tCreateUser;
        }

        /// <summary>
        /// Lista os Users da base de dados
        /// </summary>
        /// <param name="paginationParameter">Filtros para uma exibicao paginada</param>
        /// <returns>Lista de Users filtrada pelos parametros de paginacao</returns>
        public async Task<IList<User>> ListUsers(PaginationParameter paginationParameter)
        {
            Task<IList<User>> tListUsers = new Task<IList<User>>(() =>
            {
                // Neste caso, obtem todos os usuarios para fazer a paginação, mas poderia ser criada uma 
                // nova função na intreface para refinar mais a lista passando filtros direto para a consulta
                // na camada de persistencia, para melhorar a performance.
                List<User> users = new List<User>(_userRepository.GetAll());

                // Realiza a paginação da lista
                List<User> usersPage = users.
                    Skip((paginationParameter.numeroPagina - 1) * paginationParameter.numeroRegistrosPorPagina).
                    Take(paginationParameter.numeroRegistrosPorPagina)
                    .ToList();

                return usersPage;
            });
            tListUsers.Start();
            return await tListUsers;
        }
    }
}
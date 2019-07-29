using CrossCutting.Pagination;
using Domain.WishList.Entity;
using Domain.WishList.Interface;
using Infra.Repository.WishList.Repositories;
using Service.WishList.Services;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using WishListWebApi.ModelsDTO;

namespace WishListWebApi.Controllers
{
    public class UsersController : ApiController
    {
        static readonly IUserRepository _repositorio = new UserRepository();
        static readonly UserService _servico = new UserService(_repositorio);

        [HttpPost]
        public async Task<IHttpActionResult> PostUser(User user)
        {
            bool criado = await _servico.CreateUserAsync(user.Name, user.Email);
            if (criado)
                return Content(HttpStatusCode.Created, string.Empty);
            else
                return Content(HttpStatusCode.NoContent, string.Empty);
        }

        [HttpGet]
        public async Task<IEnumerable<GetAllUsersDTO>> GetAllUsers([FromUri]int page_size, [FromUri]int page)
        {
            PaginationParameter paginationParameter = new PaginationParameter(page, page_size);
            IList<User> users = await _servico.ListUsers(paginationParameter);
            List<GetAllUsersDTO> listGetAllUsersDTO = new List<GetAllUsersDTO>();

            // Faz a troca de dados da classe de dominio para a classe de exibicao
            if (users != null && users.Count > 0)
                foreach (User user in users)
                {
                    GetAllUsersDTO userModel = new GetAllUsersDTO();
                    userModel.id = user.Id;
                    userModel.name = user.Name;
                    userModel.email = user.Email;
                    listGetAllUsersDTO.Add(userModel);
                }
            return listGetAllUsersDTO;
        }
    }
}
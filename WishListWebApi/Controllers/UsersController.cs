using CrossCutting.Pagination;
using Domain.WishList.Entity;
using Domain.WishList.Interface;
using Infra.Repository.WishList.Repositories;
using Service.WishList.Services;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WishListWebApi.Models;

namespace WishListWebApi.Controllers
{
    public class UsersController : ApiController
    {
        static readonly IUserRepository _repositorio = new UserRepository();
        static readonly UserService _servico = new UserService(_repositorio);

        [HttpPost]
        public HttpResponseMessage PostUser(User user)
        {
            bool criado = _servico.CreateUser(user.Name, user.Email);
            if (criado)
                return new HttpResponseMessage(HttpStatusCode.Created);
            else
                return new HttpResponseMessage(HttpStatusCode.NoContent);
        }

        [HttpGet]
        public IEnumerable<GetAllUsersViewModel> GetAllUsers([FromUri]int page_size, [FromUri]int page)
        {
            PaginationParameter paginationParameter = new PaginationParameter(page, page_size);
            IList<User> users = _servico.ListUsers(paginationParameter);
            List<GetAllUsersViewModel> listGetAllUsersViewModel = new List<GetAllUsersViewModel>();

            // Faz a troca de dados da classe de dominio para a classe de exibicao
            if (users != null && users.Count > 0)
                foreach (User user in users)
                {
                    GetAllUsersViewModel userModel = new GetAllUsersViewModel();
                    userModel.id = user.Id;
                    userModel.name = user.Name;
                    userModel.email = user.Email;
                    listGetAllUsersViewModel.Add(userModel);
                }
            return listGetAllUsersViewModel;
        }
    }
}
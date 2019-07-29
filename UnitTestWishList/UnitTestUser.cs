using CrossCutting.Pagination;
using Infra.Repository.WishList.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Service.WishList.Services;

namespace UnitTestWishList
{
    [TestClass]
    public class UnitTestUser
    {
        [TestMethod]
        public void Test_CreateUser()
        {
            UserRepository _userRepository = new UserRepository();
            UserService userService = new UserService(_userRepository);

            Assert.AreEqual(userService.CreateUserAsync("Evaldo", "evaldo@email.com").Result, true);
            Assert.AreEqual(userService.CreateUserAsync("Rodrigo Carvalho", "rodrigo@email.com").Result, true);
            Assert.AreEqual(userService.CreateUserAsync("Marcel Grilo", "marcel@email.com").Result, true);
            Assert.AreEqual(userService.CreateUserAsync("Alexandre Faria", "alexandre@email.com").Result, true);
        }

        [TestMethod, Description("Obtem todos os usuarios, limitados a paginacao padrao")]
        public void Test_ListUsers()
        {
            UserRepository _userRepository = new UserRepository();
            UserService userService = new UserService(_userRepository);
            PaginationParameter paginationParameter = new PaginationParameter();

            Assert.AreEqual(userService.CreateUserAsync("Rodrigo Carvalho", "rodrigo@email.com").Result, true);
            Assert.AreEqual(userService.CreateUserAsync("Marcel Grilo", "marcel@email.com").Result, true);
            Assert.AreEqual(userService.CreateUserAsync("Alexandre Faria", "alexandre@email.com").Result, true);

            Assert.IsNotNull(userService.ListUsers(paginationParameter));
        }

        [TestMethod, Description("Obtem usuarios limitados pela paginacao")]
        public void Test_ListUsers_Pagina_Default()
        {
            UserRepository _userRepository = new UserRepository();
            UserService userService = new UserService(_userRepository);
            PaginationParameter paginationParameter = new PaginationParameter();

            Assert.AreEqual(userService.CreateUserAsync("Rodrigo Carvalho", "rodrigo@email.com").Result, true);
            Assert.AreEqual(userService.CreateUserAsync("Marcel Grilo", "marcel@email.com").Result, true);
            Assert.AreEqual(userService.CreateUserAsync("Alexandre Faria", "alexandre@email.com").Result, true);
            Assert.AreEqual(userService.CreateUserAsync("Evaldo", "evaldo@email.com").Result, true);
            Assert.AreEqual(userService.CreateUserAsync("Joao", "joao@email.com").Result, true);
            Assert.AreEqual(userService.CreateUserAsync("Greice", "greice@email.com").Result, true);
            Assert.AreEqual(userService.CreateUserAsync("Maria", "maria@email.com").Result, true);
            Assert.AreEqual(userService.CreateUserAsync("Kelly", "kelly@email.com").Result, true);
            Assert.AreEqual(userService.CreateUserAsync("Ana", "ana@email.com").Result, true);
            Assert.AreEqual(userService.CreateUserAsync("Paula", "paula@email.com").Result, true);

            // Fim do limite default de paginacao, nao devem ser exibidos
            Assert.AreEqual(userService.CreateUserAsync("Nao Exibir", "nao@email.com").Result, true);

            Assert.IsNotNull(userService.ListUsers(paginationParameter));
            Assert.IsTrue(userService.ListUsers(paginationParameter).Result.Count <= paginationParameter.numeroRegistrosPorPagina);
        }
    }
}
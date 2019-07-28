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

            Assert.AreEqual(userService.CreateUser("Evaldo", "evaldo@email.com"), true);
            Assert.AreEqual(userService.CreateUser("Rodrigo Carvalho", "rodrigo@email.com"), true);
            Assert.AreEqual(userService.CreateUser("Marcel Grilo", "marcel@email.com"), true);
            Assert.AreEqual(userService.CreateUser("Alexandre Faria", "alexandre@email.com"), true);
        }

        [TestMethod, Description("Obtem todos os usuarios, limitados a paginacao padrao")]
        public void Test_ListUsers()
        {
            UserRepository _userRepository = new UserRepository();
            UserService userService = new UserService(_userRepository);
            PaginationParameter paginationParameter = new PaginationParameter();

            Assert.AreEqual(userService.CreateUser("Rodrigo Carvalho", "rodrigo@email.com"), true);
            Assert.AreEqual(userService.CreateUser("Marcel Grilo", "marcel@email.com"), true);
            Assert.AreEqual(userService.CreateUser("Alexandre Faria", "alexandre@email.com"), true);

            Assert.IsNotNull(userService.ListUsers(paginationParameter));
        }

        [TestMethod, Description("Obtem usuarios limitados pela paginacao")]
        public void Test_ListUsers_Pagina_Default()
        {
            UserRepository _userRepository = new UserRepository();
            UserService userService = new UserService(_userRepository);
            PaginationParameter paginationParameter = new PaginationParameter();

            Assert.AreEqual(userService.CreateUser("Rodrigo Carvalho", "rodrigo@email.com"), true);
            Assert.AreEqual(userService.CreateUser("Marcel Grilo", "marcel@email.com"), true);
            Assert.AreEqual(userService.CreateUser("Alexandre Faria", "alexandre@email.com"), true);
            Assert.AreEqual(userService.CreateUser("Evaldo", "evaldo@email.com"), true);
            Assert.AreEqual(userService.CreateUser("Joao", "joao@email.com"), true);
            Assert.AreEqual(userService.CreateUser("Greice", "greice@email.com"), true);
            Assert.AreEqual(userService.CreateUser("Maria", "maria@email.com"), true);
            Assert.AreEqual(userService.CreateUser("Kelly", "kelly@email.com"), true);
            Assert.AreEqual(userService.CreateUser("Ana", "ana@email.com"), true);
            Assert.AreEqual(userService.CreateUser("Paula", "paula@email.com"), true);

            // Fim do limite default de paginacao, nao devem ser exibidos
            Assert.AreEqual(userService.CreateUser("Nao Exibir", "nao@email.com"), true);

            Assert.IsNotNull(userService.ListUsers(paginationParameter));
            Assert.IsTrue(userService.ListUsers(paginationParameter).Count <= paginationParameter.numeroRegistrosPorPagina);
        }
    }
}
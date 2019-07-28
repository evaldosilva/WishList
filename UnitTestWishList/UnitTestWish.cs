using CrossCutting.Pagination;
using Infra.Repository.WishList.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Service.WishList.Services;

namespace UnitTestWishList
{
    [TestClass]
    public class UnitTestWish
    {
        [TestMethod]
        public void TestMethod_CreateWish_Sem_Produto()
        {
            UserRepository _userRepository = new UserRepository();
            UserService userService = new UserService(_userRepository);

            Assert.AreEqual(userService.CreateUser("Rodrigo Carvalho", "rodrigo@email.com"), true);

            WishRepository _wishRepository = new WishRepository();
            WishService wishService = new WishService(_wishRepository);

            Assert.AreEqual(wishService.Create(1, 1), false);
        }

        [TestMethod]
        public void TestMethod_CreateWish_Sem_User()
        {
            ProductRepository _productRepository = new ProductRepository();
            ProductService productService = new ProductService(_productRepository);

            Assert.AreEqual(productService.CreateProduct("Batedeira"), true);

            WishRepository _wishRepository = new WishRepository();
            WishService wishService = new WishService(_wishRepository);

            Assert.AreEqual(wishService.Create(1, 1), false);
        }

        [TestMethod]
        public void TestMethod_CreateWish()
        {
            ProductRepository _productRepository = new ProductRepository();
            ProductService productService = new ProductService(_productRepository);

            Assert.AreEqual(productService.CreateProduct("Batedeira"), true);
            Assert.AreEqual(productService.CreateProduct("Video Cassete"), true);
            Assert.AreEqual(productService.CreateProduct("Toca Fitas"), true);

            UserRepository _userRepository = new UserRepository();
            UserService userService = new UserService(_userRepository);

            Assert.AreEqual(userService.CreateUser("Rodrigo Carvalho", "rodrigo@email.com"), true);

            WishRepository _wishRepository = new WishRepository();
            WishService wishService = new WishService(_wishRepository);

            Assert.AreEqual(wishService.Create(1, 1), true);
            Assert.AreEqual(wishService.Create(1, 3), true);
        }

        [TestMethod]
        public void TestMethod_DeleteWish()
        {
            TestMethod_CreateWish();

            WishRepository _wishRepository = new WishRepository();
            WishService wishService = new WishService(_wishRepository);

            Assert.AreEqual(wishService.Remove(1, 1), true);
            Assert.AreEqual(wishService.Remove(1, 2), false);
            Assert.AreEqual(wishService.Remove(1, 3), true);
        }

        [TestMethod, Description("Obtem todos os desejos, limitados a paginacao padrao")]
        public void TestMethod_ListWishes()
        {
            TestMethod_CreateWish();

            WishRepository _wishRepository = new WishRepository();
            WishService wishService = new WishService(_wishRepository);
            PaginationParameter paginationParameter = new PaginationParameter();

            Assert.IsNotNull(wishService.ListWishes(paginationParameter, 1));
            Assert.AreEqual(wishService.ListWishes(paginationParameter, 2).Count, 0);
        }
    }
}
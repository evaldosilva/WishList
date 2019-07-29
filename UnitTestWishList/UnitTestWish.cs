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

            Assert.AreEqual(userService.CreateUserAsync("Rodrigo Carvalho", "rodrigo@email.com").Result, true);

            WishRepository _wishRepository = new WishRepository();
            WishService wishService = new WishService(_wishRepository);

            Assert.AreEqual(wishService.CreateWishAsync(1, 1).Result, false);
        }

        [TestMethod]
        public void TestMethod_CreateWish_Sem_User()
        {
            ProductRepository _productRepository = new ProductRepository();
            ProductService productService = new ProductService(_productRepository);

            Assert.AreEqual(productService.CreateProductAsync("Batedeira").Result, true);

            WishRepository _wishRepository = new WishRepository();
            WishService wishService = new WishService(_wishRepository);

            Assert.AreEqual(wishService.CreateWishAsync(1, 1).Result, false);
        }

        [TestMethod]
        public void TestMethod_CreateWish()
        {
            ProductRepository _productRepository = new ProductRepository();
            ProductService productService = new ProductService(_productRepository);

            Assert.AreEqual(productService.CreateProductAsync("Batedeira").Result, true);
            Assert.AreEqual(productService.CreateProductAsync("Video Cassete").Result, true);
            Assert.AreEqual(productService.CreateProductAsync("Toca Fitas").Result, true);

            UserRepository _userRepository = new UserRepository();
            UserService userService = new UserService(_userRepository);

            Assert.AreEqual(userService.CreateUserAsync("Rodrigo Carvalho", "rodrigo@email.com").Result, true);

            WishRepository _wishRepository = new WishRepository();
            WishService wishService = new WishService(_wishRepository);

            Assert.AreEqual(wishService.CreateWishAsync(1, 1).Result, true);
            Assert.AreEqual(wishService.CreateWishAsync(1, 3).Result, true);
        }

        [TestMethod]
        public void TestMethod_DeleteWish()
        {
            TestMethod_CreateWish();

            WishRepository _wishRepository = new WishRepository();
            WishService wishService = new WishService(_wishRepository);

            Assert.AreEqual(wishService.RemoveWishAsync(1, 1).Result, true);
            Assert.AreEqual(wishService.RemoveWishAsync(1, 2).Result, false);
            Assert.AreEqual(wishService.RemoveWishAsync(1, 3).Result, true);
        }

        [TestMethod, Description("Obtem todos os desejos, limitados a paginacao padrao")]
        public void TestMethod_ListWishes()
        {
            TestMethod_CreateWish();

            WishRepository _wishRepository = new WishRepository();
            WishService wishService = new WishService(_wishRepository);
            PaginationParameter paginationParameter = new PaginationParameter();

            Assert.IsNotNull(wishService.ListWishesAsync(paginationParameter, 1));
            Assert.AreEqual(wishService.ListWishesAsync(paginationParameter, 2).Result.Count, 0);
        }
    }
}
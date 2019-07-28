using CrossCutting.Pagination;
using Infra.Repository.WishList.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Service.WishList.Services;

namespace UnitTestWishList
{
    [TestClass]
    public class UnitTestProduct
    {
        [TestMethod]
        public void TestMethod_CreateProduct()
        {
            ProductRepository _productRepository = new ProductRepository();
            ProductService productService = new ProductService(_productRepository);

            Assert.AreEqual(productService.CreateProduct("Batedeira"), true);
            Assert.AreEqual(productService.CreateProduct("Video Cassete"), true);
            Assert.AreEqual(productService.CreateProduct("Toca Fitas"), true);
        }

        [TestMethod, Description("Obtem todos os produtos, limitados a paginacao padrao")]
        public void TestMethod_ListProducts()
        {
            ProductRepository _productRepository = new ProductRepository();
            ProductService productService = new ProductService(_productRepository);
            PaginationParameter paginationParameter = new PaginationParameter();

            Assert.AreEqual(productService.CreateProduct("Batedeira"), true);
            Assert.AreEqual(productService.CreateProduct("Video Cassete"), true);
            Assert.AreEqual(productService.CreateProduct("Toca Fitas"), true);

            Assert.IsNotNull(productService.ListProducts(paginationParameter));
        }

        [TestMethod, Description("Obtem produtos limitados pela paginacao")]
        public void TestMethod_ListProducts_Pagina_Default()
        {
            ProductRepository _productRepository = new ProductRepository();
            ProductService productService = new ProductService(_productRepository);
            PaginationParameter paginationParameter = new PaginationParameter();

            Assert.AreEqual(productService.CreateProduct("Batedeira"), true);
            Assert.AreEqual(productService.CreateProduct("Video Cassete"), true);
            Assert.AreEqual(productService.CreateProduct("Toca Fitas"), true);
            Assert.AreEqual(productService.CreateProduct("Microondas"), true);
            Assert.AreEqual(productService.CreateProduct("TV"), true);
            Assert.AreEqual(productService.CreateProduct("Computador"), true);
            Assert.AreEqual(productService.CreateProduct("Notebook"), true);
            Assert.AreEqual(productService.CreateProduct("Fritadeira"), true);
            Assert.AreEqual(productService.CreateProduct("Celular"), true);
            Assert.AreEqual(productService.CreateProduct("Impressora"), true);

            // Fim do limite default de paginacao, nao devem ser exibidos
            Assert.AreEqual(productService.CreateProduct("Nao exibir"), true);

            Assert.IsNotNull(productService.ListProducts(paginationParameter));
            Assert.IsTrue(productService.ListProducts(paginationParameter).Count <= paginationParameter.numeroRegistrosPorPagina);
        }
    }
}
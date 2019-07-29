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

            Assert.AreEqual(productService.CreateProductAsync("Batedeira").Result, true);
            Assert.AreEqual(productService.CreateProductAsync("Video Cassete").Result, true);
            Assert.AreEqual(productService.CreateProductAsync("Toca Fitas").Result, true);
        }

        [TestMethod, Description("Obtem todos os produtos, limitados a paginacao padrao")]
        public void TestMethod_ListProducts()
        {
            ProductRepository _productRepository = new ProductRepository();
            ProductService productService = new ProductService(_productRepository);
            PaginationParameter paginationParameter = new PaginationParameter();

            Assert.AreEqual(productService.CreateProductAsync("Batedeira").Result, true);
            Assert.AreEqual(productService.CreateProductAsync("Video Cassete").Result, true);
            Assert.AreEqual(productService.CreateProductAsync("Toca Fitas").Result, true);

            Assert.IsNotNull(productService.ListProductsAsync(paginationParameter));
        }

        [TestMethod, Description("Obtem produtos limitados pela paginacao")]
        public void TestMethod_ListProducts_Pagina_Default()
        {
            ProductRepository _productRepository = new ProductRepository();
            ProductService productService = new ProductService(_productRepository);
            PaginationParameter paginationParameter = new PaginationParameter();

            Assert.AreEqual(productService.CreateProductAsync("Batedeira").Result, true);
            Assert.AreEqual(productService.CreateProductAsync("Video Cassete").Result, true);
            Assert.AreEqual(productService.CreateProductAsync("Toca Fitas").Result, true);
            Assert.AreEqual(productService.CreateProductAsync("Microondas").Result, true);
            Assert.AreEqual(productService.CreateProductAsync("TV").Result, true);
            Assert.AreEqual(productService.CreateProductAsync("Computador").Result, true);
            Assert.AreEqual(productService.CreateProductAsync("Notebook").Result, true);
            Assert.AreEqual(productService.CreateProductAsync("Fritadeira").Result, true);
            Assert.AreEqual(productService.CreateProductAsync("Celular").Result, true);
            Assert.AreEqual(productService.CreateProductAsync("Impressora").Result, true);

            // Fim do limite default de paginacao, nao devem ser exibidos
            Assert.AreEqual(productService.CreateProductAsync("Nao exibir").Result, true);

            Assert.IsNotNull(productService.ListProductsAsync(paginationParameter));
            Assert.IsTrue(productService.ListProductsAsync(paginationParameter).Result.Count <= paginationParameter.numeroRegistrosPorPagina);
        }
    }
}
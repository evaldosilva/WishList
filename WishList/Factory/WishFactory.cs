using Domain.WishList.Entity;

namespace Domain.WishList.Factory
{
    /* Criei um padrão Factory para esta classe porque, apesar de ter um modelo simples, 
     * é composta por mais de um objeto. Seria mais para demonstrar a utilização, ideal 
     * em modelos de classe mais complexos.*/

    /// <summary>
    /// Classe fabrica de Wish
    /// </summary>
    public static class WishFactory
    {
        /// <summary>
        /// Cria um novo Wish associando um Produto a um Usuario
        /// </summary>
        /// <returns>Um novo wish</returns>
        public static Wish CreateWish(User user, Product product)
        {
            Wish wish = new Wish();
            wish.User = user;
            wish.Product = product;
            return wish;
        }
    }
}
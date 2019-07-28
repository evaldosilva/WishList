namespace Domain.WishList.Entity
{
    /// <summary>
    /// Classe de produtos desejados por um usuario
    /// </summary>
    public class Wish
    {
        /// <summary>
        /// Usuario
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// Produto desejado
        /// </summary>
        public Product Product { get; set; }
    }
}
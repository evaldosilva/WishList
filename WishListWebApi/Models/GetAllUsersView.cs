namespace WishListWebApi.Models
{
    /// <summary>
    /// Classe adaptadora para a exibicao dos dados do usuario
    /// </summary>
    public class GetAllUsersViewModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
    }
}
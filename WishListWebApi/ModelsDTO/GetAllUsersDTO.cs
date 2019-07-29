namespace WishListWebApi.ModelsDTO
{
    /// <summary>
    /// Classe DTO para a exibicao dos dados do usuario
    /// </summary>
    public class GetAllUsersDTO
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
    }
}
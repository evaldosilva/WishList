namespace Service.WishList.Validators
{
    /// <summary>
    /// Classe de validacao de dados gerais
    /// </summary>
    public static class BasicValidator
    {
        /// <summary>
        /// Verifica se um nome e valido
        /// </summary>
        /// <param name="name">Nome a ser validado</param>
        /// <returns>True se a operacao deu certo, False ao contrario</returns>
        public static bool isNameValido(string name)
        {
            return !string.IsNullOrWhiteSpace(name);
        }

        /// <summary>
        /// Verifica se um email e valido
        /// </summary>
        /// <param name="name">Email a ser validado</param>
        /// <returns>True se a operacao deu certo, False ao contrario</returns>
        public static bool isEmailValido(string email)
        {
            return !string.IsNullOrWhiteSpace(email);
        }
    }
}
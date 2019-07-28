namespace CrossCutting.Pagination
{
    /// <summary>
    /// Classe auxiliar para a paginacao de dados
    /// </summary>
    public class PaginationParameter
    {
        /// <summary>
        /// Variavel de controle do numero maximo de registros por pagina 
        /// </summary>
        const int maxRegistrosPorPagina = 100; // Performance

        /// <summary>
        /// Numero da pagina
        /// </summary>
        public int numeroPagina { get; set; } = 1;

        private int _numeroRegistrosPorPagina = 0;
        /// <summary>
        /// Numero de registros por pagina
        /// </summary>
        public int numeroRegistrosPorPagina
        {
            set { _numeroRegistrosPorPagina = value > maxRegistrosPorPagina || value == 0 ? maxRegistrosPorPagina : value; }
            get { return _numeroRegistrosPorPagina; }
        }

        public PaginationParameter()
        {
            numeroPagina = 1;
            _numeroRegistrosPorPagina = maxRegistrosPorPagina;
        }

        /// <summary>
        /// Cria um novo parametro de paginacao
        /// </summary>
        /// <param name="numeroPagina">Numero da pagina</param>
        /// <param name="numeroRegistrosPorPagina">Quantidade de registros por pagina</param>
        public PaginationParameter(int numeroPagina, int numeroRegistrosPorPagina)
        {
            this.numeroPagina = numeroPagina;
            this.numeroRegistrosPorPagina = numeroRegistrosPorPagina;
        }
    }
}
using System.ComponentModel.DataAnnotations;

namespace senai.inlock.webapi.Domains
{
    /// <summary>
    /// Classe que representa a entidade Jogo
    /// </summary>
    public class JogoDomain
    {
        /// <summary>
        /// Id do Jogo
        /// </summary>
        public int IdJogo { get; set; }

        /// <summary>
        /// Id do Estúdio ao qual o Jogo pertence
        /// </summary>
        [Required(ErrorMessage = "A referência ao Estúdio é obrigatória")]
        public int IdEstudio { get; set; }

        /// <summary>
        /// Nome do Jogo
        /// </summary>
        [Required(ErrorMessage = "O nome do Jogo é obrigatório")]
        [StringLength(100)]
        public string Nome { get; set; }

        /// <summary>
        /// Descrição do Jogo
        /// </summary>
        [Required(ErrorMessage = "A descrição do Jogo é obrigatória")]
        [StringLength(100)]
        public string Descricao { get; set; }

        /// <summary>
        /// Data de lançamento do Jogo
        /// </summary>
        [Required(ErrorMessage = "A data de lançamento do jogo é obrigatória")]
        [DataType(DataType.Date)]
        public DateTime DataLancamento { get; set; }

        /// <summary>
        /// Valor (preço) do Jogo
        /// </summary>
        [Required(ErrorMessage = "O valor do Jogo é obrigatório")]
        public decimal Valor { get; set; }

        /// <summary>
        /// Objeto referente ao Estúdio do Jogo
        /// </summary>
        public EstudioDomain Estudio { get; set; }
    }
}

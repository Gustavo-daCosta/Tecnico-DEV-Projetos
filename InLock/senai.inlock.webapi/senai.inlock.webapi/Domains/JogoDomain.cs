using System.ComponentModel.DataAnnotations;

namespace senai.inlock.webapi.Domains
{
    public class JogoDomain
    {
        public int IdJogo { get; set; }

        [Required(ErrorMessage = "A referência ao Estúdio é obrigatória")]
        public int IdEstudio { get; set; }

        [Required(ErrorMessage = "O nome do Jogo é obrigatório")]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A descrição do Jogo é obrigatória")]
        [StringLength(100)]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "A data de lançamento do jogo é obrigatória")]
        [DataType(DataType.Date)]
        public DateTime DataLancamento { get; set; }

        [Required(ErrorMessage = "O valor do Jogo é obrigatório")]
        public decimal Valor { get; set; }

        public EstudioDomain Estudio { get; set; }
    }
}

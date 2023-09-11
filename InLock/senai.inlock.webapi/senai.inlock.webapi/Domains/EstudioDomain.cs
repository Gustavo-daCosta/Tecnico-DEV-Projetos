using System.ComponentModel.DataAnnotations;

namespace senai.inlock.webapi.Domains
{
    /// <summary>
    /// Classe que representa a entidade Estudio
    /// </summary>
    public class EstudioDomain
    {
        /// <summary>
        /// Id do Estúdio
        /// </summary>
        public int IdEstudio { get; set; }

        /// <summary>
        /// Nome do Estúdio
        /// </summary>
        [Required(ErrorMessage = "O nome do estúdio é obrigatório")]
        [StringLength(100)]
        public string? Nome { get; set; }

        /// <summary>
        /// Lista de jogos que pertencem ao Estúdio
        /// </summary>
        public List<JogoDomain> jogosDoEstudio { get; set; }
    }
}

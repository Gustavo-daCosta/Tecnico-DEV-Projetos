using System.ComponentModel.DataAnnotations;

namespace senai.inlock.webapi.Domains
{
    public class EstudioDomain
    {
        public int IdEstudio { get; set; }

        [Required(ErrorMessage = "O nome do estúdio é obrigatório")]
        [StringLength(100)]
        public string? Nome { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace senai.inlock.webapi.Domains
{
    public class TipoUsuarioDomain
    {
        public int IdTipoUsuario { get; set; }

        [Required(ErrorMessage = "O título do Tipo de Usuário é obrigatório")]
        [StringLength(100)]
        public string Titulo { get; set; }
    }
}

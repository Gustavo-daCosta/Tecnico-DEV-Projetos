using System.ComponentModel.DataAnnotations;

namespace senai.inlock.webapi.Domains
{
    public class UsuarioDomain
    {
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "A referência ao Tipo de Usuário é obrigatória")]
        public int IdTipoUsuario { get; set; }

        [Required(ErrorMessage = "O e-mail do Usuário é obrigatório")]
        [StringLength(100)]
        public string Usuario { get; set; }

        [Required(ErrorMessage = "A senha do Usuário é obrigatória")]
        [StringLength(100)]
        public string Senha { get; set; }
    }
}

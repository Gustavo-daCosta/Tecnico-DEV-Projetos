using System.ComponentModel.DataAnnotations;

namespace senai.inlock.webapi.Domains
{
    /// <summary>
    /// Classe que representa a entidade Usuário
    /// </summary>
    public class UsuarioDomain
    {
        /// <summary>
        /// Id do Usuário
        /// </summary>
        public int IdUsuario { get; set; }

        /// <summary>
        /// Id referente ao Tipo de Usuário
        /// </summary>
        [Required(ErrorMessage = "A referência ao Tipo de Usuário é obrigatória")]
        public int IdTipoUsuario { get; set; }

        /// <summary>
        /// Email do Usuário
        /// </summary>
        [Required(ErrorMessage = "O e-mail do Usuário é obrigatório")]
        [StringLength(100)]
        public string Email { get; set; }

        /// <summary>
        /// Senha do Usuário
        /// </summary>
        [Required(ErrorMessage = "A senha do Usuário é obrigatória")]
        [StringLength(100)]
        public string Senha { get; set; }

        /// <summary>
        /// Objeto referente ao Tipo de Usuário
        /// </summary>
        public TipoUsuarioDomain TipoUsuario { get; set; }
    }
}

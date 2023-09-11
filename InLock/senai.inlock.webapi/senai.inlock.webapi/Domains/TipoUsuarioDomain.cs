using System.ComponentModel.DataAnnotations;

namespace senai.inlock.webapi.Domains
{
    /// <summary>
    /// Classe que representa a entidade Tipo de Usuário
    /// </summary>
    public class TipoUsuarioDomain
    {
        /// <summary>
        /// Id do Tipo de Usuário
        /// </summary>
        public int IdTipoUsuario { get; set; }

        /// <summary>
        /// Título referente ao Tipo de Usuário
        /// </summary>
        [Required(ErrorMessage = "O título do Tipo de Usuário é obrigatório")]
        [StringLength(100)]
        public string Titulo { get; set; }
    }
}

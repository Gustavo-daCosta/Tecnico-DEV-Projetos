using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto_Gamer_ASP.NET_MVC.Models
{
    public class Jogador
    {
        [Key]
        public int IdJogador { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }
        
        [ForeignKey("Equipes")]
        public int IdEquipe { get; set; }
        public Equipe? Equipe { get; set; }
    }
}
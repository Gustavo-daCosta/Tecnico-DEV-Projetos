using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_de_Produtos
{
    public class Mestre
    {
        public static Usuario Usuario { get; set; } = new Usuario();
        public Produto Produto { get; set; } = new Produto();
        public Marca Marca { get; set; } = new Marca();
    }
}
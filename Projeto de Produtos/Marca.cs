using Projeto_de_Produtos;

namespace Projeto_de_Produtos
{
    public class Marca
    {
        private int Codigo { get; set; }
        private string? NomeMarca { get; set; }
        private DateTime DataCadastro { get; set; }
        public List<Marca> ListaDeMarcas { get; private set; } = new List<Marca>();

        public string Cadastrar(Marca marca) {
            Codigo = new Random().Next(1, 101);
            NomeMarca = "";
            DataCadastro = DateTime.UtcNow;

            if (ListaDeMarcas.Contains(marca)) {
                return "Marca já cadastrada!";
            } else {
                ListaDeMarcas.Add(marca);
                return "Marca cadastrada com sucesso!";
            }
        }
    }
}
namespace Projeto_de_Produtos
{
    public class Produto
    {
        private int Codigo { get; set; }
        private string? NomeProduto { get; set; }
        private float Preco { get; set; }
        private DateTime DataCadastro { get; set; }
        private Marca marca { get; set; } = new Marca();
        private Usuario CadastradoPor { get; set; } = new Usuario();
        private List<Produto> ListaDeProdutos { get; set; } = new List<Produto>();

        public bool Cadastrar(Produto produto) {
            if (ListaDeProdutos.Contains(produto)) {
                return false;
            } else {
                ListaDeProdutos.Add(produto);
                return true;
            }
        }

        public bool Deletar(Produto produto) {
            if (ListaDeProdutos.Contains(produto)) {
                ListaDeProdutos.Remove(produto);
                return true;
            } else {
                return false;
            }
        }

        public bool Atualizar() { return false; }

        public List<Produto> Listar() => ListaDeProdutos;
    }
}
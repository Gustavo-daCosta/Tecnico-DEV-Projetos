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

        public string Cadastrar(Produto produto) {
            if (ListaDeProdutos.Contains(produto)) {
                return "Produto já cadastrado!";
            } else {
                ListaDeProdutos.Add(produto);
                return "Produto cadastrado com sucesso!";
            }
        }

        public string Deletar(Produto produto) {
            if (ListaDeProdutos.Contains(produto)) {
                ListaDeProdutos.Remove(produto);
                return "Produto deletado com sucesso!";
            } else {
                return "Produto não encontrado! Não foi possível deletar.";
            }
        }

        public List<Produto> Listar() => ListaDeProdutos;
    }
}
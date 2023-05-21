namespace Projeto_de_Produtos
{
    public class Produto
    {
        private int Codigo { get; set; }
        private string? Nome { get; set; }
        private float Preco { get; set; }
        private DateTime DataCadastro { get; set; } = DateTime.Now;
        private Marca _Marca { get; set; } = new Marca();
        private Usuario CadastradoPor { get; set; } = new Usuario();
        private List<Produto> ListaDeProdutos { get; set; } = new List<Produto>();

        public void Cadastrar(Produto produto, Usuario usuario) {
            produto.Codigo = GerarCodigo(produto);

            cadastroProduto:
            Funcionalidades.Titulo(" === Cadastrar produto ===");

            Marca marca = new Marca();
            int quantOpcoes = marca.Listar(listarComOpcoes: true);
            if (quantOpcoes == 0) {
                Funcionalidades.Mensagem($"Nenhuma marca foi registrada!\nAntes de registrar um produto, registre uma marca.");
                return;
            }
            Console.Write($"Digite a opção desejada: ");
            int opcao = int.Parse(Console.ReadLine()!);

            if (opcao < 1 || opcao > quantOpcoes) {
                Funcionalidades.Mensagem($"Opção inválida digitada! Tente novamente.");
                goto cadastroProduto;
            }
            produto._Marca = marca.ListaDeMarcas[opcao - 1];

            Console.Write($"Digite o nome do produto: ");
            string nome = Console.ReadLine()!;

            if (produto.ListaDeProdutos.Exists(x => x.Nome!.ToLower() == nome.ToLower())) {
                Funcionalidades.Mensagem($"O produto \"{nome}\" já foi cadastrado para esta marca!");
                goto cadastroProduto;
            }
            produto.Nome = nome;

            Console.Write($"Digite o preço do produto: R$");
            produto.Preco = float.Parse(Console.ReadLine()!);

            // Produto produto = new Produto(nome, preco, marca, usuario);

            produto.ListaDeProdutos.Add(produto);
            Funcionalidades.Mensagem($"O produto foi cadastrado com sucesso!", ConsoleColor.Green);
        }

        public void Deletar(Produto produto) {
            menu:
            Funcionalidades.Titulo($"=== DELETAR PRODUTO ===");
            produto.Listar(produto, listarComOpcoes: true);

            Console.Write($"Digite a opção desejada: ");
            int opcao = int.Parse(Console.ReadLine()!);
            
            if (opcao < 1 || opcao > produto.ListaDeProdutos.Count) {
                Funcionalidades.Mensagem($"Opção inválida! Tente novamente...");
                goto menu;
            } else if (opcao > 0) {
                produto.ListaDeProdutos.RemoveAt(opcao - 1);
                Funcionalidades.Mensagem($"Marca deletada com sucesso!", ConsoleColor.Green);
            }
        }

        public bool Atualizar() { return false; }

        public void Listar(Produto _produto, bool listarComOpcoes = false) {
            int i = 0;
            foreach (Produto produto in _produto.ListaDeProdutos) {
                i++;
                Console.Write(listarComOpcoes ? $"\n[{i}] - " : $"\n{i}º Produto ");
                Console.WriteLine(String.Format(
                    "Código: {0, 0} - Nome: {1, 0}      Preço: {2:c, 10}",
                    produto.Codigo, produto.Nome, produto.Preco
                ));
                Console.WriteLine(String.Format(
                    "Marca: {0, 0}      Cadastrado por: {1, 10}",
                    produto._Marca, produto.CadastradoPor
                ));
            }
            Console.WriteLine(listarComOpcoes ? $"\n[0] - Voltar ao menu" : "");
        }

        private int GerarCodigo(Produto produto) {
            Random random = new Random();
            codigo:
            int codigo = random.Next(1000, 9999);

            if (produto.ListaDeProdutos.Exists(x => x.Codigo == codigo)) {
                goto codigo;
            }
            return codigo;
        }
    }
}
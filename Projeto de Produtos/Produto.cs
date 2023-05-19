namespace Projeto_de_Produtos
{
    public class Produto
    {
        private int Codigo { get; set; }
        private string? NomeProduto { get; set; }
        private float Preco { get; set; }
        private DateTime DataCadastro { get; set; } = DateTime.Now;
        private Marca _Marca { get; set; } = new Marca();
        private Usuario CadastradoPor { get; set; } = new Usuario();
        private List<Produto> ListaDeProdutos { get; set; } = new List<Produto>();

        public Produto() {}

        public Produto(string nomeProduto, float preco, Marca marca, Usuario usuario) {
            Codigo = GerarCodigo();
            NomeProduto = nomeProduto;
            Preco = preco;
            _Marca = marca;
            CadastradoPor = usuario;
        }

        public void Cadastrar(Usuario usuario) {
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

            Console.Write($"Digite o nome do produto: ");
            string nome = Console.ReadLine()!;

            if (ListaDeProdutos.Exists(x => x.NomeProduto!.ToLower() == nome.ToLower())) {
                Funcionalidades.Mensagem($"O produto \"{nome}\" já foi cadastrado para esta marca!");
                goto cadastroProduto;
            }

            Console.Write($"Digite o preço do produto: R$");
            float preco = float.Parse(Console.ReadLine()!);

            Produto produto = new Produto(nome, preco, marca, usuario);

            ListaDeProdutos.Add(produto);
            Funcionalidades.Mensagem($"O produto foi cadastrado com sucesso!", ConsoleColor.Green);
        }

        public void Deletar() {
            Funcionalidades.Titulo($"=== DELETAR MARCA ===");
            Listar(listarComOpcoes: true);

            Console.Write($"Digite a opção desejada: ");
            int opcao = int.Parse(Console.ReadLine()!);
            
            if (opcao < 1 || opcao > produto.ListaDeMarcas.Count) {
                Funcionalidades.Mensagem($"Opção inválida! Tente novamente...");
                goto menu;
            } else if (opcao > 0) {
                marca.ListaDeMarcas.Remove(marca);
                Funcionalidades.Mensagem($"Marca deletada com sucesso!", ConsoleColor.Green);
            }

            ListaDeProdutos.Remove(produto);
        }

        public bool Atualizar() { return false; }

        public int Listar(bool listarComOpcoes = false) {
            if (!ListaDeProdutos.Any()) {
                return 0;
            }
            int i = 0;
            foreach (Produto produto in ListaDeProdutos) {
                i++;
                if (listarComOpcoes) {
                    Console.Write(listarComOpcoes ? $"[{i}] - " : $"{i}º Produto ");
                }
                Console.WriteLine(produto.NomeProduto);
            }
            return ListaDeProdutos.Count();
        }

        private int GerarCodigo() {
            Random random = new Random();
            codigo:
            int codigo = random.Next(1000, 9999);

            if (ListaDeProdutos.Exists(x => x.Codigo == codigo)) {
                goto codigo;
            }
            return codigo;
        }
    }
}
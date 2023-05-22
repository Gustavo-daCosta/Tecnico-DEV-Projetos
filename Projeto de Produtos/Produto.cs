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

        public void Cadastrar() {
            Produto produto = new Produto();
            produto.Codigo = GerarCodigo();

            cadastroProduto:
            Funcionalidades.Titulo(" === Cadastrar produto ===");

            if (Mestre.Marca.ListaDeMarcas.Count == 0) {
                Funcionalidades.Mensagem($"Nenhuma marca foi registrada!\nAntes de registrar um produto, registre uma marca.");
                return;
            }
            Mestre.Marca.Listar(listarComOpcoes: true);
            Console.Write($"Digite a opção desejada: ");
            int opcao = int.Parse(Console.ReadLine()!);

            if (opcao < 0 || opcao > Mestre.Marca.ListaDeMarcas.Count) {
                Funcionalidades.Mensagem($"Opção inválida digitada! Tente novamente.");
                goto cadastroProduto;
            } else if (opcao == 0) { return; }
            produto._Marca = Mestre.Marca.ListaDeMarcas[opcao - 1];

            Console.Write($"Digite o nome do produto: ");
            string nome = Console.ReadLine()!;

            if (Mestre.Produto.ListaDeProdutos.Exists(x => x.Nome!.ToLower() == nome.ToLower())) {
                Funcionalidades.Mensagem($"O produto \"{nome}\" já foi cadastrado para esta marca!");
                goto cadastroProduto;
            }
            produto.Nome = nome;

            Console.Write($"Digite o preço do produto: R$");
            produto.Preco = float.Parse(Console.ReadLine()!);

            Mestre.Produto.ListaDeProdutos.Add(produto);
            Funcionalidades.Mensagem($"O produto foi cadastrado com sucesso!", ConsoleColor.Green);
        }

        public void Deletar() {
            if (Mestre.Produto.ListaDeProdutos.Any()) {
                menu:
                Funcionalidades.Titulo($"=== DELETAR PRODUTO ===");
                Mestre.Produto.Listar(listarComOpcoes: true);

                Console.Write($"Digite a opção desejada: ");
                int opcao = int.Parse(Console.ReadLine()!);

                if (opcao == 0) {
                    return;
                } else if (opcao > 0 && opcao <= Mestre.Produto.ListaDeProdutos.Count) {
                    Mestre.Produto.ListaDeProdutos.RemoveAt(opcao - 1);
                    Funcionalidades.Mensagem($"Marca deletada com sucesso!", ConsoleColor.Green);
                } else {
                    Funcionalidades.Mensagem($"Opção inválida! Tente novamente...");
                    goto menu;
                }
            } else {
                Funcionalidades.Mensagem($"Não é possível deletar nenhum produto pois nenhum produto foi registrado!", ConsoleColor.Blue);
            }
        }

        public bool Atualizar() { return false; }

        public void Listar(bool listarComOpcoes = false) {
            Console.WriteLine($"ENTROU NO LISTAR || EXISTEM PRODUTOS? {Mestre.Produto.ListaDeProdutos.Any()}");
            Console.ReadLine();
            if (Mestre.Produto.ListaDeProdutos.Any()) {
                Console.WriteLine(listarComOpcoes ? $"Selecione a marca do produto:\n" : "");
                int i = 0;
                foreach (Produto produto in Mestre.Produto.ListaDeProdutos) {
                    i++;
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(listarComOpcoes ? $"\n[{i}] - " : $"\n{i}º Produto ");
                    Console.ResetColor();
                    Console.WriteLine(String.Format(
                        "Código: {0, 0} - Nome: {1, 0}      Preço: R${2, 10}",
                        produto.Codigo, produto.Nome, produto.Preco
                    ));
                    Console.WriteLine(String.Format(
                        "Marca: {0, 0}      Cadastrado por: {1, 10}",
                        produto._Marca.Nome, produto.CadastradoPor.Nome
                    ));
                }
                Console.WriteLine(listarComOpcoes ? $"\n[0] - Voltar ao menu\n" : "");
            } else {
                Funcionalidades.Mensagem($"Nenhum produto foi registrado!", ConsoleColor.Blue);
            }
        }

        private int GerarCodigo() {
            Random random = new Random();
            codigo:
            int codigo = random.Next(1000, 9999);

            if (Mestre.Produto.ListaDeProdutos.Exists(x => x.Codigo == codigo)) {
                goto codigo;
            }
            return codigo;
        }
    }
}
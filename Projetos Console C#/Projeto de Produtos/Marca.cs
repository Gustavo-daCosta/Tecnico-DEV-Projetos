using Projeto_de_Produtos;

namespace Projeto_de_Produtos
{
    public class Marca
    {
        private int Codigo { get; set; }
        public string? Nome { get; set; }
        private DateTime DataCadastro { get; set; } = DateTime.Now;
        public List<Marca> ListaDeMarcas { get; private set; } = new List<Marca>();

        public void Cadastrar() {
            Marca marca = new Marca();
            marca.Codigo = GerarCodigo();

            menu:
            Funcionalidades.Titulo(" === Cadastrar marca ===");

            Console.Write($"Digite o nome da marca: ");
            marca.Nome = Console.ReadLine()!;

            if (Mestre.Marca.ListaDeMarcas.Exists(x => x.Nome!.ToLower() == marca.Nome.ToLower())) {
                Funcionalidades.Mensagem($"Uma marca com o nome {marca} já foi cadastrada anteriormente!");
                goto menu;
            } else {
                Mestre.Marca.ListaDeMarcas.Add(marca);
                Funcionalidades.Mensagem($"A marca foi cadastrada com sucesso!", ConsoleColor.Green);
            }
        }

        public void Atualizar(Marca marca) {}

        public void Deletar() {
            if (Mestre.Marca.ListaDeMarcas.Any()) {
                menu:
                Funcionalidades.Titulo($" === DELETAR MARCA ===");
                Mestre.Marca.Listar(listarComOpcoes: true);
                Console.Write($"Digite a opção desejada: ");
                int opcao = int.Parse(Console.ReadLine()!);

                if (opcao == 0) {
                    return;
                } else if (opcao > 0 && opcao < Mestre.Marca.ListaDeMarcas.Count) {
                    Mestre.Marca.ListaDeMarcas.RemoveAt(opcao - 1);
                    Funcionalidades.Mensagem($"Marca deletada com sucesso!", ConsoleColor.Green);
                } else {
                    Funcionalidades.Mensagem($"Opção inválida! Tente novamente...");
                    goto menu;
                }
            } else {
                Funcionalidades.Mensagem($"Não é possível deletar nenhuma marca pois nenhuma marca foi registrada!");
            }
        }

        public void Listar(bool listarComOpcoes = false) {
            Console.WriteLine($"");
            if (Mestre.Marca.ListaDeMarcas.Any()) {
                Console.WriteLine(listarComOpcoes ? $"Selecione a marca do produto:\n" : "");
                int i = 0;
                foreach (Marca _marca in Mestre.Marca.ListaDeMarcas) {
                    i++;
                    if (listarComOpcoes) {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(listarComOpcoes ? $"[{i}] - " : "");
                        Console.ResetColor();
                    }
                    Console.WriteLine($" Código: {_marca.Codigo} - Nome: {_marca.Nome}");
                }
                Console.WriteLine(listarComOpcoes ? $"\n[0] - Voltar ao menu\n" : "");
            } else {
                Funcionalidades.Mensagem($"Nenhuma marca foi registrada!", ConsoleColor.Blue);
            }
        }

        public bool MarcaExiste(Marca marca) {
            foreach (Marca _marca in Mestre.Marca.ListaDeMarcas) {
                if (marca.Nome!.ToLower() == _marca.Nome!.ToLower()) {
                    return true;
                }
            }
            return false;
        }

        private int GerarCodigo() {
            Random random = new Random();
            codigo:
            int codigo = random.Next(1000, 9999);

            if (Mestre.Marca.ListaDeMarcas.Exists(x => x.Codigo == codigo)) {
                goto codigo;
            }
            return codigo;
        }
    }
}
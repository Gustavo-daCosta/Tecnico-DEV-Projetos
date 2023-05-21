using Projeto_de_Produtos;

namespace Projeto_de_Produtos
{
    public class Marca
    {
        private int Codigo { get; set; }
        private string? Nome { get; set; }
        private DateTime DataCadastro { get; set; } = DateTime.Now;
        public List<Marca> ListaDeMarcas { get; private set; } = new List<Marca>();

        public void Cadastrar(Marca marca) {
            marca.Codigo = GerarCodigo(marca);

            menu:
            Funcionalidades.Titulo(" === Cadastrar marca ===");

            Console.Write($"Digite o nome da marca: ");
            marca.Nome = Console.ReadLine()!;

            // Marca marca = new Marca(nome);

            if (marca.ListaDeMarcas.Exists(x => x.Nome!.ToLower() == marca.Nome.ToLower())) {
                Funcionalidades.Mensagem($"Uma marca com o nome {marca} já foi cadastrada anteriormente!");
                goto menu;
            } else {
                marca.ListaDeMarcas.Add(marca);
                Funcionalidades.Mensagem($"A marca foi cadastrada com sucesso!", ConsoleColor.Green);
            }
        }

        public void Atualizar(Marca marca) {}

        public void Deletar(Marca marca) {
            menu:
            Funcionalidades.Titulo($" === DELETAR MARCA ===");
            Listar(marca, listarComOpcoes: true);
            Console.Write($"Digite a opção desejada: ");
            int opcao = int.Parse(Console.ReadLine()!);
            
            if (opcao < 1 || opcao > marca.ListaDeMarcas.Count) {
                Funcionalidades.Mensagem($"Opção inválida! Tente novamente...");
                goto menu;
            } else if (opcao > 0) {
                marca.ListaDeMarcas.RemoveAt(opcao - 1);
                Funcionalidades.Mensagem($"Marca deletada com sucesso!", ConsoleColor.Green);
            }
        }

        public void Listar(Marca marca, bool listarComOpcoes = false) {
            int i = 0;
            foreach (Marca _marca in marca.ListaDeMarcas) {
                i++;
                if (listarComOpcoes) {
                    Console.Write(listarComOpcoes ? $"[{i}] - " : "");
                }
                Console.WriteLine($" Código: {_marca.Codigo} - Nome: {_marca.Nome}");
            }
            Console.WriteLine(listarComOpcoes ? $"\n[0] - Voltar ao menu" : "");
        }

        public bool MarcaExiste(Marca marca) {
            foreach (Marca _marca in marca.ListaDeMarcas) {
                if (marca.Nome!.ToLower() == _marca.Nome!.ToLower()) {
                    return true;
                }
            }
            return false;
        }

        private int GerarCodigo(Marca marca) {
            Random random = new Random();
            codigo:
            int codigo = random.Next(1000, 9999);

            if (marca.ListaDeMarcas.Exists(x => x.Codigo == codigo)) {
                goto codigo;
            }
            return codigo;
        }
    }
}
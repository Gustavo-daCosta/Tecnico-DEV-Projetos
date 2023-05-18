using Projeto_de_Produtos;

namespace Projeto_de_Produtos
{
    public class Marca
    {
        private int Codigo { get; set; }
        private string? NomeMarca { get; set; }
        private DateTime DataCadastro { get; set; } = DateTime.Now;
        public List<Marca> ListaDeMarcas { get; private set; } = new List<Marca>();

        public Marca() {}

        public Marca(string nomeMarca) {
            Codigo = GerarCodigo();
            NomeMarca = nomeMarca;
        }

        public void Cadastrar() {
            Funcionalidades.Titulo(" === Cadastrar marca ===");

            nomeMarca:
            Console.Write($"Digite o nome da marca: ");
            string nome = Console.ReadLine()!;

            Marca marca = new Marca(nome);

            if (ListaDeMarcas.Exists(x => x.NomeMarca!.ToLower() == nome.ToLower())) {
                Funcionalidades.Mensagem($"Uma marca com o nome {marca} já foi cadastrada anteriormente!");
                goto nomeMarca;
            } else {
                ListaDeMarcas.Add(marca);
                Funcionalidades.Mensagem($"A marca foi cadastrada com sucesso!", ConsoleColor.Green);
            }
        }

        public void Atualizar(Marca marca) {}

        public void Deletar(Marca marca) {
            menu:
            Funcionalidades.Titulo($" === DELETAR MARCA ===");
            Listar(listarComOpcoes: true);
            Console.Write($"Digite a opção desejada: ");
            int opcao = int.Parse(Console.ReadLine()!);
            
            if (opcao < 1 || opcao > marca.ListaDeMarcas.Count) {
                Funcionalidades.Mensagem($"Opção inválida! Tente novamente...");
                goto menu;
            } else if (opcao > 0) {
                marca.ListaDeMarcas.Remove(marca);
                Funcionalidades.Mensagem($"Marca deletada com sucesso!", ConsoleColor.Green);
            }
        }

        public void Listar(bool listarComOpcoes = false) {
            int i = 0;
            foreach (Marca marca in ListaDeMarcas) {
                i++;
                if (listarComOpcoes) {
                    Console.Write(listarComOpcoes ? $"[{i}] - " : $"{i}º Marca ");
                }
                Console.WriteLine(marca.NomeMarca);
            }
        }

        public bool MarcaExiste(string nomeMarca) {
            foreach (Marca marca in ListaDeMarcas) {
                if (marca.NomeMarca!.ToLower() == nomeMarca.ToLower()) {
                    return true;
                }
            }
            return false;
        }

        private int GerarCodigo() {
            Random random = new Random();
            codigo:
            int codigo = random.Next(1000, 9999);

            if (ListaDeMarcas.Exists(x => x.Codigo == codigo)) {
                goto codigo;
            }
            return codigo;
        }
    }
}
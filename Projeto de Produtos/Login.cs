namespace Projeto_de_Produtos
{
    public class Login
    {
        public bool Logado { get; set; }

        public Login() {
            Usuario usuario = new Usuario();

            bool desejaContinuar = true;
            while (desejaContinuar) {
                if (Logado) {
                    int opcao = GerarMenu();
                    switch (opcao) {
                        case 1:
                            break;
                    }
                } else {
                    int opcao = MenuCadastro();
                    
                    switch (opcao) {
                        case 1:
                            usuario.Cadastrar();
                            break;
                        case 2:
                            Logar(usuario);
                            Logado = true;
                            break;
                        default:
                            Funcionalidades.Mensagem($"Saindo do programa...", ConsoleColor.Blue);
                            Environment.Exit(1);
                            break;
                    }
                }
            }
        }

        public int MenuCadastro() {
            menu:
            Funcionalidades.Titulo(" === LOG IN === ");
            Console.WriteLine(@$"Selecione uma opção:

            [1] - Cadastrar nova conta
            [2] - Logar em conta pré-existente

            [0] - Sair
            ");
            Console.Write($"Digite a opção desejada: ");
            int opcao = int.Parse(Console.ReadLine()!);

            if (opcao < 0 || opcao > 2) {
                Funcionalidades.Mensagem($"Opção inválida!");
                goto menu;
            }
            return opcao;
        }

        public void Logar(Usuario usuario) {
            logar:
            Funcionalidades.Titulo(" === Logar usuário ===");

            Console.Write($"Digite o email do usuário: ");
            string email = Console.ReadLine()!;

            Console.Write($"Digite a senha do usuário: ");
            string senha = Console.ReadLine()!;

            // Se não funcionar, passar o usuário para o UsuarioExiste e utilizar a lista de usuarios do objeto usuario (usuario.ListaDeUsuarios)
            if (!usuario.UsuarioExiste(usuario, email, senha)) { // Se usuário não existe
                Funcionalidades.Mensagem($"O email ou a senha estão incorretos! Tente novamente");
                goto logar;
            }
        }

        public int GerarMenu() {
            menu:
            Funcionalidades.Titulo($" === MENU DE OPÇÕES ===");
            Console.WriteLine(@$"
            [1] Cadastrar produto
            [2] Listar produtos
            [3] Remover produto
            ---------------------
            [4] Cadastrar marca
            [5] Listar marcas
            [6] Remover marca
            ---------------------
            [0] Sair da conta");
            Console.Write($"Digite a opção desejada: ");
            int opcao = int.Parse(Console.ReadLine()!);

            if (opcao < 0 || opcao > 6) {
                Funcionalidades.Mensagem($"Opção inválida digitada! Tente novamente.");
                goto menu;
            }
            return opcao;
        }
    }
}
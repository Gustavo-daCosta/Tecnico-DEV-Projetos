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
                            Mestre.Produto.Cadastrar();
                            break;
                        case 2:
                            // Console.Write($"Listar");
                            // Console.ReadLine();
                            Mestre.Produto.Listar();
                            break;
                        case 3:
                            Mestre.Produto.Deletar();
                            break;
                        case 4:
                            Mestre.Marca.Cadastrar();
                            break;
                        case 5:
                            Mestre.Marca.Listar();
                            break;
                        case 6:
                            Mestre.Marca.Deletar();
                            break;
                        case 7:
                            Mestre.Usuario.Deletar(usuario);
                            break;
                        case 8:
                            Funcionalidades.Mensagem($"Saindo da sua conta...", ConsoleColor.Blue);
                            Logado = false;
                            break;
                        default:
                            Funcionalidades.Mensagem($"Saindo do programa...", ConsoleColor.Blue);
                            Environment.Exit(1);
                            break;
                    }
                } else {
                    menuCadastro:
                    int opcao = MenuCadastro();
                    Usuario usuarioTeste = new Usuario("Gustavo", "gustavo@gmail", "guti10");
                    
                    switch (opcao) {
                        case 1:
                            usuario = Mestre.Usuario.Cadastrar();
                            break;
                        case 2:
                            Mestre.Usuario.ListaDeUsuarios.Add(usuarioTeste);
                            bool conseguiuLogar = Logar(usuarioTeste);
                            // bool conseguiuLogar = Logar(Mestre.Usuario);
                            if (conseguiuLogar) {
                                Logado = true;
                                break;
                            } else {
                                goto menuCadastro;
                            }
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

        public bool Logar(Usuario usuario) {
            logar:
            Funcionalidades.Titulo(" === Logar usuário ===");

            Console.Write($"Digite o email do usuário: ");
            string email = Console.ReadLine()!;

            Console.Write($"Digite a senha do usuário: ");
            string senha = Console.ReadLine()!;

            // Se não funcionar, passar o usuário para o UsuarioExiste e utilizar a lista de usuarios do objeto usuario (usuario.ListaDeUsuarios)
            if (!usuario.UsuarioExiste(email, senha)) { // Se usuário não existe
                menu:
                Funcionalidades.Mensagem($"O email ou a senha estão incorretos! Tente novamente");
                Console.WriteLine(@$"Você deseja voltar ao menu ou tentar novamente?
    [1] - Tentar novamente
    [2] - Voltar ao menu
                ");
                int opcao = int.Parse(Console.ReadLine()!);

                if (opcao != 1 && opcao != 2) {
                    Funcionalidades.Mensagem($"Valor inválido!");
                    goto menu;
                }
                if (opcao == 1) {
                  goto logar;
                } else {
                    return false;
                }
            }
            Funcionalidades.Mensagem($"Login concluído!", ConsoleColor.Green);
            return true;
        }

        public int GerarMenu() {
            menu:
            Funcionalidades.Titulo($" === MENU DE OPÇÕES ===");
            Console.WriteLine(@$"
  -------- PRODUTO ---------
    [1] Cadastrar produto
    [2] Listar produtos
    [3] Remover produto
  --------- MARCA ----------
    [4] Cadastrar marca
    [5] Listar marcas
    [6] Remover marca
  --------- CONTA ----------
    [7] Deletar conta
    [8] Sair da conta
  --------------------------
    [0] Encerrar programa
            ");
            Console.Write($"Digite a opção desejada: ");
            int opcao = int.Parse(Console.ReadLine()!);

            if (opcao < 0 || opcao > 8) {
                Funcionalidades.Mensagem($"Opção inválida digitada! Tente novamente.");
                goto menu;
            }
            return opcao;
        }
    }
}
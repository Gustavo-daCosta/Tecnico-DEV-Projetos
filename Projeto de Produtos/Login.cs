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

                    Produto produto = new Produto();
                    Marca marca = new Marca();

                    switch (opcao) {
                        case 1:
                            produto.Cadastrar(produto, usuario);
                            break;
                        case 2:
                            produto.Listar();
                            break;
                        case 3:
                            produto.Deletar(produto);
                            break;
                        case 4:
                            marca.Cadastrar(marca);
                            break;
                        case 5:
                            marca.Listar();
                            break;
                        case 6:
                            marca.Deletar(marca);
                            break;
                        case 7:
                            usuario.Deletar(usuario);
                            break;
                        case 8:
                            Funcionalidades.Mensagem($"Saindo da sua conta...", ConsoleColor.Blue);
                            Logado = false;
                            break;
                        default:
                            Funcionalidades.Mensagem($"Valor inválido! Tente novamente.");
                            break;
                    }
                } else {
                    menuCadastro:
                    int opcao = MenuCadastro();
                    
                    switch (opcao) {
                        case 1:
                            usuario.Cadastrar();
                            break;
                        case 2:
                            bool conseguiuLogar = Logar(usuario);
                            if (conseguiuLogar) {
                                Logado = true;
                                break;
                            } else {
                                goto menuCadastro;
                            }
                        default:
                            Funcionalidades.Mensagem($"Saindo do programa...", ConsoleColor.Blue);
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
            Funcionalidades.Mensagem($"Login concluído!");
            return true;
        }

        public int GerarMenu() {
            menu:
            Funcionalidades.Titulo($" === MENU DE OPÇÕES ===");
            Console.WriteLine(@$"
    -------- PRODUTO ----------
    [1] Cadastrar produto
    [2] Listar produtos
    [3] Remover produto
    --------- MARCA -----------
    [4] Cadastrar marca
    [5] Listar marcas
    [6] Remover marca
    --------- CONTA -----------
    [7] Deletar conta
    [8] Sair da conta
    ---------------------------
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
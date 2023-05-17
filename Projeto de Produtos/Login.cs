namespace Projeto_de_Produtos
{
    public class Login
    {
        public bool Logado { get; set; }

        public Login() {
            bool desejaContinuar = true;
            while (desejaContinuar) {
                if (Logado) {
                    int opcao = GerarMenu();
                    switch (opcao) {
                        
                    }
                } else {
                    Logar();
                }
            }
        }

        public void MenuCadastro() {
            menu:
            Console.Clear();
            Console.WriteLine(" === LOG IN === ");
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
        }

        public void Logar() {
            Console.WriteLine(" === Logar usuário ===");
            Usuario usuario = new Usuario();

            if (usuario.ListaDeUsuarios.Contains(usuario)) {
                
            }
        }

        

        public int GerarMenu() {
            Console.WriteLine(@$" === MENU DE OPÇÕES ===
            
            [1] Cadastrar produto
            [2] Listar produtos
            [3] Remover produto
            ---------------------
            [4] Cadastrar marca
            [5] Listar marcas
            [6] Remover marca
            ---------------------
            [0] Sair da conta");
            return 1;
        }
    }
}
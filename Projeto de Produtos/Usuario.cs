namespace Projeto_de_Produtos
{
    public class Usuario
    {
        private int Codigo { get; set; }
        private string? Nome { get; set; }
        private string? Email { get; set; }
        private string? Senha { get; set; }
        private DateTime DataCadastro { get; set; } = DateTime.Now;
        public List<Usuario> ListaDeUsuarios {get; private set;} = new List<Usuario>();

        public Usuario() {}

        private Usuario(string nome, string email, string senha) {
            Codigo = GerarCodigo();
            Nome = nome;
            Email = email;
            Senha = senha;
        }

        public void Cadastrar() {
            Console.WriteLine(" === Cadastrar usuário ===");

            Console.Write($"Digite o nome do usuário: ");
            string nome = Console.ReadLine()!;

            email:
            Console.Write($"Digite o email do usuário: ");
            string email = Console.ReadLine()!;

            senha:
            Console.WriteLine($"A senha deve conter no mínimo 4 dígitos e pelo menos uma letra e um número.");
            Console.Write($"Digite a senha do usuário: ");
            string senha = Console.ReadLine()!;

            Console.Write($"Digite a senha do usuário novamente: ");
            string senha2 = Console.ReadLine()!;

            bool senhaInvalida = senha.Length < 4 && !(senha.All(char.IsDigit) || senha.All(char.IsLetter));
            if (senhaInvalida || senha != senha2) {
                Funcionalidades.Mensagem(senhaInvalida ? "Senha inválida digitada!" : "As senhas digitadas não coincidem!");
                goto senha;
            }

            Usuario usuario = new Usuario(nome, email, senha);

            if (ListaDeUsuarios.Exists(x => x.Email == usuario.Email)) {
                Funcionalidades.Mensagem($"O email {usuario.Email} já foi cadastrado em outra conta!");
                goto email;
            } else {
                ListaDeUsuarios.Add(usuario);
                Funcionalidades.Mensagem($"O usuário foi cadastrado com sucesso!", ConsoleColor.Green);
            }
        }

        public void Atualizar(Usuario usuario) {}

        public void Deletar(Usuario usuario) {
            menu:
            Console.Clear();
            Console.WriteLine($" === DELETAR USUÁRIO ===");
            Console.WriteLine($"Devemos fazer uma verificação antes de deletar seu usuário.");
            Console.Write($"Digite sua senha: ");
            string senha = Console.ReadLine()!;

            if (senha == usuario.Senha) {
                ListaDeUsuarios.Remove(usuario);
                Funcionalidades.Mensagem($"Usuário deletado com sucesso! Sentiremos sua falta... 😢", ConsoleColor.Green);
            } else {
                Funcionalidades.Mensagem($"A senha digitada está incorreta.");
                goto menu;
            }
        }

        private int GerarCodigo() {
            Random random = new Random();
            codigo:
            int codigo = random.Next(1000, 9999);

            if (ListaDeUsuarios.Exists(x => x.Codigo == codigo)) {
                goto codigo;
            }
            return codigo;
        }
    }
}
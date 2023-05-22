namespace Projeto_de_Produtos
{
    public class Usuario
    {
        public int Codigo { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }
        public DateTime DataCadastro { get; set; } = DateTime.Now;
        public List<Usuario> ListaDeUsuarios { get; private set; } = new List<Usuario>();

        public Usuario() {}

        public Usuario(string nome, string email, string senha) {
            Codigo = GerarCodigo();
            Nome = nome;
            Email = email;
            Senha = senha;
        }

        public Usuario Cadastrar() {
            Funcionalidades.Titulo(" === Cadastrar usuário ===");

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
            if (senhaInvalida || senha != senha2)
            {
                Funcionalidades.Mensagem(senhaInvalida ? "Senha inválida digitada!" : "As senhas digitadas não coincidem!");
                goto senha;
            }

            Usuario usuario = new Usuario(nome, email, senha);

            if (usuario.ListaDeUsuarios.Exists(x => x.Email == usuario.Email)) {
                Funcionalidades.Mensagem($"O email {usuario.Email} já foi cadastrado em outra conta!");
                goto email;
            }
            else {
                Mestre.Usuario.ListaDeUsuarios.Add(usuario);
                Funcionalidades.Mensagem($"O usuário foi cadastrado com sucesso!", ConsoleColor.Green);
            }
            return usuario;
        }

        public void Atualizar(Usuario usuario) { }

        public void Deletar(Usuario usuario) {
            menu:
            Funcionalidades.Titulo($" === DELETAR USUÁRIO ===");
            Console.WriteLine($"Devemos fazer uma verificação antes de deletar seu usuário.");
            Console.Write($"Digite sua senha: ");
            string senha = Console.ReadLine()!;

            if (senha == usuario.Senha) {
                Mestre.Usuario.ListaDeUsuarios.Remove(usuario);
                Funcionalidades.Mensagem($"Usuário deletado com sucesso! Sentiremos sua falta... 😢", ConsoleColor.Green);
            }
            else {
                Funcionalidades.Mensagem($"A senha digitada está incorreta.");
                goto menu;
            }
        }

        public void Listar() {
            Funcionalidades.Titulo($" === Lista de Usuários ===");
            int i = 0;
            foreach (Usuario usuario in Mestre.Usuario.ListaDeUsuarios) {
                i++;
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"\n{i}º Usuário:");
                Console.ResetColor();
                Console.WriteLine($"Código: {usuario.Codigo} - Nome: {usuario.Nome}");
                Console.WriteLine($"Email: {usuario.Email}");
            }
        }

        public bool UsuarioExiste(string email, string senha) {
            foreach (Usuario usuarioListado in Mestre.Usuario.ListaDeUsuarios) {
                if (usuarioListado.Email == email && usuarioListado.Senha == senha) {
                    return true;
                }
            }
            return false;
        }

        private int GerarCodigo() {
            Random random = new Random();
            codigo:
            int codigo = random.Next(1000, 9999);

            if (Mestre.Usuario.ListaDeUsuarios.Exists(x => x.Codigo == codigo)) {
                goto codigo;
            }
            return codigo;
        }
    }
}
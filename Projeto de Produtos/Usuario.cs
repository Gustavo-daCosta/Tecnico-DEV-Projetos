namespace Projeto_de_Produtos
{
    public class Usuario : Produto
    {
        private int Codigo { get; set; }
        private string? Nome { get; set; }
        private string? Email { get; set; }
        private string? Senha { get; set; }
        private DateTime DataCadastro { get; set; }
        public List<Usuario> ListaDeUsuarios {get; private set;} = new List<Usuario>();

        public string Cadastrar(Usuario usuario) {
            if (ListaDeUsuarios.Contains(usuario)) {
                return "Usuário já cadastrado!";
            } else {
                ListaDeUsuarios.Add(usuario);
                return "Usuário cadastrado com sucesso!";
            }
        }

        public string Deletar(Usuario usuario) {
            if (ListaDeUsuarios.Contains(usuario)) {
                ListaDeUsuarios.Remove(usuario);
                return "Usuário deletado com sucesso!";
            } else {
                return "Usuário não encontrado! Não foi possível deletar.";
            }
        }
    }
}
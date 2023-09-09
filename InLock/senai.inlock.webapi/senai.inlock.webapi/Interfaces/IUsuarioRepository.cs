using senai.inlock.webapi.Domains;

namespace senai.inlock.webapi.Interfaces
{
    public interface IUsuarioRepository
    {
        public UsuarioDomain Login(string email, string senha);

        public List<UsuarioDomain> ListarTodos();

        public UsuarioDomain BuscarPorId(int id);

        public void Cadastrar(UsuarioDomain usuarioDomain);
    }
}

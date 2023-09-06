using senai.inlock.webapi.Domains;

namespace senai.inlock.webapi.Interfaces
{
    public interface ITipoUsuarioRepository
    {
        public List<TipoUsuarioDomain> ListarTodos();
    }
}

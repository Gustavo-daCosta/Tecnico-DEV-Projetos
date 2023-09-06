using senai.inlock.webapi.Domains;

namespace senai.inlock.webapi.Interfaces
{
    public interface IUsuarioRepository
    {
        public UsuarioDomain Login(string email, string senha);
    }
}

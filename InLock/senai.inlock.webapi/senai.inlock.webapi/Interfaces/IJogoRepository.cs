using senai.inlock.webapi.Domains;

namespace senai.inlock.webapi.Interfaces
{
    public interface IJogoRepository
    {
        public void Cadastrar(JogoDomain jogo);

        public void Deletar(int id);

        public List<JogoDomain> ListarTodos();
    }
}

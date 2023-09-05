using senai.inlock.webapi.Domains;

namespace senai.inlock.webapi.Interfaces
{
    public interface IEstudioRepository
    {
        public void Cadastrar(EstudioDomain estudio);

        public void Deletar(int id);

        public List<EstudioDomain> ListarTodos();
    }
}

using senai.inlock.webapi.Domains;

namespace senai.inlock.webapi.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório EstudioRepository
    /// Define os métodos que serão implementados pelo repositório
    /// </summary>
    public interface IEstudioRepository
    {
        /// <summary>
        /// Cadastrar um novo Estúdio
        /// </summary>
        /// <param name="estudio">Objeto do Estúdio a ser cadastrado</param>
        public void Cadastrar(EstudioDomain estudio);

        /// <summary>
        /// Deletar um Estúdio existente
        /// </summary>
        /// <param name="id">Id do Estúdio a ser deletado</param>
        public void Deletar(int id);

        /// <summary>
        /// Listar todos os Estúdios existentes
        /// </summary>
        /// <returns>Lista dos Estúdios</returns>
        public List<EstudioDomain> ListarTodos();
    }
}

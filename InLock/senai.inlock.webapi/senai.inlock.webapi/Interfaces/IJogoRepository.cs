using senai.inlock.webapi.Domains;

namespace senai.inlock.webapi.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório UsuarioRepository
    /// Define os métodos que serão implementados pelo repositório
    /// </summary>
    public interface IJogoRepository
    {
        /// <summary>
        /// Cadastrar um novo Jogo
        /// </summary>
        /// <param name="jogo">Jogo a ser cadastrado</param>
        public void Cadastrar(JogoDomain jogo);

        /// <summary>
        /// Deletar um Jogo existente
        /// </summary>
        /// <param name="id">Id do Jogo a ser deletado</param>
        public void Deletar(int id);

        /// <summary>
        /// Listar todos os Jogos existentes
        /// </summary>
        /// <returns>Lista de Jogos</returns>
        public List<JogoDomain> ListarTodos();
    }
}

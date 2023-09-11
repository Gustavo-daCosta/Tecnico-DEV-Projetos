using senai.inlock.webapi.Domains;

namespace senai.inlock.webapi.Interfaces
{
    public interface IUsuarioRepository
    {
        /// <summary>
        /// Interface do Método para fazer login do Usuário
        /// </summary>
        /// <param name="email">E-mail do usuário a ser logado</param>
        /// <param name="senha">Senha do usuário a ser logado</param>
        public UsuarioDomain Login(string email, string senha);

        /// <summary>
        /// Listar todos os Usuários existentes
        /// </summary>
        /// <returns>Lista de Usuários</returns>
        public List<UsuarioDomain> ListarTodos();

        /// <summary>
        /// Buscar um objeto através de seu id
        /// </summary>
        /// <param name="id">Id do objeto que será buscado</param>
        /// <returns>Objeto que foi buscado</returns>
        public UsuarioDomain BuscarPorId(int id);

        /// <summary>
        /// Cadastrar um novo Usuário
        /// </summary>
        /// <param name="usuario">Objeto do Usuário a ser cadastrado</param>
        public void Cadastrar(UsuarioDomain usuario);
    }
}

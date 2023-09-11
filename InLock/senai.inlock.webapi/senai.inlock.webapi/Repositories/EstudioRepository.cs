using senai.inlock.webapi.Domains;
using senai.inlock.webapi.Interfaces;
using System.Data.SqlClient;

namespace senai.inlock.webapi.Repositories
{
    /// <summary>
    /// Classe referente a implementação da classe da entidade Estudio
    /// </summary>
    public class EstudioRepository : IEstudioRepository
    {
        /// <summary>
		/// String de conexão com o banco de dados que recebe os seguintes parâmetros:
		/// Data Source : Nome do servidor do banco
		/// Initial Catalog: Nome do banco de dados
		/// Autenticação
		///     - windows : Integrated Security = True
		///     - SqlServer : User Id = sa; Pwd = Senha
		/// </summary>
        private string StringConexao = "Data Source = NOTE11-S14; Initial Catalog = InLock_Games; User Id = sa; Pwd = Senai@134";

        /// <summary>
        /// Cadastrar um novo Estúdio
        /// </summary>
        /// <param name="estudio">Objeto do Estúdio a ser cadastrado</param>
        public void Cadastrar(EstudioDomain estudio)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryInsert = "INSERT INTO Estudio(Nome) VALUES (@Nome)";

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@Nome", estudio.Nome);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Deletar um Estúdio existente
        /// </summary>
        /// <param name="id">Id do Estúdio a ser deletado</param>
        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryDelete = "DELETE FROM Estudio WHERE IdEstudio LIKE @Id";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Listar todos os Estúdios existentes
        /// </summary>
        /// <returns>Lista dos Estúdios</returns>
        public List<EstudioDomain> ListarTodos()
        {
            List<EstudioDomain> listaEstudios = new List<EstudioDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string querySelectAll = "SELECT IdEstudio, Nome FROM Estudio";
                con.Open();
                SqlDataReader reader;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        EstudioDomain estudio = new EstudioDomain()
                        {
                            IdEstudio = Convert.ToInt32(reader["IdEstudio"]),
                            Nome = reader["Nome"].ToString(),
                            jogosDoEstudio = new List<JogoDomain>(),
                        };

                        using (SqlConnection conJogos = new SqlConnection(StringConexao))
                        {
                            string queryFindGames = "SELECT IdJogo, IdEstudio, Nome, Descricao, DataLancamento, Valor FROM Jogo WHERE IdEstudio = @IdEstudio";
                            SqlDataReader readerJogos;
                            conJogos.Open();

                            using (SqlCommand cmdJogos = new SqlCommand(queryFindGames, conJogos))
                            {
                                cmdJogos.Parameters.AddWithValue("@IdEstudio", estudio.IdEstudio);
                                readerJogos = cmdJogos.ExecuteReader();

                                while (readerJogos.Read())
                                {
                                    JogoDomain jogo = new JogoDomain()
                                    {
                                        IdJogo = Convert.ToInt32(readerJogos["IdJogo"]),
                                        IdEstudio = Convert.ToInt32(readerJogos["IdEstudio"]),
                                        Nome = readerJogos["Nome"].ToString(),
                                        Descricao = readerJogos["Descricao"].ToString(),
                                        DataLancamento = Convert.ToDateTime(readerJogos["DataLancamento"]),
                                        Valor = Convert.ToDecimal(readerJogos["Valor"]),
                                    };
                                    estudio.jogosDoEstudio.Add(jogo);
                                }
                            }
                        }

                        listaEstudios.Add(estudio);
                    }
                }
            }
            return listaEstudios;
        }
    }
}

using senai.inlock.webapi.Domains;
using senai.inlock.webapi.Interfaces;
using System.Data.SqlClient;

namespace senai.inlock.webapi.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        private string StringConexao = "Data Source = DESKTOP-SN4RF4J\\SQLEXPRESS; Initial Catalog = InLock_Games; User Id = sa; Pwd = Senai@134";

        public void Cadastrar(JogoDomain jogo)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryInsert = "INSERT INTO Jogo(IdEstudio, Nome, Descricao, DataLancamento, Valor) VALUES (@IdEstudio, @Nome, @Descricao, @DataLancamento, @Valor)";
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@IdEstudio", jogo.IdEstudio);
                    cmd.Parameters.AddWithValue("@Nome", jogo.Nome);
                    cmd.Parameters.AddWithValue("@Descricao", jogo.Descricao);
                    cmd.Parameters.AddWithValue("@DataLancamento", jogo.DataLancamento);
                    cmd.Parameters.AddWithValue("@Valor", jogo.Valor);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryDelete = "DELETE FROM Jogo WHERE IdJogo LIKE @Id";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// teste
        /// </summary>
        /// <returns></returns>
        public List<JogoDomain> ListarTodos()
        {
            List<JogoDomain> listaJogos = new List<JogoDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string querySelectAll = "SELECT IdJogo, Jogo.Nome, Descricao, DataLancamento, Valor, Jogo.IdEstudio, Estudio.Nome AS NomeEstudio FROM Jogo INNER JOIN Estudio ON Estudio.IdEstudio LIKE Jogo.IdEstudio";
                con.Open();
                SqlDataReader reader;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        JogoDomain jogo = new JogoDomain()
                        {
                            IdJogo = Convert.ToInt32(reader["IdJogo"]),
                            Nome = reader["Nome"].ToString(),
                            Descricao = reader["Descricao"].ToString(),
                            DataLancamento = Convert.ToDateTime(reader["DataLancamento"]),
                            Valor = Convert.ToDecimal(reader["Valor"]),
                            IdEstudio = Convert.ToInt32(reader["IdEstudio"]),
                            Estudio = new EstudioDomain()
                            {
                                IdEstudio = Convert.ToInt32(reader["IdEstudio"]),
                                Nome = reader["NomeEstudio"].ToString(),
                            }
                        };
                        listaJogos.Add(jogo);
                    }
                }
            }
            return listaJogos;
        }
    }
}

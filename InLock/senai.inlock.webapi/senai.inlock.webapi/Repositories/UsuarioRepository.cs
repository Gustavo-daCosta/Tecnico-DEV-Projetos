using senai.inlock.webapi.Domains;
using senai.inlock.webapi.Interfaces;
using System.Data.SqlClient;

namespace senai.inlock.webapi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private string StringConexao = "Data Source = DESKTOP-SN4RF4J\\SQLEXPRESS; Initial Catalog = InLock_Games; User Id = sa; Pwd = Senai@134";

        public UsuarioDomain Login(string email, string senha)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryValidate = "SELECT IdUsuario, Email, Senha, Usuario.IdTipoUsuario, Titulo FROM Usuario INNER JOIN TiposUsuario ON Usuario.IdTipoUsuario LIKE TiposUsuario.IdTipoUsuario WHERE Email LIKE @Email AND Senha LIKE @Senha";
                SqlDataReader reader;

                using (SqlCommand cmd = new SqlCommand(queryValidate, con))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Senha", senha);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        UsuarioDomain usuario = new UsuarioDomain()
                        {
                            IdUsuario = Convert.ToInt32(reader["IdUsuario"]),
                            Email = reader["Email"].ToString(),
                            Senha = reader["Senha"].ToString(),
                            IdTipoUsuario = Convert.ToInt32(reader["IdTipoUsuario"]),
                            TipoUsuario = new TipoUsuarioDomain()
                            {
                                IdTipoUsuario = Convert.ToInt32(reader["IdTipoUsuario"]),
                                Titulo = reader["Titulo"].ToString(),
                            }
                        };
                        return usuario;
                    }
                }
            }
            return null;
        }

        public List<UsuarioDomain> ListarTodos()
        {
            List<UsuarioDomain> listaUsuarios = new List<UsuarioDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string querySelectAll = "SELECT IdUsuario, Usuario.IdTipoUsuario, TiposUsuario.Titulo, Email, Senha FROM Usuario INNER JOIN TiposUsuario ON TiposUsuario.IdTipoUsuario LIKE Usuario.IdTipoUsuario";
                SqlDataReader reader;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        UsuarioDomain usuario = new UsuarioDomain()
                        {
                            IdUsuario = Convert.ToInt32(reader["IdUsuario"]),
                            IdTipoUsuario = Convert.ToInt32(reader["IdTipoUsuario"]),
                            Email = reader["Email"].ToString(),
                            Senha = reader["Senha"].ToString(),
                            TipoUsuario = new TipoUsuarioDomain()
                            {
                                IdTipoUsuario = Convert.ToInt32(reader["IdTipoUsuario"]),
                                Titulo = reader["Titulo"].ToString(),
                            }
                        };
                        listaUsuarios.Add(usuario);
                    }
                }
            }
            return listaUsuarios;
        }

        public void Cadastrar(UsuarioDomain usuario)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryInsert = "INSERT INTO Usuario(IdTipoUsuario, Email, Senha) VALUES (@IdTipoUsuario, @Email, @Senha)";

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@IdTipoUsuario", usuario.IdTipoUsuario);
                    cmd.Parameters.AddWithValue("@Email", usuario.Email);
                    cmd.Parameters.AddWithValue("@Senha", usuario.Senha);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}

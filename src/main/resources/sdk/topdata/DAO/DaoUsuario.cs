using SDK_Leitor_Facial.Entity;
using SDK_Leitor_Facial.Negocio;
using System;
using System.Collections.Generic;
using System.Text;

namespace SDK_Leitor_Facial.DAO
{
    class DaoUsuario
    {
        public List<Usuario> ConsultarUsuarios()
        {
            try
            {
                List<Usuario> ListUsers = new List<Usuario>();
                var cmd = DaoConexao.ConectarBase().CreateCommand();
                cmd.CommandText = "SELECT ID, Nome, Cartao, Senha, Admin from usuario order by ID";

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Usuario user = new Usuario();
                        user.id = reader.GetInt64(0);
                        user.nome = reader.IsDBNull(1) ? "" : reader.GetValue(1).ToString();
                        user.cartao = reader.GetValue(2).ToString().Equals("") ? 0 : Int32.Parse(reader.GetValue(2).ToString());
                        user.senha = reader.GetValue(3).ToString().Equals("") ? 0 : Int32.Parse(reader.GetValue(3).ToString());
                        user.admin = reader.GetValue(4).ToString().Equals("") ? 0 : Int32.Parse(reader.GetValue(4).ToString());
                        ListUsers.Add(user);
                    }
                }

                return ListUsers;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public bool adicionar(Usuario user)
        {
            try
            {
                using (var cmd = DaoConexao.ConectarBase().CreateCommand())
                {
                    cmd.CommandText = "Insert Into Usuario(ID, Nome, Cartao, Senha, Admin) " +
                                      "values (@id,@nome,@cartao,@senha,@admin)";
                    cmd.Parameters.AddWithValue("@id", user.id);
                    cmd.Parameters.AddWithValue("@nome", user.nome);
                    cmd.Parameters.AddWithValue("@cartao", user.cartao.ToString());
                    cmd.Parameters.AddWithValue("@senha", user.senha.ToString());
                    cmd.Parameters.AddWithValue("@admin", user.admin);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        public bool atualizar(Usuario user)
        {
            try
            {
                using (var cmd = DaoConexao.ConectarBase().CreateCommand())
                {
                    cmd.CommandText = "Update Usuario Set Nome = @nome ," +
                                      " Cartao = @cartao, Senha = @senha" +
                                      " WHERE ID = @id";
                    cmd.Parameters.AddWithValue("@nome", user.nome);
                    cmd.Parameters.AddWithValue("@cartao", user.cartao);
                    cmd.Parameters.AddWithValue("@senha", user.senha);
                    cmd.Parameters.AddWithValue("@id", user.id);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        public bool apagar(long id)
        {
            try
            {
                using (var cmd = DaoConexao.ConectarBase().CreateCommand())
                {
                    cmd.CommandText = "Delete  from Usuario " +
                                      "Where ID = @id";
                    cmd.Parameters.AddWithValue("@id", id);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        public Usuario ConsultarUsuario(long id)
        {
            try
            {
                var cmd = DaoConexao.ConectarBase().CreateCommand();
                Usuario user = new Usuario();
                cmd.CommandText = "SELECT ID, Nome, Cartao, Senha, Admin from usuario WHERE Id = @id ";
                cmd.Parameters.AddWithValue("@id", id);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        user.id = reader.GetInt64(0);
                        user.nome = reader.IsDBNull(1) ? "" : reader.GetValue(1).ToString();
                        user.cartao = reader.GetValue(2).ToString().Equals("") ? 0 : Int32.Parse(reader.GetValue(2).ToString());
                        user.senha = reader.GetValue(3).ToString().Equals("") ? 0 : Int32.Parse(reader.GetValue(3).ToString());
                        user.admin = reader.GetValue(4).ToString().Equals("") ? 0 : Int32.Parse(reader.GetValue(4).ToString());
                    }
                }

                return user;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
    }
}

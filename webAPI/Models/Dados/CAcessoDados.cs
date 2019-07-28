using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using webAPI.Models.funcionarios;
using webAPI.Models.usuarios;
using MySql.Data.MySqlClient;
using System.Data;


namespace webAPI.Models
{
    public class CAcessoDados
    {
        //--------------------------------------------
        //------Inicio Métodos Funcionários

        //Strig de conexão localizada no Web config
        protected static string GetStringConexao()
        {
            return WebConfigurationManager.ConnectionStrings["Acesso_dados"].ConnectionString;
        }

        //Método que retorna uma lista de todos os funcionários
        public static List<CFuncionarios> GetCFuncionarios()
        {
            try
            {
                List<CFuncionarios> _funcionarios = new List<CFuncionarios>();
                using (MySqlConnection conexao = new MySqlConnection(GetStringConexao()))
                {
                    conexao.Open();
                    using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM funcionarios", conexao))
                    {
                        using (MySqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr != null)
                            {
                                while (dr.Read())
                                {
                                    var funcionarios = new CFuncionarios();
                                    funcionarios.id_funcionario = Convert.ToInt32(dr["id_funcionario"]);
                                    funcionarios.nome_funcionario = Convert.ToString(dr["nome_funcionario"]);
                                    _funcionarios.Add(funcionarios);
                                }
                            }
                            return _funcionarios;
                        }
                    }

                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        //Método de buscar funcionario por id
        public static CFuncionarios GetCFuncionarios(int id)
        {
            CFuncionarios funcionarios = null;
            using (MySqlConnection conexao = new MySqlConnection(GetStringConexao()))
            {
                conexao.Open();
                using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM funcionarios WHERE id_funcionario ="+id, conexao))
                {
                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                funcionarios = new CFuncionarios();
                                funcionarios.id_funcionario = Convert.ToInt32(dr["id_funcionario"]);
                                funcionarios.nome_funcionario = Convert.ToString(dr["nome_funcionario"]);
                                
                            }
                        }
                        return funcionarios;
                    }
                }
                
            }
        }

        //Método de inserção de funcionarios
        public static int InsertFuncionarios(CFuncionarios funcionario)
        {
            int registro = 0;
            using (MySqlConnection conexao = new MySqlConnection(GetStringConexao()))
            {
                string sql = "INSERT INTO funcionarios (nome_funcionario,cargo,ativo,id_usuario,admin) VALUES (@nome_funcionario,@cargo,@ativo,@id_usuario,@admin)";
                using(MySqlCommand cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@nome_funcionario", funcionario.nome_funcionario);
                    cmd.Parameters.AddWithValue("@cargo", funcionario.cargo);
                    cmd.Parameters.AddWithValue("@ativo", funcionario.ativo);
                    cmd.Parameters.AddWithValue("@id_usuario", funcionario.id_usuario);
                    cmd.Parameters.AddWithValue("@admin", funcionario.admim);

                    conexao.Open();
                    registro = cmd.ExecuteNonQuery();
                    conexao.Close();
                }
            }
            return registro;
        }

        //Método de atualização de funcionários
        public static int UpdateFuncionarios(CFuncionarios funcionario)
        {
            int registro = 0;
            using (MySqlConnection conexao = new MySqlConnection(GetStringConexao()))
            {
                string sql = "UPDATE funcionarios SET nome_funcionario=@nome_funcionario, cargo=@cargo, ativo=@ativo, id_usuario=@id_usuario, admin=@admin";
                using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@nome_funcionario", funcionario.nome_funcionario);
                    cmd.Parameters.AddWithValue("@cargo", funcionario.cargo);
                    cmd.Parameters.AddWithValue("@ativo", funcionario.ativo);
                    cmd.Parameters.AddWithValue("@id_usuario", funcionario.id_usuario);
                    cmd.Parameters.AddWithValue("@admin", funcionario.admim);

                    conexao.Open();
                    registro = cmd.ExecuteNonQuery();
                    conexao.Close();
                }
            }
            return registro;
        }

        //Método para deletar funcionario
        public static int DeleteFuncionario(int id)
        {
            int registro = 0;
            using (MySqlConnection conexao = new MySqlConnection(GetStringConexao()))
            {
                string sql = "DELETE FROM funcionarios WHERE id_funcionario = " + id;
                using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@id_funcionario", id);

                    conexao.Open();
                    registro = cmd.ExecuteNonQuery();
                    conexao.Close();
                }
            }
            return registro;
        }

        //------Fim Métodos Funcionários
        //----------------------------------------------------

        //----------------------------------------------------
        //Inicio dos Metodos referentes ao cadastro de Usuário

        //Listar todos usuarios
        public static List<CUsuario> GetCUsuario()
        {
            try
            {
                List<CUsuario> _usuarios = new List<CUsuario>();
                using (MySqlConnection conexao = new MySqlConnection(GetStringConexao()))
                {
                    conexao.Open();
                    using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM usuarios", conexao))
                    {
                        using (MySqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr != null)
                            {
                                while (dr.Read())
                                {
                                    var usuarios = new CUsuario();
                                    usuarios.id_usuarios = Convert.ToInt32(dr["id_usuario"]);
                                    usuarios.nome_usuario = Convert.ToString(dr["nome_usuario"]);
                                    usuarios.endereco = Convert.ToString(dr["endereco"]);
                                    usuarios.cpf_usuario = Convert.ToString(dr["cpf_usuario"]);
                                    usuarios.email_usuario = Convert.ToString(dr["email_usuario"]);
                                    usuarios.cidade_usuario = Convert.ToString(dr["cidade_usuario"]);
                                    usuarios.nivel_acesso = Convert.ToInt32(dr["nivel_acesso"]);
                                    usuarios.usuario = Convert.ToString(dr["usuario"]);
                                    usuarios.senha = Convert.ToString(dr["senha"]);
                                    _usuarios.Add(usuarios);
                                }
                            }
                            return _usuarios;
                        }
                    }

                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        //Listar usuário por id
        public static CUsuario GetCUsuario(int id)
        {
            CUsuario usuarios = null;
            using (MySqlConnection conexao = new MySqlConnection(GetStringConexao()))
            {
                conexao.Open();
                using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM usuarios WHERE id_usuarios =" + id, conexao))
                {
                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                               
                                usuarios.id_usuarios = Convert.ToInt32(dr["id_usuario"]);
                                usuarios.nome_usuario = Convert.ToString(dr["nome_usuario"]);
                                usuarios.endereco = Convert.ToString(dr["endereco"]);
                                usuarios.cpf_usuario = Convert.ToString(dr["cpf_usuario"]);
                                usuarios.email_usuario = Convert.ToString(dr["email_usuario"]);
                                usuarios.cidade_usuario = Convert.ToString(dr["cidade_usuario"]);
                                usuarios.nivel_acesso = Convert.ToInt32(dr["nivel_acesso"]);
                                usuarios.usuario = Convert.ToString(dr["usuario"]);
                                usuarios.senha = Convert.ToString(dr["senha"]);
                                
                            }
                        }
                        return usuarios;
                    }
                }

            }

        }


        //Fim dos métodos referentes ao cadastro de Usuarios
        //----------------------------------------------------

    }
}
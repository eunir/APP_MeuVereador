using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using webAPI.Models.funcionarios;
using webAPI.Models.usuarios;
using MySql.Data.MySqlClient;
using System.Data;
using webAPI.Models.chamados;

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
        public static CUsuario GetUsuario(int id)
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

        //Insert Usuários
        public static int InsertUsuario(CUsuario usuario)
        {
            int registro = 0;
            using (MySqlConnection conexao = new MySqlConnection(GetStringConexao()))
            {
                string sql = "INSERT INTO usuarios (nome_usuario,endereco,cpf_usuario,email_usuario,cidade_usuario,nivel_acesso,usuario,senha)" +
                    " VALUES (@nome_usuario,@endereco,@cpf_usuario,@email_usuario,@cidade_usuario,@nivel_acesso,@usuario,@senha)";
                using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@nome_usuario",usuario.nome_usuario);
                    cmd.Parameters.AddWithValue("@endereco",usuario.endereco);
                    cmd.Parameters.AddWithValue("@cpf_usuario",usuario.cpf_usuario);
                    cmd.Parameters.AddWithValue("@email_usuario",usuario.email_usuario);
                    cmd.Parameters.AddWithValue("@cidade_usuario",usuario.cidade_usuario);
                    cmd.Parameters.AddWithValue("@nivel_acesso",usuario.nivel_acesso);
                    cmd.Parameters.AddWithValue("@usuario", usuario.usuario);
                    cmd.Parameters.AddWithValue("@senha", usuario.senha);

                    conexao.Open();
                    registro = cmd.ExecuteNonQuery();
                    conexao.Close();
                }
            }
            return registro;
        }

        //Update Usuários
        public static int UpdateUsuario(CUsuario usuario)
        {
            int registro = 0;
            using (MySqlConnection conexao = new MySqlConnection(GetStringConexao()))
            {
                string sql = "UPDATE usuarios SET nome_usuario=@nome_usuario, endereco=@endereco, cpf_usuario=@cpf_usuario," +
                    "email_usuario=@email_usuario, cidade_usuario=@cidade_usuario, nivel_acesso=@nivel_acesso, usuario=@usuario, senha=@senha";
                  
                using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@nome_usuario", usuario.nome_usuario);
                    cmd.Parameters.AddWithValue("@endereco", usuario.endereco);
                    cmd.Parameters.AddWithValue("@cpf_usuario", usuario.cpf_usuario);
                    cmd.Parameters.AddWithValue("@email_usuario", usuario.email_usuario);
                    cmd.Parameters.AddWithValue("@cidade_usuario", usuario.cidade_usuario);
                    cmd.Parameters.AddWithValue("@nivel_acesso", usuario.nivel_acesso);
                    cmd.Parameters.AddWithValue("@usuario", usuario.usuario);
                    cmd.Parameters.AddWithValue("@senha", usuario.senha);

                    conexao.Open();
                    registro = cmd.ExecuteNonQuery();
                    conexao.Close();
                }
            }
            return registro;
        }

        //Delete Usuários
        public static int DeleteUsuario(int id)
        {
            int registro = 0;
            using (MySqlConnection conexao = new MySqlConnection(GetStringConexao()))
            {
                string sql = "DELETE FROM usuarios WHERE id_usuarios = " + id;
                using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@id_usuarios", id);

                    conexao.Open();
                    registro = cmd.ExecuteNonQuery();
                    conexao.Close();
                }
            }
            return registro;
        }

        //Fim dos métodos referentes ao cadastro de Usuarios
        //----------------------------------------------------

        //----------------------------------------------------
        //------Inicio dos métodos ref aos chamados-----------

        //Listar todos chamados
        public static List<CChamados> GetCChamados()
        {
            try
            {
                List<CChamados> _chamados = new List<CChamados>();
                using (MySqlConnection conexao = new MySqlConnection(GetStringConexao()))
                {
                    conexao.Open();
                    using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM chamados", conexao))
                    {
                        using (MySqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr != null)
                            {
                                while (dr.Read())
                                {
                                    var chamados = new CChamados();
                                    chamados.id_chamado = Convert.ToInt32(dr["id_chamado"]);
                                    chamados.tipo_chamado = Convert.ToString(dr["tipo_chamado"]);
                                    chamados.status_chamado = Convert.ToString(dr["status_chamado"]);
                                    chamados.descricao = Convert.ToString(dr["descricao"]);
                                    chamados.imagem_video = Convert.ToString(dr["imagem_video"]);
                                    chamados.resposta_chamado = Convert.ToString(dr["resposta_chamado"]);
                                    chamados.data_abertura= Convert.ToDateTime(dr["data_abertura"]);
                                    chamados.longitude = Convert.ToString(dr["longitude"]);
                                    chamados.latitude = Convert.ToString(dr["latitude"]);
                                    chamados.id_usuario = Convert.ToInt32(dr["id_usuario"]);
                                    chamados.id_funcionario = Convert.ToInt32(dr["id_funcionario"]);
                                    _chamados.Add(chamados);
                                }
                            }
                            return _chamados;
                        }
                    }

                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        //Listar chamados por id
        public static CChamados GetChamados(int id)
        {
            CChamados chamados = null;
            using (MySqlConnection conexao = new MySqlConnection(GetStringConexao()))
            {
                conexao.Open();
                using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM chamados WHERE id_chamado =" + id, conexao))
                {
                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {

                                chamados.id_chamado = Convert.ToInt32(dr["id_chamado"]);
                                chamados.tipo_chamado = Convert.ToString(dr["tipo_chamado"]);
                                chamados.status_chamado = Convert.ToString(dr["status_chamado"]);
                                chamados.descricao = Convert.ToString(dr["descricao"]);
                                chamados.imagem_video = Convert.ToString(dr["imagem_video"]);
                                chamados.resposta_chamado = Convert.ToString(dr["resposta_chamado"]);
                                chamados.data_abertura = Convert.ToDateTime(dr["data_abertura"]);
                                chamados.longitude = Convert.ToString(dr["longitude"]);
                                chamados.latitude = Convert.ToString(dr["latitude"]);
                                chamados.id_usuario = Convert.ToInt32(dr["id_usuario"]);
                                chamados.id_funcionario = Convert.ToInt32(dr["id_funcionario"]);

                            }
                        }
                        return chamados;
                    }
                }

            }

        }

        //Insert chamados
        public static int InsertChamados(CChamados chamados)
        {
            int registro = 0;
            using (MySqlConnection conexao = new MySqlConnection(GetStringConexao()))
            {
                string sql = "INSERT INTO chamados (tipo_chamado,status_chamado,descricao,imagem_video,resposta_chamado,data_abertura,longitude,latitude,id_usuario,id_funcionario)" +
                    " VALUES (@tipo_chamado,@status_chamado,@descricao,@imagem_video,@resposta_chamado,@data_abertura,@longitude,@latitude,@id_usuario,@id_funcionario)";
                using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@tipo_chamado", chamados.tipo_chamado);
                    cmd.Parameters.AddWithValue("@status_chamado", chamados.status_chamado);
                    cmd.Parameters.AddWithValue("@descricao", chamados.descricao);
                    cmd.Parameters.AddWithValue("@imagem_video", chamados.imagem_video);
                    cmd.Parameters.AddWithValue("@resposta_chamado", chamados.resposta_chamado);
                    cmd.Parameters.AddWithValue("@data_abertura", chamados.data_abertura);
                    cmd.Parameters.AddWithValue("@longitude", chamados.longitude);
                    cmd.Parameters.AddWithValue("@latitude", chamados.latitude);
                    cmd.Parameters.AddWithValue("@id_usuario", chamados.id_usuario);
                    cmd.Parameters.AddWithValue("@id_funcionario", chamados.id_funcionario);

                    conexao.Open();
                    registro = cmd.ExecuteNonQuery();
                    conexao.Close();
                }
            }
            return registro;
        }

        //Update chamados
        public static int UpdateChamados(CChamados chamados)
        {
            int registro = 0;
            using (MySqlConnection conexao = new MySqlConnection(GetStringConexao()))
            {
                string sql = "UPDATE chamados SET tipo_chamado=@tipo_chamado, status_chamado=@status_chamado, descricao=@descricao, imagem_video=@imagem_video" +
                    "resposta_chamado=@resposta_chamado, data_abertura=@data_abertura, longitude=@longitude, latitude=@latitude, id_usuario=@id_usuario, id_funcionario=@id_funcionario ";
                using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@tipo_chamado", chamados.tipo_chamado);
                    cmd.Parameters.AddWithValue("@status_chamado", chamados.status_chamado);
                    cmd.Parameters.AddWithValue("@descricao", chamados.descricao);
                    cmd.Parameters.AddWithValue("@imagem_video", chamados.imagem_video);
                    cmd.Parameters.AddWithValue("@resposta_chamado", chamados.resposta_chamado);
                    cmd.Parameters.AddWithValue("@data_abertura", chamados.data_abertura);
                    cmd.Parameters.AddWithValue("@longitude", chamados.longitude);
                    cmd.Parameters.AddWithValue("@latitude", chamados.latitude);
                    cmd.Parameters.AddWithValue("@id_usuario", chamados.id_usuario);
                    cmd.Parameters.AddWithValue("@id_funcionario", chamados.id_funcionario);

                    conexao.Open();
                    registro = cmd.ExecuteNonQuery();
                    conexao.Close();
                }
            }
            return registro;
        }

        //Delete chamados
        public static int DeleteChamados(int id)
        {
            int registro = 0;
            using (MySqlConnection conexao = new MySqlConnection(GetStringConexao()))
            {
                string sql = "DELETE FROM chamados WHERE id_chamado = " + id;
                using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@id_chamado", id);

                    conexao.Open();
                    registro = cmd.ExecuteNonQuery();
                    conexao.Close();
                }
            }
            return registro;
        }
        //------Fim dos métodos ref aos chamados--------------
        //----------------------------------------------------

    }
}
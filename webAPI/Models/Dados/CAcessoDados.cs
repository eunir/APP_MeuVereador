using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using webAPI.Models.funcionarios;
using MySql.Data.MySqlClient;


namespace webAPI.Models
{
    public class CAcessoDados
    {
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


    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webAPI.Models.funcionarios
{
    public class CFuncionarios
    {
        public int id_funcionario { get; set; }
        public int id_usuario { get; set; }
        public string nome_funcionario { get; set; }
        public string cargo { get; set; }
        public string ativo { get; set; }
        public string admim { get; set; }
    }
}
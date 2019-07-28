using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webAPI.Models.usuarios
{
    public class CUsuario
    {
        public int id_usuarios { get; set; }
        public string nome_usuario { get; set; }
        public string endereco { get; set; }
        public string cpf_usuario { get; set; }
        public string email_usuario { get; set; }
        public string cidade_usuario { get; set; }
        public int nivel_acesso { get; set; }
        public string usuario { get; set; }
        public string senha { get; set; }
    }
}
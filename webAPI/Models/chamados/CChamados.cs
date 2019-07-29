using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webAPI.Models.chamados
{
    public class CChamados
    {
        public int id_chamado { get; set; }
        public string tipo_chamado { get; set; }
        public string status_chamado { get; set; }
        public string descricao { get; set; }
        public string imagem_video { get; set; }
        public string resposta_chamado { get; set; }
        public DateTime data_abertura { get; set; }
        public string longitude { get; set; }
        public string latitude { get; set; }
        public int id_usuario { get; set; }
        public int id_funcionario { get; set; }

    }
}
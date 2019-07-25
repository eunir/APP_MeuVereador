using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using webAPI.Models.funcionarios;

namespace webAPI.Controllers
{
    public class FuncionariosController : ApiController
    {
        private readonly IFuncionariosRepositorio _funcionariosRepositorio;
        public FuncionariosController()
        {
            _funcionariosRepositorio = new CFuncionariosRepositorio();
        }

        //GET: api/funcionarios
        [HttpGet]
        public IEnumerable<CFuncionarios> List()
        {
            return _funcionariosRepositorio.All;
        }

        //GET: api/funcionarios/id
        public CFuncionarios GetFuncionarios(int id)
        {
            var funcionario = _funcionariosRepositorio.Find(id);
            if (funcionario == null)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            }
            return funcionario;
        }
    }
}

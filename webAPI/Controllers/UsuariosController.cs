using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using webAPI.Models.usuarios;

namespace webAPI.Controllers
{
    public class UsuariosController : ApiController
    {
        public class UsuarioController : ApiController
        {
            private readonly IUsuarioRepositorio _usuarioRepositorio;
            public UsuarioController()
            {
                _usuarioRepositorio = new CUsuarioRepositorio();
            }

            //GET: api/usuario
            [HttpGet]
            public IEnumerable<CUsuario> List()
            {
                return _usuarioRepositorio.All;
            }

            //GET: api/usuario/id
            public CUsuario GetUsuario(int id)
            {
                var usuario = _usuarioRepositorio.Find(id);
                if (usuario == null)
                {
                    throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
                }
                return usuario;
            }

            //POST: api/usuario
            [HttpPost()]
            public void Post([FromBody]CUsuario usuario)
            {
                _usuarioRepositorio.insert(usuario);
            }

            //PUT: api/usuario/id
            [HttpPut()]
            public void Put(int id, [FromBody]CUsuario usuario)
            {
                usuario.id_usuarios = id;
                _usuarioRepositorio.update(usuario);
            }

            //DELETE: api/usuario/id
            [HttpDelete()]
            public void Delete(int id)
            {
                _usuarioRepositorio.delete(id);
            }
        }
    }
}

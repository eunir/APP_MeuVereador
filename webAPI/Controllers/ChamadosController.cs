using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using webAPI.Models.chamados;

namespace webAPI.Controllers
{
    public class ChamadosController : ApiController
    {
        private readonly IChamadosRepositorio _chamadosRepositorio;
        public ChamadosController()
        {
            _chamadosRepositorio = new CChamadosRepositorio();
        }

        //GET: api/chamados
        [HttpGet]
        public IEnumerable<CChamados> List()
        {
            return _chamadosRepositorio.All;
        }

        //GET: api/chamados/id
        public CChamados GetChamados(int id)
        {
            var chamados = _chamadosRepositorio.Find(id);
            if (chamados == null)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            }
            return chamados;
        }

        //POST: api/chamados
        [HttpPost()]
        public void Post([FromBody]CChamados chamados)
        {
            _chamadosRepositorio.insert(chamados);
        }

        [HttpPost]
        [Route("api/FileUploading/UploadFile")]
        public async Task<string> UploadFile()
        {
            var ctx = HttpContext.Current;
            var root = ctx.Server.MapPath("~/App_Data");
            var provider = new MultipartFormDataStreamProvider(root);
            try
            {
                await Request.Content.ReadAsMultipartAsync(provider);
                foreach(var File in provider.FileData)
                {
                    var name = File.Headers.ContentDisposition.FileName;
                    name = name.Trim('"');
                    var localFileName = File.LocalFileName;
                    var filePath = Path.Combine(root, name);
                    File.Move(localFileName, filePath);


                }
            }
            catch ( Exception E)
            {

                return $"Error:{E.Message}";
            }
            return "File Upload!";
        }
        //PUT: api/chamados/id
        [HttpPut()]
        public void Put(int id, [FromBody]CChamados chamados)
        {
            chamados.id_chamado = id;
            _chamadosRepositorio.update(chamados);
        }

        //DELETE: api/chamados/id
        [HttpDelete()]
        public void Delete(int id)
        {
            _chamadosRepositorio.delete(id);
        }
    }
}

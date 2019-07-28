using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webAPI.Models.usuarios
{
    public class CUsuarioRepositorio : IUsuarioRepositorio
    {
        private List<CUsuario> _usuario;
        public CUsuarioRepositorio()
        {
            InicializaDados();
        }
        private void InicializaDados()
        {
            _usuario = CAcessoDados.GetCUsuario();
        }
        public IEnumerable<CUsuario> All
        {
            get
            {
                return _usuario;
            }
        }

        public void delete(int id)
        {
            CAcessoDados.DeleteUsuario(id);
        }

        public CUsuario Find(int id)
        {
            return CAcessoDados.GetUsuario(id);
        }

        public void insert(CUsuario usuario)
        {
            if (usuario == null)
            {
                throw new ArgumentNullException("usuario");
            }
            else
            {
                CAcessoDados.InsertUsuario(usuario);
            }
        }

        public void update(CUsuario usuario)
        {
            if (usuario == null)
            {
                throw new ArgumentNullException("usuario");
            }
            else
            {
                CAcessoDados.UpdateUsuario(usuario);
            }
        }
    }
}
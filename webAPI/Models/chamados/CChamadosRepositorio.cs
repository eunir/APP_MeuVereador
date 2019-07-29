using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webAPI.Models.chamados
{
    public class CChamadosRepositorio : IChamadosRepositorio
    {
        private List<CChamados> _chamados;
        public CChamadosRepositorio()
        {
            InicializaDados();
        }
        private void InicializaDados()
        {
            _chamados = CAcessoDados.GetCChamados();
        }
        public IEnumerable<CChamados> All
        {
            get
            {
                return _chamados;
            }
        }

        public void delete(int id)
        {
            CAcessoDados.DeleteChamados(id);
        }

        public CChamados Find(int id)
        {
            return CAcessoDados.GetChamados(id);
        }

        public void insert(CChamados chamado)
        {
            if (chamado == null)
            {
                throw new ArgumentNullException("chamado");
            }
            else
            {
                CAcessoDados.InsertChamados(chamado);
            }
        }

        public void update(CChamados chamado)
        {
            if (chamado == null)
            {
                throw new ArgumentNullException("chamado");
            }
            else
            {
                CAcessoDados.UpdateChamados(chamado);
            }
        }
    }
}
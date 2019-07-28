using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webAPI.Models.funcionarios;
using webAPI.Models;



namespace webAPI.Models.funcionarios
{
    public class CFuncionariosRepositorio : IFuncionariosRepositorio
    {
        private List<CFuncionarios> _funcionarios;
        public CFuncionariosRepositorio()
        {
            InicializaDados();
        }
        private void InicializaDados()
        {
            _funcionarios = CAcessoDados.GetCFuncionarios();
        }
        public IEnumerable<CFuncionarios> All
        {
            get
            {
                return _funcionarios;
            }
        }

        public void delete(int id)
        {
            CAcessoDados.DeleteFuncionario(id);
        }

        public CFuncionarios Find(int id)
        {
            return CAcessoDados.GetCFuncionarios(id);
        }

        public void insert(CFuncionarios funcionario)
        {
            if (funcionario == null)
            {
                throw new ArgumentNullException("funcionarios");
            }
            else
            {
                CAcessoDados.InsertFuncionarios(funcionario);
            }
        }

        public void update(CFuncionarios funcionario)
        {
            if (funcionario == null)
            {
                throw new ArgumentNullException("funcionarios");
            }
            else
            {
                CAcessoDados.UpdateFuncionarios(funcionario);
            }
        }
    }
}
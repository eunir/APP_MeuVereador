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
        //public IEnumerable<CFuncionarios> All => throw new NotImplementedException();

        public void delete(int id)
        {
            throw new NotImplementedException();
        }

        public CFuncionarios Find(int id)
        {

            throw new NotImplementedException();
        }

        public void insert(CFuncionarios item)
        {
            throw new NotImplementedException();
        }

        public void update(CFuncionarios item)
        {
            throw new NotImplementedException();
        }
    }
}
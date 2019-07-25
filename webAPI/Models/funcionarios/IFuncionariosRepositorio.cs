using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webAPI.Models.funcionarios
{
    public interface IFuncionariosRepositorio
    {
        IEnumerable<CFuncionarios> All { get; }
        CFuncionarios Find(int id);
        void insert(CFuncionarios item);
        void update(CFuncionarios item);
        void delete(int id);

    }
}

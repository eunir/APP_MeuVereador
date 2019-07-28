using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webAPI.Models.usuarios
{
    interface IUsuarioRepositorio
    {
        IEnumerable<CUsuario> All { get; }
        CUsuario Find(int id);
        void insert(CUsuario item);
        void update(CUsuario item);
        void delete(int id);

    }
}

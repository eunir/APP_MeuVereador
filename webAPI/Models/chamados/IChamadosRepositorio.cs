using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webAPI.Models.chamados
{
    interface IChamadosRepositorio
    {
        IEnumerable<CChamados> All { get; }
        CChamados Find(int id);
        void insert(CChamados item);
        void update(CChamados item);
        void delete(int id);
    }
}

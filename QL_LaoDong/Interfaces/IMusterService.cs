using QL_LaoDong.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QL_LaoDong.Interfaces
{
    public interface IMusterService
    {
        List<Muster> Get();
        Muster GetById(int id);
        void Create(Muster model);
        void Edit(Muster model);
        void Delete(Muster model);
    }
}

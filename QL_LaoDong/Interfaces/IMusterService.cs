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
        List<Muster> PageMuster(long id);
        Muster GetById(int id);
        void AddStudent(Muster model, long id);
        void Edit(Muster model);
        void Delete(Muster model);
    }
}

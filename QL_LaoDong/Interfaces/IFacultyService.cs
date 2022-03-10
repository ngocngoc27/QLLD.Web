using QL_LaoDong.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QL_LaoDong.Interfaces
{
    public interface IFacultyService
    {
        List<Faculty> Get();
        Faculty GetById(int id);
        void Create(Faculty model);
        void Edit(Faculty model);
        void Delete(Faculty model);
    }
}

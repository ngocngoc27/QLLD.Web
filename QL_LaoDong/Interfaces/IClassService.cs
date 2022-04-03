using QL_LaoDong.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QL_LaoDong.Interfaces
{
    public interface IClassService
    {
        List<Class> Get();
        Class GetById(int id);
        void Create(Class model);
        void Edit(Class model);
        void Delete(Class model);
        bool ClassExists(long id);
        int CountClass();
        int CountHoanthanh();
        int CountChuaHT();
        int CountChuaxet();
        int CountLD();
        int countTotalLD();
    }
}

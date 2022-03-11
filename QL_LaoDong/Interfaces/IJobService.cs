using QL_LaoDong.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QL_LaoDong.Interfaces
{
    public interface IJobService
    {
        List<Job> Get();
        Job GetById(int id);
        void Create(Job model);
        void Edit(Job model);
        void Delete(Job model);
        void Lock(Job model);
    }
}

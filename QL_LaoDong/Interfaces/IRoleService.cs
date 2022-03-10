using QL_LaoDong.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QL_LaoDong.Interfaces
{
    public interface IRoleService
    {
        List<Role> Get();
        Role GetById(int id);
        void Create(Role model);
        void Edit(Role model);
        void Delete(Role model);
    }
}

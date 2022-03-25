using QL_LaoDong.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QL_LaoDong.Interfaces
{
    public interface IGroupsService
    {
        List<Groups> Get();
        Groups GetById(int id);
        void Create(Groups model);
        void Edit(Groups model);
        void Delete(Groups model);
        bool GroupsExists(long id);
    }
}

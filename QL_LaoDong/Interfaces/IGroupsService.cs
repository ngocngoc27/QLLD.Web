using QL_LaoDong.Models;
using QL_LaoDong.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QL_LaoDong.Interfaces
{
    public interface IGroupsService
    {
        List<Groups> Get();
        List<Groups> PageGroups(long id);
        Groups GetById(long id);
        void CreateGroups(Groups model, long id);
        void Edit(Groups model);
        void Delete(Groups model);
        bool GroupsExists(long id);
    }
}

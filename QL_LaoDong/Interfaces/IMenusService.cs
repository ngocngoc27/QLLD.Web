using QL_LaoDong.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QL_LaoDong.Interfaces
{
    public interface IMenusService
    {
        List<Menus> Get();
        Menus GetById(int id);
        void Create(Menus model);
        void Edit(Menus model);
        void Delete(Menus model);
    }
}

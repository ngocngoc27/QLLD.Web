using QL_LaoDong.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QL_LaoDong.Interfaces
{
    public interface IMenusRoleService
    {
        List<MenusRole> Get();
        MenusRole GetById(int IdMn);
        void Create(MenusRole model);
        void Edit(MenusRole model, int id);
        void Delete(int id);
        bool MenusRoleExists(long IdMn);
    }
}

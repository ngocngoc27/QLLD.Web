using Microsoft.AspNetCore.Http;
using QL_LaoDong.Data;
using QL_LaoDong.Interfaces;
using QL_LaoDong.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QL_LaoDong.Services
{
    public class MenusRoleService : IMenusRoleService
    {
        public DataContext _context;
        private IHttpContextAccessor _httpContextAccessor;
        public MenusRoleService(DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }
        public void Create(MenusRole model)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Edit(MenusRole model, int id)
        {
            throw new NotImplementedException();
        }

        public List<MenusRole> Get()
        {
            throw new NotImplementedException();
        }

        public MenusRole GetById(int IdMn)
        {
            throw new NotImplementedException();
        }

        public bool MenusRoleExists(long IdMn)
        {
            throw new NotImplementedException();
        }
    }
}

using QL_LaoDong.Data;
using QL_LaoDong.Interfaces;
using QL_LaoDong.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QL_LaoDong.Services
{
    public class RoleService : IRoleService
    {
        public DataContext _context;
        public RoleService(DataContext context)
        {
            _context = context;
        }
        public void Create(Role model)
        {
            var entity = new Role();
            entity.NameRole = model.NameRole;
            entity.IsDelete = false;
            entity.Code = model.Code;
            _context.Role.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Role model)
        {
            var entity = _context.Role.Where(x => x.Id == model.Id).FirstOrDefault();
            if (entity == default)
                throw new Exception("Không tìm thấy dữ liệu.");

            _context.Role.Remove(entity);
            _context.SaveChanges();
        }

        public void Edit(Role model)
        {
            var entity = _context.Role.Where(x => x.Id == model.Id).FirstOrDefault();
            if (entity == default)
                throw new Exception("Không tìm thấy dữ liệu.");
            entity.NameRole = model.NameRole;
            entity.IsDelete = model.IsDelete;
            entity.Code = model.Code;
            _context.Role.Update(entity);
            _context.SaveChanges();
        }

        public List<Role> Get()
        {
            return _context.Role.Where(x => x.IsDelete != true).ToList();
        }

        public Role GetById(int id)
        {
            return _context.Role.Where(x => x.Id == id).FirstOrDefault();
        }
    }
}

using QL_LaoDong.Data;
using QL_LaoDong.Interfaces;
using QL_LaoDong.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QL_LaoDong.Services
{
    public class MenusService : IMenusService
    {
        public DataContext _context;
        public MenusService(DataContext context)
        {
            _context = context;
        }
        public void Create(Menus model)
        {
            var entity = new Menus();
            entity.Label = model.Label;
            entity.Parent = model.Parent;
            entity.UrlLink = model.UrlLink;
            entity.OrderKey = model.OrderKey;
            entity.UserAdd = model.UserAdd;
            entity.Hide = model.Hide;
            _context.Menus.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Menus model)
        {
            var entity = _context.Menus.Where(x =>x.IdMn == model.IdMn).FirstOrDefault();
            if (entity == default)
                throw new Exception("Không tìm thấy dữ liệu.");
            _context.Menus.Remove(entity);
            _context.SaveChanges();
        }

        public void Edit(Menus model)
        {
            var entity = _context.Menus.Where(x => x.IdMn == model.IdMn).FirstOrDefault();
            if (entity == default)
                throw new Exception("Không tìm thấy dữ liệu.");
            entity.Label = model.Label;
            entity.Parent = model.Parent;
            entity.UrlLink = model.UrlLink;
            entity.OrderKey = model.OrderKey;
            entity.UserAdd = model.UserAdd;
            entity.Hide = model.Hide;
            _context.Menus.Update(entity);
            _context.SaveChanges();
        }

        public List<Menus> Get()
        {
            return _context.Menus.ToList();
        }

        public Menus GetById(int id)
        {
            return _context.Menus.Where(x => x.IdMn == id).FirstOrDefault();
        }
        public bool MenusExists(long id)
        {
            return _context.Menus.Any(x => x.IdMn == id);
        }
    }
    
}

using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
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
        private IHttpContextAccessor _httpContextAccessor;
        public MenusService(DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public void Create(Menus model)
        {
            var entity = new Menus();
            entity.Label = model.Label;
            entity.Parent = model.Parent;
            entity.UrlLink = model.UrlLink;
            entity.OrderKey = model.OrderKey;
            string data = _httpContextAccessor.HttpContext.Session.GetString("id");
            int id = Convert.ToInt32(data);
            entity.UserAdd = id;
            entity.Hide = model.Hide;
            _context.Menus.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = _context.Menus.Where(x => x.IdMn == id).FirstOrDefault();
            if (entity == default)
                throw new Exception("Không tìm thấy dữ liệu.");

            _context.Menus.Remove(entity);
            _context.SaveChanges();
        }

        public void Edit(Menus model, int id)
        {
            var entity = _context.Menus.Where(x => x.IdMn == id).FirstOrDefault();
            if (entity == default)
                throw new Exception("Không tìm thấy dữ liệu.");
            entity.Label = model.Label;
            entity.Parent = model.Parent;
            entity.UrlLink = model.UrlLink;
            entity.OrderKey = model.OrderKey;
            entity.UserAdd = model.UserAdd;
            entity.Hide = model.Hide;
            _context.SaveChanges();
        }

        public List<Menus> Get()
        {
            string data = _httpContextAccessor.HttpContext.Session.GetString("id");
            int id = Convert.ToInt32(data);
            var menu = _context.Menus.Include(x => x.UserAddNavigation).ToList();
            return menu;
        }

        public Menus GetById(int IdMn)
        {
            return _context.Menus.Where(x => x.IdMn == IdMn).FirstOrDefault();
        }

        public bool MenusExists(long IdMn)
        {
            return _context.Menus.Any(x => x.IdMn == IdMn);
        }
    }
    
}

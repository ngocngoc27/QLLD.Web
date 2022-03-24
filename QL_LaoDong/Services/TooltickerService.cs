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
    public class TooltickerService : ITooltickerService
    {
        public DataContext _context;
        public TooltickerService(DataContext context)
        {
            _context = context;
        }
        public void Create(Toolticker model)
        {
            var entity = new Toolticker();
            entity.ToolId = model.ToolId;
            entity.GroupsId= model.GroupsId;
            entity.Amount = model.Amount;
            entity.Notes = model.Notes;
            _context.Toolticker.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Toolticker model)
        {
            var entity = _context.Toolticker.Where(x => x.Id == model.Id).FirstOrDefault();
            if (entity == default)
                throw new Exception("Không tìm thấy dữ liệu.");

            _context.Toolticker.Remove(entity);
            _context.SaveChanges();
        }

        public void Edit(Toolticker model)
        {
            var entity = _context.Toolticker.Where(x => x.Id == model.Id).FirstOrDefault();
            if (entity == default)
                throw new Exception("Không tìm thấy dữ liệu.");
            entity.ToolId = model.ToolId;
            entity.GroupsId = model.GroupsId;
            entity.Amount = model.Amount;
            entity.Notes = model.Notes;
            _context.Toolticker.Update(entity);
            _context.SaveChanges();
        }

        public List<Toolticker> Get()
        {
            return _context.Toolticker.Include(x=>x.Tool).Include(x => x.Groups).ToList();
        }

        public Toolticker GetById(int id)
        {
            return _context.Toolticker.Where(x => x.Id == id).FirstOrDefault();
        }
    }
}

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
        public void Create(Toolticker model, long id)
        {
            var entity = new Toolticker();
            entity.ToolId = model.ToolId;
            entity.GroupsId= id;
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
            entity.IsDelete = true;
            _context.SaveChanges();
        }

        public void Edit(Toolticker model)
        {
            var entity = _context.Toolticker.Where(x => x.Id == model.Id).FirstOrDefault();
            if (entity == default)
                throw new Exception("Không tìm thấy dữ liệu.");
            entity.ToolId = model.ToolId;
            entity.Amount = model.Amount;
            entity.Notes = model.Notes;
            _context.Toolticker.Update(entity);
            _context.SaveChanges();
        }

        public List<Toolticker> PageToolTicker(long id)
        {
            return _context.Toolticker.Include(x => x.Tool).Include(x => x.Groups).Where(x => x.GroupsId == id && x.IsDelete != true).ToList();
        }
        public Toolticker GetById(long id)
        {
            return _context.Toolticker.Include(x => x.Tool).Include(x => x.Groups).Where(x => x.Id == id).FirstOrDefault();
        }
        public bool TooltickerExists(long id)
        {
            return _context.Toolticker.Any(x => x.Id == id);
        }
    }
}

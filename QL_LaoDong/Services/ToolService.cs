using QL_LaoDong.Data;
using QL_LaoDong.Interfaces;
using QL_LaoDong.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QL_LaoDong.Services
{
    public class ToolService:IToolService
    {
        public DataContext _context;
        public ToolService(DataContext context)
        {
            _context = context;
        }
        public List<Tool> Get()
        {
            return _context.Tool.Where(x => x.IsDelete != true).ToList();
        }

        public Tool GetById(int id)
        {
            return _context.Tool.Where(x => x.Id == id).FirstOrDefault();
        }

        public void Create(Tool model)
        {
            var entity = new Tool();
            entity.Tool1 = model.Tool1;
            entity.Sum = model.Sum;
            entity.Unit = model.Unit;
            entity.Available = entity.Sum;
            entity.IsDelete = false;
            _context.Tool.Add(entity);
            _context.SaveChanges();
        }

        public void Edit(Tool model)
        {
            var entity = _context.Tool.Where(x => x.Id == model.Id).FirstOrDefault();
            if (entity == default)
                throw new Exception("Không tìm thấy dữ liệu.");
            entity.Tool1 = model.Tool1;
            entity.Sum = model.Sum;
            entity.Unit = model.Unit;
            entity.Available = entity.Sum;
            _context.Tool.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(Tool model)
        {
            var entity = _context.Tool.Where(x => x.Id == model.Id).FirstOrDefault();
            if (entity == default)
                throw new Exception("Không tìm thấy dữ liệu.");
            entity.IsDelete = true;
            _context.SaveChanges();
        }

        public void Lock(Tool model)
        {
            var entity = _context.Tool.Where(x => x.Id == model.Id).FirstOrDefault();
            if (entity == default)
                throw new Exception("Không tìm thấy dữ liệu.");
            entity.IsDelete = true;
            _context.Tool.Update(entity);
            _context.SaveChanges();
        }
        public bool ToolExists(long id)
        {
            return _context.Tool.Any(x => x.Id == id);
        }
    }
}

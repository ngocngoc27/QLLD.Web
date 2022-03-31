using QL_LaoDong.Data;
using QL_LaoDong.Interfaces;
using QL_LaoDong.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QL_LaoDong.Services
{
    public class FacultyService : IFacultyService
    {
        public DataContext _context;

        public FacultyService(DataContext context)
        {
            _context = context;
        }
        public void Create(Faculty model)
        {
            var entity = new Faculty();
            entity.FacultyName = model.FacultyName;
            entity.IsDelete = false;
            _context.Faculty.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Faculty model)
        {
            var entity = _context.Faculty.Where(x => x.Id == model.Id).FirstOrDefault();
            if (entity == default)
                throw new Exception("Không tìm thấy dữ liệu.");
            entity.IsDelete = true;
            _context.SaveChanges();
        }

        public void Edit(Faculty model)
        {
            var entity = _context.Faculty.Where(x => x.Id == model.Id).FirstOrDefault();
            if (entity == default)
                throw new Exception("Không tìm thấy dữ liệu.");
            entity.FacultyName = model.FacultyName;
            _context.Faculty.Update(entity);
            _context.SaveChanges();
        }

        public List<Faculty> Get()
        {
            return _context.Faculty.Where(x=>x.IsDelete != true).ToList();
        }

        public Faculty GetById(int id)
        {
            return _context.Faculty.Where(x => x.Id == id).FirstOrDefault();
        }
    }
}

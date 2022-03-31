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
    public class ClassService : IClassService
    {
        public DataContext _context;
        public ClassService(DataContext context)
        {
            _context = context;
        }
        public void Create(Class model)
        {
            var entity = new Class();
            entity.ClassCode = model.ClassCode;
            entity.ClassName = model.ClassName;
            entity.Training = model.Training;
            entity.TypeOfEducation = model.TypeOfEducation;
            entity.Total = model.Total;
            entity.TotalOfWork = model.TotalOfWork;
<<<<<<< HEAD
            entity.Status = 1; 
=======
            entity.Status = model.Status; //1 = Chưa hoàn thành
>>>>>>> 1220823fdd6829c49d66ef79fada7b105d77daa5
            entity.FacultyId = model.FacultyId;
            entity.IsDelete = false;
            _context.Class.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Class model)
        {
            var entity = _context.Class.Where(x => x.Id == model.Id).FirstOrDefault();
            if (entity == default)
                throw new Exception("Không tìm thấy dữ liệu.");
            entity.IsDelete = true;
            _context.SaveChanges();
        }

        public void Edit(Class model)
        {
            var entity = _context.Class.Where(x => x.Id == model.Id).FirstOrDefault();
            if (entity == default)
                throw new Exception("Không tìm thấy dữ liệu.");
            entity.ClassCode = model.ClassCode;
            entity.ClassName = model.ClassName;
            entity.Training = model.Training;
            entity.TypeOfEducation = model.TypeOfEducation;
            entity.Total = model.Total;
            entity.TotalOfWork = model.TotalOfWork;
            entity.Status = model.Status;
            entity.FacultyId = model.FacultyId;
            _context.Class.Update(entity);
            _context.SaveChanges();
        }

        public List<Class> Get()
        {
            return _context.Class.Include(x=>x.Faculty).Where(x => x.IsDelete != true).ToList();
        }

        public Class GetById(int id)
        {
            return _context.Class.Where(x => x.Id == id).FirstOrDefault();
        }
        public bool ClassExists(long id)
        {
            return _context.Class.Any(x => x.Id == id);
        }
        public int CountClass()
        {
            var data = _context.Class.Where(x => x.IsDelete != true).ToList();
            return data.Count();
        }
    }
}

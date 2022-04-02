using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using QL_LaoDong.Data;
using QL_LaoDong.Helpers;
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
        private IHttpContextAccessor _httpContextAccessor;
        public ClassService(DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
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
            entity.Status = model.Status; //1 = Chưa hoàn thành
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
        public int CountHoanthanh()
        {
            var data = _context.Class.Where(x => x.IsDelete != true && x.Status == (int)ClassEnum.hoanthanh).ToList();
            return data.Count();
        }
        public int CountChuaHT()
        {
            var data = _context.Class.Where(x => x.IsDelete != true && x.Status == (int)ClassEnum.chuahoanthanh).ToList();
            return data.Count();
        }
        public int CountChuaxet()
        {
            var data = _context.Class.Where(x => x.IsDelete != true && x.Status == (int)ClassEnum.chuaxet).ToList();
            return data.Count();
        }
        public int CountLD()
        {
            var data = _context.Class.Where(x => x.IsDelete != true).Sum(x=>x.TotalOfWork);

            return data.Value;
        }
        public int countTotalLD()
        {
            string data = _httpContextAccessor.HttpContext.Session.GetString("idclass");
            long id = Convert.ToInt64(data);
            string typeofedu = _httpContextAccessor.HttpContext.Session.GetString("typeofedu");
            if (typeofedu == "Đại học")
            {
                var dulieu = _context.Class.Where(x => x.Id == id).FirstOrDefault();
                int total = ((int)(dulieu.Total * 18));
                return total;
            }
            else
            {
                var dulieu = _context.Class.Where(x => x.Id == id).FirstOrDefault();
                int total = ((int)(dulieu.Total * 12));
                return total;
            }
        }
    }
}

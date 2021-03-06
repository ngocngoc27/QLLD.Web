using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using QL_LaoDong.Data;
using QL_LaoDong.Helpers;
using QL_LaoDong.Interfaces;
using QL_LaoDong.Models;
using QL_LaoDong.ViewModels;
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
            if (model.Total == default)
            {
                entity.Total = 0;
            }
            else
            {
                entity.Total = model.Total;
            }
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
            if (model.Total == default)
            {
                entity.Total = entity.Total;
            }
            else
            {
                entity.Total = model.Total;
            }
            entity.TotalOfWork = model.TotalOfWork;
            entity.Status = model.Status;
            entity.FacultyId = model.FacultyId;
            _context.Class.Update(entity);
            _context.SaveChanges();
        }

        public List<Class> Get()
        {
            return _context.Class.Include(x => x.Student).Include(x => x.Faculty).Where(x => x.IsDelete != true).ToList();
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

            return data;
        }
       public int CountNgayLD()
        {
            string data = _httpContextAccessor.HttpContext.Session.GetString("typeofedu");
            string idclass = _httpContextAccessor.HttpContext.Session.GetString("idclass");
            int id = Convert.ToInt32(idclass);
            int ngayld = 0;
            var value = _context.Class.Where(x => x.IsDelete != true && x.Id==id).FirstOrDefault();
            if (data == "Đại học")
            {
                ngayld = (int)(value.Total * 18);
                return ngayld;
            }
            else
                return ngayld = (int)(value.Total * 12);
        }
        public List<ClassRPVM> GetClass()
        {
            var data = _context.Class.Include(x=>x.Faculty).Where(x => x.IsDelete != true).Select(x => new ClassRPVM()
            {
                ClassCode=x.ClassCode,
                ClassName=x.ClassName,
                TypeOfEducation=x.TypeOfEducation,
                FacultyName=x.Faculty.FacultyName,
                Total=(int)x.Total,
                TotalOfWork=(int)x.TotalOfWork

            }).ToList();
            return data;
        }
        public void TongLD(Class model)
        {
            var stu = _context.Student.Where(x => x.ClassId == model.Id && x.IsDelete!=true).Sum(x => x.NumberOfWork);
            var sslop = _context.Class.Where(x => x.Id ==model.Id && x.IsDelete!=true).Select(x => x.Total).FirstOrDefault();
            int ss = Convert.ToInt32(sslop);
            string typeofedu = _httpContextAccessor.HttpContext.Session.GetString("typeofedu");
            float ngaylaodong = 0;
            if (typeofedu == "Đại học")
            {
                ngaylaodong = ((float)stu / (ss * 18)) * 100;
            }
            else
            {
                ngaylaodong = ((float)stu / (ss * 12)) * 100;
            }
            var sosinhvien = _context.Student.Where(x => x.ClassId == model.Id && x.IsDelete!=true).ToList();
            int sosv = Convert.ToInt32(sosinhvien.Count());
            var entity = _context.Class.Where(x => x.Id == model.Id && x.IsDelete!=true).FirstOrDefault();
            if (entity == default)
                throw new Exception("Không tìm thấy dữ liệu.");
            entity.TotalOfWork = Convert.ToInt32(stu);
            if (ngaylaodong >= 70)
            {
                entity.Status = (int)ClassEnum.hoanthanh;
            }
            else if (ngaylaodong < 70)
            {
                entity.Status = (int)ClassEnum.chuahoanthanh;
            }

            entity.Total = sosv;
            _context.SaveChanges();
        }
    }
}

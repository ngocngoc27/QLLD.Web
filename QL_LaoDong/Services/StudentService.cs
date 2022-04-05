using ClosedXML.Excel;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using QL_LaoDong.Data;
using QL_LaoDong.Helpers;
using QL_LaoDong.Interfaces;
using QL_LaoDong.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace QL_LaoDong.Services
{
    public class StudentService:IStudentService
    {
        public DataContext _context;
        private IHttpContextAccessor _httpContextAccessor;
        public StudentService(DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }
        public void Create(Student model)
        {
            var check = _context.Student.Where(x => x.Mssv == model.Mssv || x.AccountId == model.AccountId).FirstOrDefault();
            if(check != default(Student))
            {
                throw new Exception("Tài khoản đã tồn tại!!!");
            }
            var entity = new Student();
            entity.Mssv = model.Mssv;
            entity.NumberOfWork = model.NumberOfWork;
            string data = _httpContextAccessor.HttpContext.Session.GetString("idclass");
            long id = Convert.ToInt64(data);
            entity.ClassId = model.ClassId;
            entity.AccountId = model.AccountId;
            entity.IsDelete = false;
            _context.Student.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Student model)
        {
            var entity = _context.Student.Where(x => x.Id == model.Id).FirstOrDefault();
            if(entity == default)
                throw new Exception("Không tìm thấy dữ liệu!!!");
            entity.IsDelete = true;
            _context.SaveChanges();
        }

        public void Edit(Student model)
        {
            var entity = _context.Student.Where(x => x.Id == model.Id).FirstOrDefault();
            if(entity == default)
                throw new Exception("Không tìm thấy dữ liệu!!!");
            entity.Mssv = model.Mssv;
            entity.NumberOfWork = model.NumberOfWork;            
            string data = _httpContextAccessor.HttpContext.Session.GetString("idclass");
            long id = Convert.ToInt64(data);
            entity.ClassId = model.ClassId;
            entity.AccountId = model.AccountId;
            entity.IsDelete = false;
            _context.Student.Update(entity);
            _context.SaveChanges();
        }

        public List<Student> Get()
        {
            return _context.Student.Include(x => x.Account).Include(x => x.Class).Where(x => x.IsDelete != true).ToList();
        }
        public List<Student> GetClass()
        {
            string data = _httpContextAccessor.HttpContext.Session.GetString("idclass");
            long id = Convert.ToInt64(data);
            //int sum = 0;
            //foreach(int x in _context.Student.Where(x => x.ClassId == id).Select(x=>x.NumberOfWork))
            //{
            //     sum += x;
            //}
            //var entity = new Class();
            //entity.TotalOfWork = sum;  
            
            var student = _context.Student.Include(x => x.Account).Include(x => x.Class).Where(x=>x.ClassId == id).ToList();
            return student;
        }
        public Student GetById(int id)
        {
            return _context.Student.Where(x => x.Id == id).FirstOrDefault();
        }
        public bool StudentExists(long Id)
        {
            return _context.Student.Any(x => x.Id == Id);
        }
        public int CountHT()
        {
            string data = _httpContextAccessor.HttpContext.Session.GetString("idclass");
            string typeofedu = _httpContextAccessor.HttpContext.Session.GetString("typeofedu");
            long id = Convert.ToInt64(data);
            if(typeofedu=="Đại học")
            {
                var datahoanthanh = _context.Student.Where(x => x.ClassId == id && x.NumberOfWork >= 18).ToList();
                return datahoanthanh.Count();
            }
            else
            {
                var dataht = _context.Student.Where(x => x.ClassId == id && x.NumberOfWork >= 12).ToList();
                return dataht.Count();
            }
                
        }
        public int CountSap()
        {
            string data = _httpContextAccessor.HttpContext.Session.GetString("idclass");
            string typeofedu = _httpContextAccessor.HttpContext.Session.GetString("typeofedu");
            long id = Convert.ToInt64(data);
            if (typeofedu == "Đại học")
            {
                var datahoanthanh = _context.Student.Where(x => x.ClassId == id && x.NumberOfWork >10 && x.NumberOfWork<18).ToList();
                return datahoanthanh.Count();
            }
            else
            {
                var dataht = _context.Student.Where(x => x.ClassId == id && x.NumberOfWork >= 6 && x.NumberOfWork<12).ToList();
                return dataht.Count();
            }
        }
        public int CountChua()
        {
            string data = _httpContextAccessor.HttpContext.Session.GetString("idclass");
            string typeofedu = _httpContextAccessor.HttpContext.Session.GetString("typeofedu");
            long id = Convert.ToInt64(data);
            if (typeofedu == "Đại học")
            {
                var datahoanthanh = _context.Student.Where(x => x.ClassId == id && x.NumberOfWork <10).ToList();
                return datahoanthanh.Count();
            }
            else
            {
                var dataht = _context.Student.Where(x => x.ClassId == id && x.NumberOfWork<6).ToList();
                return dataht.Count();
            }
        }
        public float CountLDClass()
        {
            string data = _httpContextAccessor.HttpContext.Session.GetString("idclass");
            long id = Convert.ToInt64(data);
            string typeofedu = _httpContextAccessor.HttpContext.Session.GetString("typeofedu");
            var sslop = _context.Class.Where(x=>x.Id==id).Select(x=>x.Total).FirstOrDefault();
            int ss = Convert.ToInt32(sslop);
            var value = _context.Student.Where(x => x.ClassId == id).Sum(x=>x.NumberOfWork);
            float ngaylaodong = 0;
            if(typeofedu=="Đại học")
            {
                ngaylaodong = ((float)value / (ss * 18)) * 100;
            }
            else
            {
                ngaylaodong = ((float)value / (ss * 12)) * 100;
            }
            return ngaylaodong;
        }


    }
}

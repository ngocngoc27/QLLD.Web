using Microsoft.EntityFrameworkCore;
using QL_LaoDong.Data;
using QL_LaoDong.Interfaces;
using QL_LaoDong.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QL_LaoDong.ViewModels;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace QL_LaoDong.Services
{
    public class AccountService:IAccountService
    {
        public DataContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public AccountService(DataContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
          
        }

        public void Create(Account model)
        {
            var check = _context.Account.Where(x => x.Username == model.Username).FirstOrDefault();
        
            if (check != default(Account))
            {
                throw new Exception("Tài khoản đã tồn tại!!");
            }
            var entity = new Account();
            entity.Username = model.Username;
            if (model.Password != null)
            {
                string pass = model.Password;
                entity.Password = Security.MD5(pass);
            }
            else
            {
                entity.Password = Security.MD5("1234567");
            }
            entity.Fullname = model.Fullname;
            entity.Sex = model.Sex;
            entity.RoleId = model.RoleId;
            entity.DateOfBirth = model.DateOfBirth;
            entity.IsDelete = false;
            entity.Picture = "user225026334.png";
            _context.Account.Add(entity);
            _context.SaveChanges();

        }

        public List<Account> Get()
        {
            return _context.Account.Include(x => x.Role).Where(x => x.IsDelete != true).ToList();
        }
      public List<Account> GetSV()
        {
            var student = _context.Student.Where(x => x.IsDelete != true).Select(x => x.AccountId).FirstOrDefault();

            return _context.Account.Include(x => x.Role).Where(x => x.IsDelete != true && x.Id != student).ToList();
        }
        public void Edit(Account model)
        {
            var entity = _context.Account.Where(x => x.Id == model.Id).FirstOrDefault();
            if (entity == default)
                throw new Exception("Không tìm thấy dữ liệu.");
            var check = _context.Account.Where(x => x.Username == model.Username && x.Id!=model.Id).FirstOrDefault();
            if (check != default)
            {
                throw new Exception("Tài khoản đã tồn tại!!");
            }
            entity.Username = model.Username;
            entity.Sex = model.Sex;
            if (model.Password != null)
            {
                string pass = model.Password;
                entity.Password = Security.MD5(pass);
            }
            else
            {
                entity.Password = entity.Password;
            }
            entity.Fullname = model.Fullname;
            entity.DateOfBirth = model.DateOfBirth;
            entity.RoleId = model.RoleId;
            if (model.ImageFile != null)
            {
                ////Save image to wwwroot/image
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(model.ImageFile.FileName);
                string extension = Path.GetExtension(model.ImageFile.FileName);
                entity.Picture = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRootPath + "/Image/", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    model.ImageFile.CopyToAsync(fileStream);
                }
            }
            else
            {
                entity.Picture = entity.Picture;
            }
            _context.Account.Update(entity);
            _context.SaveChanges();

        }
        public void Delete(Account model)
        {
            var entity = _context.Account.Where(x => x.Id == model.Id).FirstOrDefault();
            if (entity == default)
                throw new Exception("Không tìm thấy dữ liệu.");
            //if (entity.Picture != null)
            //{
            //    var imagePath = Path.Combine(_hostEnvironment.WebRootPath, "image", entity.Picture);
            //    if (System.IO.File.Exists(imagePath))
            //    {
            //        System.IO.File.Delete(imagePath);
            //    }
            //}
            entity.IsDelete = true;
            _context.SaveChanges();
        }
        public Account GetById(int id)
        {
            return _context.Account.Include(x=>x.Role).Where(x => x.Id == id).FirstOrDefault();
        }
        public bool AccountExists(long id)
        {
            return _context.Account.Any(x => x.Id == id);
        }
        public void Lock(Account model)
        {
            var entity = _context.Account.Where(x => x.Id == model.Id).FirstOrDefault();
            if (entity == default)
                throw new Exception("Không tìm thấy dữ liệu.");
            entity.IsDelete = true;
            _context.Account.Update(entity);
            _context.SaveChanges();
        }
        public AppUser Login(Account model)
        {
            var AppUser = new AppUser();

            string pass = model.Password;
            string pas = Security.MD5(pass);
            string user = model.Username;
            try
            {
                var acc = _context.Account.Include(x => x.Role).Where(x => x.Username == user && x.Password == pas).FirstOrDefault();
                if (acc==default)
                    throw new Exception("Tên đăng nhập hoặc mật khẩu không chính xác! Vui lòng nhập lại");
                if (acc.IsDelete != false)
                    throw new Exception("Tài khoản của bạn đã bị khóa! Hãy liên hệ quản trị viên");
                if (acc != default)
                {
                    var query = from students in _context.Student
                                join classes in _context.Class on students.ClassId equals classes.Id
                                where students.AccountId == acc.Id
                                select new AppUser()
                                {
                                    AccountId = acc.Id,
                                    Username = acc.Username,
                                    FullName = acc.Fullname,
                                    RoleId = acc.Role.Id,
                                    RoleName = acc.Role.NameRole,
                                    ClassId = classes.Id,
                                    ClassName = classes.ClassName,
                                    Total = classes.Total,
                                    TotalOfWork=classes.TotalOfWork,
                                    NumberWork=students.NumberOfWork,
                                    TypeofEdu=classes.TypeOfEducation
                                    
                                };
                    AppUser = query.FirstOrDefault();
                }
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            return AppUser;
        }
        public Profile Details(long id)
        {
            var Profile = new Profile();
            var query = from students in _context.Student
                        join classes in _context.Class on students.ClassId equals classes.Id
                        join account in _context.Account on students.AccountId equals account.Id
                        join role in _context.Role on account.RoleId equals role.Id
                        join faculty in _context.Faculty on classes.FacultyId equals faculty.Id
                        where students.AccountId == id
                        select new Profile()
                        {
                            Picture = account.Picture,
                            Mssv = students.Mssv,
                            FullName = account.Fullname,
                            DateOfBirth = account.DateOfBirth,
                            Sex = account.Sex,
                            RoleName = role.NameRole,
                            ClassName = classes.ClassName,
                            Training = classes.Training,
                            TypeOfEducation = classes.TypeOfEducation,
                            FacultyName = faculty.FacultyName,
                            NumberOfWork = students.NumberOfWork
                        };
            Profile = query.FirstOrDefault();
            return Profile;
        }
        public void ChangePass(Account model, int id)
        {
            var entity = _context.Account.Where(x => x.Id == id).FirstOrDefault();
            if (entity == default)
                throw new Exception("Không tìm thấy dữ liệu.");
            string pass = model.Password;
            entity.Password = Security.MD5(pass);
            _context.SaveChanges();

        }
        public void EditInfo(Account model, int id)
        {
            var entity = _context.Account.Where(x => x.Id == id).FirstOrDefault();
            if (entity == default)
                throw new Exception("Không tìm thấy dữ liệu.");
            entity.Username = model.Username;
            var check = _context.Account.Where(x => x.Username == model.Username && x.Id != model.Id).FirstOrDefault();
            if (check != default)
                throw new Exception("Tên đăng nhập đã tồn tại");
            entity.Sex = model.Sex;
            entity.Fullname = model.Fullname;
            entity.DateOfBirth = model.DateOfBirth;
            _context.SaveChanges();
        }


    }
}

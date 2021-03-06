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
    public class WorkTickerService : IWorkTickerService
    {
        public DataContext _context;
        private IHttpContextAccessor _httpContextAccessor;
        public WorkTickerService(DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }
        public void Create(Workticker model)
        {
            var entity = new Workticker();
            var number_data = _context.Calendar.Include(x=>x.Workticker).Where(x=>x.Id==model.Id).FirstOrDefault();
            entity.CalendarId = model.Id;
            entity.Note = model.Note;

            string data = _httpContextAccessor.HttpContext.Session.GetString("id");
            int id = Convert.ToInt32(data);
            entity.AccountId = id;

            entity.Status = (int) WorkTickerEnum.ChoDuyet;
            entity.RegistrationForm = model.RegistrationForm;
            
            string total = _httpContextAccessor.HttpContext.Session.GetString("total");
            int num = Convert.ToInt32(total);
            
            if (entity.RegistrationForm == "Cá nhân")
                entity.RegistrationNumber = 1; //gán số lượng là một
            else if (entity.RegistrationForm == "Lớp")
                entity.RegistrationNumber = num; //lấy sỉ số lớp của session
            number_data.RegistrationTotal += Convert.ToInt32(entity.RegistrationNumber);

            _context.Workticker.Add(entity);
            _context.SaveChanges();
        }
        
        public void Delete(Workticker model)
        {
            var entity = _context.Workticker.Where(x => x.Id == model.Id && x.Status != (int)WorkTickerEnum.DaDuyet).FirstOrDefault();
            if(entity == default)
                throw new Exception("Không tìm thấy dữ liệu!!!");
            entity.IsDelete = true;
            _context.SaveChanges();
        }

        public void Edit(Workticker model)
        {
            var entity = _context.Workticker.Include(x=>x.Calendar).Where(x => x.Id == model.Id).FirstOrDefault();
            if(entity == default)
                throw new Exception("Không tìm thấy dữ liệu!!!");
            entity.Status = model.Status;
            entity.Note = model.Note;
            if (entity.Status == (int)WorkTickerEnum.DaHuy)
                entity.Calendar.RegistrationTotal -= Convert.ToInt32(entity.RegistrationNumber);
            if (entity.Calendar.RegistrationTotal >= entity.Calendar.LimitsNumber)
                entity.Calendar.Status = (int)CalendarEnum.KhoaDangKy;
            else entity.Calendar.Status = (int)CalendarEnum.ChoPhepDangKy;
            _context.Workticker.Update(entity);
            _context.SaveChanges();
        }

        public void Cancle(Workticker model)
        {
            var entity = _context.Workticker.Include(x => x.Calendar).Where(x => x.Id == model.Id).FirstOrDefault();
            if (entity == default)
                throw new Exception("Không tìm thấy dữ liệu!!!");
            entity.Status = (int)WorkTickerEnum.BaoBan;
            entity.Note = model.Note;
            _context.Workticker.Update(entity);
            _context.SaveChanges();
        }
        public List<Calendar> GetCalendar()
        {
            return _context.Calendar.Where(x => x.IsDelete != true && x.Status == (int)CalendarEnum.ChoPhepDangKy).ToList();
        }
        public List<Workticker> Get()
        {
            string data = _httpContextAccessor.HttpContext.Session.GetString("id");
            int id = Convert.ToInt32(data);
            return _context.Workticker.Include(x=>x.Calendar).Include(x => x.Account).Where(x=>x.AccountId==id && x.IsDelete != true).ToList();
        }
        public List<Workticker> PageWorkTicker(long id)
        {
            return _context.Workticker.Include(x => x.Calendar).Include(x => x.Account).Where(x => x.CalendarId == id && x.IsDelete != true).ToList();
        }
        public Workticker GetById(int id)
        {
            return _context.Workticker.Include(x=>x.Calendar).Where(x => x.Id == id).FirstOrDefault();
        }
        public bool TickerExists(long id)
        {
            return _context.Workticker.Any(x => x.Id == id);
        }
        /*-----------------------------------------------------------*/
        public List<StudentVM> GetStudent(long id)
        {
            var data = new List<StudentVM>();
            var worktickers = _context.Workticker.Include(x => x.Calendar).Include(x => x.Account.Student)
                        .Where(x => x.CalendarId == id && x.Status == (int)WorkTickerEnum.DaDuyet).ToList();

            foreach (var wtk in worktickers)
            {
                if(wtk.RegistrationForm == "Cá nhân")
                {
                    var student = _context.Student.Include(x => x.Class).Include(x => x.Account)
                        .Where(x => x.AccountId == wtk.AccountId && x.IsDelete != true)
                        .Select(x => new StudentVM()
                        {
                            StudentId = x.Id,
                            Mssv = x.Mssv,
                            Fullname = x.Account != default ? x.Account.Fullname : "",
                            ClassName = x.Class != default ? x.Class.ClassName : "",
                        })
                        .FirstOrDefault();
                    if(student != default)
                    {
                        data.Add(student);
                    }
                }
                else
                {
                    var student = _context.Student.Include(x => x.Class).Include(x => x.Account)
                         .Where(x => x.AccountId == wtk.AccountId && x.IsDelete != true)
                         .FirstOrDefault();
                    if(student != default)
                    {
                        var students = _context.Student.Include(x => x.Class).Include(x => x.Account)
                             .Where(x => x.ClassId == student.ClassId && x.IsDelete != true)
                             .Select(x => new StudentVM()
                             {
                                 StudentId = x.Id,
                                 Mssv = x.Mssv,
                                 Fullname = x.Account != default ? x.Account.Fullname : "",
                                 ClassName = x.Class != default ? x.Class.ClassName : "",
                             })
                             .Distinct()
                             .ToList();
                        if(students.Count > 0)
                        {
                            data.AddRange(students);
                        }
                    }
                }
            }
            return data;
        }
        public int CountsDS()
        {
            var data = _context.Workticker.Where(x => x.IsDelete != true).ToList();
            return data.Count();
        }
        public int CountTT()
        {
            var data = _context.Workticker.Where(x => x.IsDelete != true && x.Status == (int)WorkTickerEnum.DaDuyet).ToList();
            return data.Count();
        }
        public int CountBan()
        {
            var data = _context.Workticker.Where(x => x.IsDelete != true && x.Status == (int)WorkTickerEnum.BaoBan).ToList();
            return data.Count();
        }
        public int Choduyet()
        {
            var data = _context.Workticker.Where(x => x.IsDelete != true && x.Status == (int)WorkTickerEnum.ChoDuyet).ToList();
            return data.Count();
        }
        public int CountDK()
        {
            string data = _httpContextAccessor.HttpContext.Session.GetString("id");
            int id = Convert.ToInt32(data);
            var value= _context.Workticker.Include(x => x.Calendar).Include(x => x.Account).Where(x => x.AccountId == id && x.IsDelete != true).ToList();
            return value.Count();
        }
        public int CountDuyet()
        {
            string data = _httpContextAccessor.HttpContext.Session.GetString("id");
            int id = Convert.ToInt32(data);
            var value = _context.Workticker.Include(x => x.Calendar).Include(x => x.Account).Where(x => x.AccountId == id && x.IsDelete != true && x.Status == (int)WorkTickerEnum.DaDuyet).ToList();
            return value.Count();
        }
        public int CountCho()
        {
            string data = _httpContextAccessor.HttpContext.Session.GetString("id");
            int id = Convert.ToInt32(data);
            var value = _context.Workticker.Include(x => x.Calendar).Include(x => x.Account).Where(x => x.AccountId == id && x.IsDelete != true && x.Status == (int)WorkTickerEnum.ChoDuyet).ToList();
            return value.Count();
        }
        public int CountBban()
        {
            string data = _httpContextAccessor.HttpContext.Session.GetString("id");
            int id = Convert.ToInt32(data);
            var value = _context.Workticker.Include(x => x.Calendar).Include(x => x.Account).Where(x => x.AccountId == id && x.IsDelete != true && x.Status == (int)WorkTickerEnum.BaoBan).ToList();
            return value.Count();
        }
        public int CountHuy()
        {
            string data = _httpContextAccessor.HttpContext.Session.GetString("id");
            int id = Convert.ToInt32(data);
            var value = _context.Workticker.Include(x => x.Calendar).Include(x => x.Account).Where(x => x.AccountId == id && x.IsDelete != true && x.Status == (int)WorkTickerEnum.DaHuy).ToList();
            return value.Count();
        }
    }
}

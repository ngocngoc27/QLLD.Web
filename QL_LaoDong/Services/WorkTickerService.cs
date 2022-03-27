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

            
            _context.Workticker.Add(entity);
            _context.SaveChanges();
        }
        public void CreateGroups(Groups model)
        {
            var entity = new Groups();
            entity.Leader = model.Leader;
            entity.GroupsName = model.GroupsName;
            entity.JobId = model.JobId;
            entity.IsDelete = false;
            entity.Status = (int)GroupsEnum.ChuaDiemDanh;
            _context.Groups.Add(entity);
            _context.SaveChanges();
        }
        public void Delete(Workticker model)
        {
            var entity = _context.Workticker.Where(x => x.Id == model.Id && x.Status != (int)WorkTickerEnum.DaDuyet).FirstOrDefault();
            if(entity == default)
                throw new Exception("Không tìm thấy dữ liệu!!!");
            _context.Workticker.Remove(entity);
            _context.SaveChanges();
        }

        public void Edit(Workticker model)
        {
            var entity = _context.Workticker.Include(x=>x.Calendar).Where(x => x.Id == model.Id).FirstOrDefault();
            if(entity == default)
                throw new Exception("Không tìm thấy dữ liệu!!!");
            entity.Status = model.Status;
            entity.Note = model.Note;
            if (entity.Status == (int)WorkTickerEnum.DaDuyet)
                entity.Calendar.RegistrationTotal += Convert.ToInt32(entity.RegistrationNumber);
            if (entity.Calendar.RegistrationTotal >= entity.Calendar.LimitsNumber)
                entity.Calendar.Status = (int)CalendarEnum.HetLuotDangKy;
            _context.Workticker.Update(entity);
            _context.SaveChanges();
        }
        public void Cancle(Workticker model)
        {
            var entity = _context.Workticker.Include(x => x.Calendar).Where(x => x.Id == model.Id).FirstOrDefault();
            if (entity == default)
                throw new Exception("Không tìm thấy dữ liệu!!!");
            entity.Status = model.Status;
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
            return _context.Workticker.Include(x=>x.Calendar).Include(x => x.Account).ToList();
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
        public List<Workticker> GetSundayAfter()
        {
            return _context.Workticker.Include(x => x.Calendar).Include(x => x.Account).Where(x => x.Calendar.SessionOfDay == "Chiều" && x.Calendar.Weekdays == "Chủ nhật" && x.Status == 2).ToList();
        }
        public List<Workticker> GetSundayMor()
        {
            return _context.Workticker.Include(x => x.Calendar).Include(x => x.Account).Where(x => x.Calendar.SessionOfDay == "Sáng" && x.Calendar.Weekdays == "Chủ nhật" && x.Status == 2).ToList();
        }
        public List<Workticker> GetMondayAfter()
        {
            return _context.Workticker.Include(x => x.Calendar).Include(x => x.Account).Where(x => x.Calendar.SessionOfDay == "Chiều" && x.Calendar.Weekdays == "Thứ hai" && x.Status == 2).ToList();
        }
        public List<Workticker> GetMondayMor()
        {
            return _context.Workticker.Include(x => x.Calendar).Include(x => x.Account).Where(x => x.Calendar.SessionOfDay == "Sáng" && x.Calendar.Weekdays == "Thứ hai" && x.Status == 2).ToList();
        }
        public List<Workticker> GetTuesdayAfter()
        {
            return _context.Workticker.Include(x => x.Calendar).Include(x => x.Account).Where(x => x.Calendar.SessionOfDay == "Chiều" && x.Calendar.Weekdays == "Thứ ba" && x.Status == 2).ToList();
        }
        public List<Workticker> GetTuesdayMor()
        {
            return _context.Workticker.Include(x => x.Calendar).Include(x => x.Account).Where(x => x.Calendar.SessionOfDay == "Sáng" && x.Calendar.Weekdays == "Thứ ba" && x.Status == 2).ToList();
        }
        public List<Workticker> GetWednesdayAfter()
        {
            return _context.Workticker.Include(x => x.Calendar).Include(x => x.Account).Where(x => x.Calendar.SessionOfDay == "Chiều" && x.Calendar.Weekdays == "Thứ tư" && x.Status == 2).ToList();
        }
        public List<Workticker> GetWednesdayMor()
        {
            return _context.Workticker.Include(x => x.Calendar).Include(x => x.Account).Where(x => x.Calendar.SessionOfDay == "Sáng" && x.Calendar.Weekdays == "Thứ tư" && x.Status == 2).ToList();
        }
        public List<Workticker> GetThursdayAfter()
        {
            return _context.Workticker.Include(x => x.Calendar).Include(x => x.Account).Where(x => x.Calendar.SessionOfDay == "Chiều" && x.Calendar.Weekdays == "Thứ năm" && x.Status == 2).ToList();
        }
        public List<Workticker> GetThursdayMor()
        {
            return _context.Workticker.Include(x => x.Calendar).Include(x => x.Account).Where(x => x.Calendar.SessionOfDay == "Sáng" && x.Calendar.Weekdays == "Thứ năm" && x.Status == 2).ToList();
        }
        public List<Workticker> GetFridayAfter()
        {
            return _context.Workticker.Include(x => x.Calendar).Include(x => x.Account).Where(x => x.Calendar.SessionOfDay == "Chiều" && x.Calendar.Weekdays == "Thứ sáu" && x.Status == 2).ToList();
        }
        public List<Workticker> GetFridayMor()
        {
            return _context.Workticker.Include(x => x.Calendar).Include(x => x.Account).Where(x => x.Calendar.SessionOfDay == "Sáng" && x.Calendar.Weekdays == "Thứ sáu" && x.Status == 2).ToList();
        }
        public List<Workticker> GetSaturdayAfter()
        {
            return _context.Workticker.Include(x => x.Calendar).Include(x => x.Account).Where(x => x.Calendar.SessionOfDay == "Chiều" && x.Calendar.Weekdays == "Thứ bảy" && x.Status == 2).ToList();
        }
        public List<Workticker> GetSaturdayMor()
        {
            return _context.Workticker.Include(x => x.Calendar).Include(x => x.Account).Where(x => x.Calendar.SessionOfDay == "Sáng" && x.Calendar.Weekdays == "Thứ bảy" && x.Status == 2).ToList();
        }
    }
}

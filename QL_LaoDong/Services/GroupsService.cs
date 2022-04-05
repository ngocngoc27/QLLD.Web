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
    public class GroupsService : IGroupsService
    {
        public DataContext _context;
        private IHttpContextAccessor _httpContextAccessor;
        public GroupsService(DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }
        public void Delete(Groups model)
        {
            var entity = _context.Groups.Where(x => x.Id == model.Id).FirstOrDefault();
            if (entity == default)
                throw new Exception("Không tìm thấy dữ liệu.");
            entity.IsDelete = true;
            _context.SaveChanges();
        }
        public void CreateGroups(Groups model, long caid)
        {
            var entity = new Groups();
            entity.Leader = model.Leader;
            entity.CalendarId = caid;
            entity.GroupsName = model.GroupsName;
            entity.JobId = model.JobId;
            entity.IsDelete = false;
            entity.Status = model.Status;
            _context.Groups.Add(entity);
            _context.SaveChanges();
        }
        public void Edit(Groups model)
        {
            var entity = _context.Groups.Where(x => x.Id == model.Id).FirstOrDefault();
            if (entity == default)
                throw new Exception("Không tìm thấy dữ liệu.");
            entity.GroupsName = model.GroupsName;
            entity.JobId = model.JobId;
            entity.Leader = model.Leader;
            entity.Status = model.Status;
            _context.Groups.Update(entity);
            _context.SaveChanges();
        }

        public List<Groups> PageGroups(long id)
        {
            return _context.Groups.Include(x => x.Calendar).Include(x => x.Job).Include(x => x.Muster).Where(x => x.CalendarId == id && x.IsDelete != true).ToList();
        }
        public Groups GetById(long id)
        {
            return _context.Groups.Include(x => x.Toolticker).Include(x => x.Calendar).Include(x => x.Muster).Include(x => x.Job).Where(x => x.Id == id).FirstOrDefault();
        }
        public bool GroupsExists(long id)
        {
            return _context.Groups.Any(x => x.Id == id);
        }
        public int CountGrChuaSV()
        {
            var data = _context.Groups.Where(x => x.IsDelete != true && x.Status == (int)GroupsEnum.ChuaCoSinhVien).ToList();
            return data.Count();
        }
        public int CountGrChuaDD()
        {
            var data = _context.Groups.Where(x => x.IsDelete != true && x.Status == (int)GroupsEnum.ChuaDiemDanh).ToList();
            return data.Count();
        }
        public int CountGr()
        {
            var data = _context.Groups.Where(x => x.IsDelete != true).ToList();
            return data.Count();
        }
        /*===============================================================*/
        public List<Groups> GetSundayAfter()
        {
            return _context.Groups.Include(x => x.Job).Include(x => x.Toolticker).Include(x => x.Calendar).Include(x => x.Muster).Where(x => x.Calendar.SessionOfDay == "Chiều" && x.Calendar.Weekdays == "Chủ nhật" && x.Status == (int)GroupsEnum.ChuaDiemDanh && x.IsDelete != true).ToList();
        }
        public List<Groups> GetSundayMor()
        {
            return _context.Groups.Include(x => x.Job).Include(x => x.Toolticker).Include(x => x.Calendar).Include(x => x.Muster).Where(x => x.Calendar.SessionOfDay == "Sáng" && x.Calendar.Weekdays == "Chủ nhật" && x.Status == (int)GroupsEnum.ChuaDiemDanh && x.IsDelete != true).ToList();
        }
        public List<Groups> GetMondayAfter()
        {
            return _context.Groups.Include(x => x.Job).Include(x => x.Toolticker).Include(x => x.Calendar).Include(x => x.Muster).Where(x => x.Calendar.SessionOfDay == "Chiều" && x.Calendar.Weekdays == "Thứ hai" && x.Status == (int)GroupsEnum.ChuaDiemDanh && x.IsDelete != true).ToList();
        }
        public List<Groups> GetMondayMor()
        {
            return _context.Groups.Include(x => x.Job).Include(x => x.Toolticker).Include(x => x.Calendar).Include(x => x.Muster).Where(x => x.Calendar.SessionOfDay == "Sáng" && x.Calendar.Weekdays == "Thứ hai" && x.Status == (int)GroupsEnum.ChuaDiemDanh && x.IsDelete != true).ToList();
        }
        public List<Groups> GetTuesdayAfter()
        {
            return _context.Groups.Include(x => x.Job).Include(x => x.Toolticker).Include(x => x.Calendar).Include(x => x.Muster).Where(x => x.Calendar.SessionOfDay == "Chiều" && x.Calendar.Weekdays == "Thứ ba" && x.Status == (int)GroupsEnum.ChuaDiemDanh && x.IsDelete != true).ToList();
        }
        public List<Groups> GetTuesdayMor()
        {
            return _context.Groups.Include(x => x.Job).Include(x => x.Toolticker).Include(x => x.Calendar).Include(x => x.Muster).Where(x => x.Calendar.SessionOfDay == "Sáng" && x.Calendar.Weekdays == "Thứ ba" && x.Status == (int)GroupsEnum.ChuaDiemDanh && x.IsDelete != true).ToList();
        }
        public List<Groups> GetWednesdayAfter()
        {
            return _context.Groups.Include(x => x.Job).Include(x => x.Toolticker).Include(x => x.Calendar).Include(x => x.Muster).Where(x => x.Calendar.SessionOfDay == "Chiều" && x.Calendar.Weekdays == "Thứ tư" && x.Status == (int)GroupsEnum.ChuaDiemDanh && x.IsDelete != true).ToList();
        }
        public List<Groups> GetWednesdayMor()
        {
            return _context.Groups.Include(x => x.Job).Include(x => x.Toolticker).Include(x => x.Calendar).Include(x => x.Muster).Where(x => x.Calendar.SessionOfDay == "Sáng" && x.Calendar.Weekdays == "Thứ tư" && x.Status == (int)GroupsEnum.ChuaDiemDanh && x.IsDelete != true).ToList();
        }
        public List<Groups> GetThursdayAfter()
        {
            return _context.Groups.Include(x => x.Job).Include(x => x.Toolticker).Include(x => x.Calendar).Include(x => x.Muster).Where(x => x.Calendar.SessionOfDay == "Chiều" && x.Calendar.Weekdays == "Thứ năm" && x.Status == (int)GroupsEnum.ChuaDiemDanh && x.IsDelete != true).ToList();
        }
        public List<Groups> GetThursdayMor()
        {
            return _context.Groups.Include(x => x.Job).Include(x => x.Toolticker).Include(x => x.Calendar).Include(x => x.Muster).Where(x => x.Calendar.SessionOfDay == "Sáng" && x.Calendar.Weekdays == "Thứ năm" && x.Status == (int)GroupsEnum.ChuaDiemDanh && x.IsDelete != true).ToList();
        }
        public List<Groups> GetFridayAfter()
        {
            return _context.Groups.Include(x => x.Job).Include(x => x.Toolticker).Include(x => x.Calendar).Include(x => x.Muster).Where(x => x.Calendar.SessionOfDay == "Chiều" && x.Calendar.Weekdays == "Thứ sáu" && x.Status == (int)GroupsEnum.ChuaDiemDanh && x.IsDelete != true).ToList();
        }
        public List<Groups> GetFridayMor()
        {
            return _context.Groups.Include(x => x.Job).Include(x => x.Toolticker).Include(x => x.Calendar).Include(x => x.Muster).Where(x => x.Calendar.SessionOfDay == "Sáng" && x.Calendar.Weekdays == "Thứ sáu" && x.Status == (int)GroupsEnum.ChuaDiemDanh && x.IsDelete != true).ToList();
        }
        public List<Groups> GetSaturdayAfter()
        {
            return _context.Groups.Include(x => x.Job).Include(x => x.Toolticker).Include(x => x.Calendar).Include(x => x.Muster).Where(x => x.Calendar.SessionOfDay == "Chiều" && x.Calendar.Weekdays == "Thứ bảy" && x.Status == (int)GroupsEnum.ChuaDiemDanh && x.IsDelete != true).ToList();
        }
        public List<Groups> GetSaturdayMor()
        {
            return _context.Groups.Include(x => x.Job).Include(x => x.Toolticker).Include(x => x.Calendar).Include(x => x.Muster).Where(x => x.Calendar.SessionOfDay == "Sáng" && x.Calendar.Weekdays == "Thứ bảy" && x.Status == (int)GroupsEnum.ChuaDiemDanh && x.IsDelete != true).ToList();
        }
    }
}

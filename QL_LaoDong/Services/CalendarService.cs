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
    public class CalendarService : ICalendarService
    {
        public DataContext _context;
        public CalendarService(DataContext context)
        {
            _context = context;
        }
        public void Create(Calendar model)
        {          
            var entity = new Calendar();
            entity.SessionOfDay = model.SessionOfDay;
            entity.Day = model.Day;
            var days =Convert.ToDateTime( model.Day);
            DayOfWeek week = days.DayOfWeek;
            var thu = "";
            if (week == DayOfWeek.Monday)
            {
                thu = "Thứ hai";
            }
            else if (week == DayOfWeek.Tuesday)
            {
                thu = "Thứ ba";
            }
            else if (week == DayOfWeek.Wednesday)
            {
                thu = "Thứ tư";
            }
            else if (week == DayOfWeek.Thursday)
            {
                thu = "Thứ năm";
            }
            else if (week == DayOfWeek.Friday)
            {
                thu = "Thứ sáu";
            }
            else if (week == DayOfWeek.Saturday)
            {
                thu = "Thứ bảy";
            }
            else if (week == DayOfWeek.Sunday)
            {
                thu = "Chủ nhật";
            }
            //var thu = Convert.ToString(week);
            entity.Weekdays = thu;
            entity.LimitsNumber = model.LimitsNumber;
            entity.RegistrationTotal = 0;
            entity.Status = (int)CalendarEnum.ChoPhepDangKy; 
            entity.IsDelete = false;
            _context.Calendar.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Calendar model)
        {
            var entity = _context.Calendar.Where(x => x.Id == model.Id).FirstOrDefault();
            if (entity == default)
                throw new Exception("Không tìm thấy dữ liệu.");
            entity.IsDelete = true;
            _context.SaveChanges();
        }

        public void Edit(Calendar model)
        {
            var entity = _context.Calendar.Where(x => x.Id == model.Id).FirstOrDefault();
            if (entity == default)
                throw new Exception("Không tìm thấy dữ liệu.");
            entity.SessionOfDay = model.SessionOfDay;
            entity.Day = model.Day;
            DayOfWeek week = Convert.ToDateTime(model.Day).DayOfWeek;
            var thu = "";
            if (week == DayOfWeek.Monday)
            {
                thu = "Thứ hai";
            }
            else if (week == DayOfWeek.Tuesday)
            {
                thu = "Thứ ba";
            }
            else if (week == DayOfWeek.Wednesday)
            {
                thu = "Thứ tư";
            }
            else if (week == DayOfWeek.Thursday)
            {
                thu = "Thứ năm";
            }
            else if (week == DayOfWeek.Friday)
            {
                thu = "Thứ sáu";
            }
            else if (week == DayOfWeek.Saturday)
            {
                thu = "Thứ bảy";
            }
            else if (week == DayOfWeek.Sunday){
                thu = "Chủ nhật";
            }
            //var thu = Convert.ToString(week);
            entity.Weekdays = thu;
            entity.LimitsNumber = model.LimitsNumber;
            entity.Status = model.Status;
            _context.Calendar.Update(entity);
            _context.SaveChanges();
        }

        public List<Calendar> Get()
        {
            return _context.Calendar.Where(x => x.IsDelete != true).ToList();
        }
        public Calendar GetById(long id)
        {
            return _context.Calendar.Where(x => x.Id == id).FirstOrDefault();
        }
        public bool CalendarExists(long id)
        {
            return _context.Calendar.Any(x => x.Id == id);
        }        
    }
}

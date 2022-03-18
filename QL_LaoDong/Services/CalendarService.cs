﻿using QL_LaoDong.Data;
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
            var thu = Convert.ToString(week);
            entity.Weekdays = thu;
            _context.Calendar.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Calendar model)
        {
            var entity = _context.Calendar.Where(x => x.Id == model.Id).FirstOrDefault();
            if (entity == default)
                throw new Exception("Không tìm thấy dữ liệu.");

            _context.Calendar.Remove(entity);
            _context.SaveChanges();
        }

        public void Edit(Calendar model)
        {
            var entity = _context.Calendar.Where(x => x.Id == model.Id).FirstOrDefault();
            if (entity == default)
                throw new Exception("Không tìm thấy dữ liệu.");
            entity.SessionOfDay = model.SessionOfDay;
            entity.Day = model.Day;
            var days = Convert.ToDateTime(model.Day);
            DayOfWeek week = days.DayOfWeek;
            var thu = Convert.ToString(week);
            entity.Weekdays = thu;
            _context.Calendar.Update(entity);
            _context.SaveChanges();
        }

        public List<Calendar> Get()
        {
            return _context.Calendar.ToList();
        }

        public Calendar GetById(int id)
        {
            return _context.Calendar.Where(x => x.Id == id).FirstOrDefault();
        }
        public bool CalendarExists(long id)
        {
            return _context.Calendar.Any(x => x.Id == id);
        }
    }
}

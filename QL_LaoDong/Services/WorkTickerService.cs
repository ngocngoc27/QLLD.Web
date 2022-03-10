using QL_LaoDong.Data;
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
        public WorkTickerService(DataContext context)
        {
            _context = context;
        }
        public void Create(Workticker model)
        {
            var entity = new Workticker();
            entity.CalendarId = model.CalendarId;
            entity.JobId = model.JobId;
            entity.Status = model.Status;
            _context.Workticker.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Workticker model)
        {
            var entity = _context.Workticker.Where(x => x.Id == model.Id).FirstOrDefault();
            if(entity == default)
                throw new Exception("Không tìm thấy dữ liệu!!!");
            _context.Workticker.Remove(entity);
            _context.SaveChanges();
        }

        public void Edit(Workticker model)
        {
            var entity = _context.Workticker.Where(x => x.Id == model.Id).FirstOrDefault();
            if(entity == default)
                throw new Exception("Không tìm thấy dữ liệu!!!");
            entity.CalendarId = model.CalendarId;
            entity.JobId = model.JobId;
            entity.Status = model.Status;
            _context.Workticker.Update(entity);
            _context.SaveChanges();
        }

        public List<Workticker> Get()
        {
            return _context.Workticker.ToList();
        }

        public Workticker GetById(int id)
        {
            return _context.Workticker.Where(x => x.Id == id).FirstOrDefault();
        }
    }
}

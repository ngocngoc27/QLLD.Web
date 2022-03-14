using QL_LaoDong.Data;
using QL_LaoDong.Interfaces;
using QL_LaoDong.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QL_LaoDong.Services
{
    public class JobService : IJobService
    {
        public DataContext _context;
        public JobService(DataContext context)
        {
            _context = context;
        }
        public void Create(Job model)
        {
            var entity = new Job();
            entity.Job1 = model.Job1;
            entity.Description = model.Description;
            entity.Locate = model.Locate;
            entity.Lock = false;
            _context.Job.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Job model)
        {
            var entity = _context.Job.Where(x => x.Id == model.Id).FirstOrDefault();
            if (entity == default)
                throw new Exception("Không tìm thấy dữ liệu.");

            _context.Job.Remove(entity);
            _context.SaveChanges();
        }

        public void Edit(Job model)
        {
            var entity = _context.Job.Where(x => x.Id == model.Id).FirstOrDefault();
            if (entity == default)
                throw new Exception("Không tìm thấy dữ liệu.");
            entity.Job1 = model.Job1;
            entity.Description = model.Description;
            entity.Locate = model.Locate;
            entity.Lock = model.Lock;
            _context.Job.Update(entity);
            _context.SaveChanges();
        }

        public List<Job> Get()
        {
            return _context.Job.Where(x=>x.Lock!=true).ToList();
        }

        public Job GetById(int id)
        {
            return _context.Job.Where(x => x.Id == id).FirstOrDefault();
        }
        public void Lock(Job model)
        {
            var entity = _context.Job.Where(x => x.Id == model.Id).FirstOrDefault();
            if (entity == default)
                throw new Exception("Không tìm thấy dữ liệu.");
            entity.Lock = true;
            _context.Job.Update(entity);
            _context.SaveChanges();
        }
        public bool JobExists(long id)
        {
            return _context.Job.Any(x => x.Id == id);
        }
    }
}

using QL_LaoDong.Data;
using QL_LaoDong.Interfaces;
using QL_LaoDong.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QL_LaoDong.Services
{
    public class MusterService : IMusterService
    {
        public DataContext _context;
        public MusterService(DataContext context)
        {
            _context = context;
        }
        public void Create(Muster model)
        {
            var entity = new Muster();
            entity.WorkTickerId = model.WorkTickerId;
            entity.AccountId = model.AccountId;
            entity.Present = model.Present;
            entity.Status = model.Status;
            _context.Muster.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Muster model)
        {
            var entity = _context.Muster.Where(x => x.Id == model.Id).FirstOrDefault();
            if (entity == default)
                throw new Exception("Không tìm thấy dữ liệu.");

            _context.Muster.Remove(entity);
            _context.SaveChanges();
        }

        public void Edit(Muster model)
        {
            var entity = _context.Muster.Where(x => x.Id == model.Id).FirstOrDefault();
            if (entity == default)
                throw new Exception("Không tìm thấy dữ liệu.");
            entity.WorkTickerId = model.WorkTickerId;
            entity.AccountId = model.AccountId;
            entity.Present = model.Present;
            entity.Status = model.Status;
            _context.Muster.Update(entity);
            _context.SaveChanges();
        }

        public List<Muster> Get()
        {
            return _context.Muster.ToList();
        }

        public Muster GetById(int id)
        {
            return _context.Muster.Where(x => x.Id == id).FirstOrDefault();
        }
    }
}

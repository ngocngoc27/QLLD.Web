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
    public class MusterService : IMusterService
    {
        public DataContext _context;
        public MusterService(DataContext context)
        {
            _context = context;
        }
        public void AddStudent(Muster model, long id)
        {
            var entity = new Muster();
            entity.StudentId = model.Id;
            entity.GroupsId = id;
            entity.IsDelete = false;
            //entity.Groups.Status = (int)GroupsEnum.ChuaDiemDanh;
            _context.Muster.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Muster model)
        {
            var entity = _context.Muster.Where(x => x.Id == model.Id).FirstOrDefault();
            if (entity == default)
                throw new Exception("Không tìm thấy dữ liệu.");
            entity.IsDelete = true;
            _context.SaveChanges();
        }

        public void Edit(Muster model)
        {
            var entity = _context.Muster.Where(x => x.Id == model.Id).FirstOrDefault();
            if (entity == default)
                throw new Exception("Không tìm thấy dữ liệu.");
            entity.StudentId = model.StudentId;
            entity.GroupsId = model.GroupsId;
            entity.RollUp = model.RollUp;
            //logic cộng ngày lao động khi check điểm danh
            if (entity.RollUp == true)
                entity.Student.NumberOfWork += entity.Groups.Job.BenefitOfDay;
            _context.Muster.Update(entity);
            _context.SaveChanges();
        }

        public List<Muster> Get()
        {
            return _context.Muster.Include(x=>x.Student).Include(x => x.Groups).Where(x => x.IsDelete != true).ToList();
        }
        public List<Muster> PageMuster(long id)
        {
            return _context.Muster.Include(x => x.Student).Include(x => x.Groups).Where(x => x.GroupsId == id && x.IsDelete != true).ToList();
        }
        public Muster GetById(int id)
        {
            return _context.Muster.Where(x => x.Id == id).FirstOrDefault();
        }
        public void Diemdanh(List<Muster> model)
        {
            foreach(var item in model)
            {
                var entity = _context.Muster.Where(x => x.StudentId == item.StudentId && x.IsDelete != true).FirstOrDefault();
                if(entity!=default)
                {
                    entity.RollUp = item.RollUp;
                }
                _context.SaveChanges();
            }
        }
    
    }
}

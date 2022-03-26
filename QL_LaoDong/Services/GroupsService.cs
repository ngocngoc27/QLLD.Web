using Microsoft.EntityFrameworkCore;
using QL_LaoDong.Data;
using QL_LaoDong.Interfaces;
using QL_LaoDong.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QL_LaoDong.Services
{
    public class GroupsService : IGroupsService
    {
        public DataContext _context;
        public GroupsService(DataContext context)
        {
            _context = context;
        }
        public void Create(Groups model)
        {
            var entity = new Groups();
            entity.GroupsName = model.GroupsName;
            entity.JobId = model.JobId;
            entity.Leader = model.Leader;
            entity.Status = model.Status;
            entity.WorkTickerId = model.WorkTickerId;
            entity.IsDelete = false;
            _context.Groups.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Groups model)
        {
            var entity = _context.Groups.Where(x => x.Id == model.Id).FirstOrDefault();
            if (entity == default)
                throw new Exception("Không tìm thấy dữ liệu.");

            _context.Groups.Remove(entity);
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

        public List<Groups> Get()
        {
            return _context.Groups.Include(x => x.WorkTicker.Calendar).Include(x=>x.Job).Where(x => x.IsDelete != true).ToList();
        }

        public Groups GetById(int id)
        {
            return _context.Groups.Include(x => x.WorkTicker).Include(x => x.Job).Where(x => x.Id == id).FirstOrDefault();
        }

        public bool GroupsExists(long id)
        {
            return _context.Groups.Any(x => x.Id == id);
        }
    }
}

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
        public void CreateGroups(Groups model, long ids)
        {
            var entity = new Groups();
            entity.Leader = model.Leader;
            entity.CalendarId = ids;
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
            return _context.Groups.Include(x => x.Job).Where(x => x.Id == id).FirstOrDefault();
        }
        public bool GroupsExists(long id)
        {
            return _context.Groups.Any(x => x.Id == id);
        }
        public int CountChuaSV()
        {
            var data = _context.Groups.Where(x => x.IsDelete != true && x.Status == (int)GroupsEnum.ChuaCoSinhVien).ToList();
            return data.Count();
        }
        public int CountChuaDiemdanh()
        {
            var data = _context.Groups.Where(x => x.IsDelete != true && x.Status == (int)GroupsEnum.ChuaDiemDanh).ToList();
            return data.Count();
        }
        public int CountGr()
        {
            var data = _context.Groups.Where(x => x.IsDelete != true).ToList();
            return data.Count();
        }
        
    }
}

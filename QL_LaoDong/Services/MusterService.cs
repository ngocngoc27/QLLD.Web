﻿using Microsoft.EntityFrameworkCore;
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
            entity.StudentId = model.StudentId;
            entity.GroupsId = model.GroupsId;
            entity.RollUp = model.RollUp;
            entity.IsDelete = false;
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
            entity.StudentId = model.StudentId;
            entity.GroupsId = model.GroupsId;
            entity.RollUp = model.RollUp;
            _context.Muster.Update(entity);
            _context.SaveChanges();
        }

        public List<Muster> Get()
        {
            return _context.Muster.Include(x=>x.Student).Include(x => x.Groups).Where(x => x.IsDelete != true).ToList();
        }

        public Muster GetById(int id)
        {
            return _context.Muster.Where(x => x.Id == id).FirstOrDefault();
        }
    }
}

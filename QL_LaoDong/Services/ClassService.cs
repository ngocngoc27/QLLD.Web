﻿using QL_LaoDong.Data;
using QL_LaoDong.Interfaces;
using QL_LaoDong.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QL_LaoDong.Services
{
    public class ClassService : IClassService
    {
        public DataContext _context;
        public ClassService(DataContext context)
        {
            _context = context;
        }
        public void Create(Class model)
        {
            var entity = new Class();
            entity.ClassCode = model.ClassCode;
            entity.ClassName = model.ClassName;
            entity.Training = model.Training;
            entity.TypeOfEducation = model.TypeOfEducation;
            entity.Total = model.Total;
            entity.TotalOfWork = model.TotalOfWork;
            entity.Status = model.Status;
            entity.FacultyId = model.FacultyId;
            _context.Class.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Class model)
        {
            var entity = _context.Class.Where(x => x.Id == model.Id).FirstOrDefault();
            if (entity == default)
                throw new Exception("Không tìm thấy dữ liệu.");

            _context.Class.Remove(entity);
            _context.SaveChanges();
        }

        public void Edit(Class model)
        {
            var entity = _context.Class.Where(x => x.Id == model.Id).FirstOrDefault();
            if (entity == default)
                throw new Exception("Không tìm thấy dữ liệu.");
            entity.ClassCode = model.ClassCode;
            entity.ClassName = model.ClassName;
            entity.Training = model.Training;
            entity.TypeOfEducation = model.TypeOfEducation;
            entity.Total = model.Total;
            entity.TotalOfWork = model.TotalOfWork;
            entity.Status = model.Status;
            entity.FacultyId = model.FacultyId;
            _context.Class.Update(entity);
            _context.SaveChanges();
        }

        public List<Class> Get()
        {
            return _context.Class.ToList();
        }

        public Class GetById(int id)
        {
            return _context.Class.Where(x => x.Id == id).FirstOrDefault();
        }
    }
}

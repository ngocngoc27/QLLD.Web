﻿using QL_LaoDong.Data;
using QL_LaoDong.Interfaces;
using QL_LaoDong.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QL_LaoDong.Services
{
    public class StudentService:IStudentService
    {
        public DataContext _context;
        public StudentService(DataContext context)
        {
            _context = context;
        }
        public void Create(Student model)
        {
            var check = _context.Student.Where(x => x.Mssv == model.Mssv).FirstOrDefault();
            if(check != default(Student))
            {
                throw new Exception("Tài khoản đã tồn tại!!!");
            }
            var entity = new Student();
            entity.Mssv = model.Mssv;
            entity.NumberOfWork = model.NumberOfWork;
            entity.ClassId = model.ClassId;
            entity.AccountId = model.AccountId;
            entity.Lock = false;
            _context.Student.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Student model)
        {
            var entity = _context.Student.Where(x => x.Id == model.Id).FirstOrDefault();
            if(entity == default)
                throw new Exception("Không tìm thấy dữ liệu!!!");
            _context.Student.Remove(entity);
            _context.SaveChanges();
        }

        public void Edit(Student model)
        {
            var entity = _context.Student.Where(x => x.Id == model.Id).FirstOrDefault();
            if(entity == default)
                throw new Exception("Không tìm thấy dữ liệu!!!");
            entity.Mssv = model.Mssv;
            entity.NumberOfWork = model.NumberOfWork;
            entity.ClassId = model.ClassId;
            entity.AccountId = model.AccountId;
            entity.Lock = false;
            _context.Student.Update(entity);
            _context.SaveChanges();
        }

        public List<Student> Get()
        {
            var student = _context.Student.Where(x => x.Lock != true).ToList();
            return student;
        }

        public Student GetById(int id)
        {
            return _context.Student.Where(x => x.Id == id).FirstOrDefault();
        }
    }
}

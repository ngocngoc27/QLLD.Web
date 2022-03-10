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
    public class AccountService:IAccountService
    {
        public DataContext _context;
        public AccountService(DataContext context)
        {
            _context = context;
        }

        public void Create(Account model)
        {
            var check = _context.Account.Where(x => x.Username == model.Username).FirstOrDefault();
        
            if (check != default(Account))
            {
                throw new Exception("Tài khoản đã tồn tại!!");
            }
            var entity = new Account();
            entity.Username = model.Username;
            string pass = model.Password;
            entity.Password = Security.MD5(pass);
            entity.Fullname = model.Fullname;
            entity.Sex = model.Sex;
            entity.RoleId = model.RoleId;
            entity.DateOfBirth = model.DateOfBirth;
            entity.Lock = false;
            _context.Account.Add(entity);
            _context.SaveChanges();

        }

        public List<Account> Get()
        {
            var account = _context.Account.Include(x => x.Role).Where(x => x.Lock != true).ToList();
            return account;
        }
        public void Edit(Account model)
        {
            var entity = _context.Account.Where(x => x.Id == model.Id).FirstOrDefault();
            if (entity == default)
                throw new Exception("Không tìm thấy dữ liệu.");
            entity.Username = model.Username;
            string pass = model.Password;
            entity.Password = Security.MD5(pass);
            entity.Sex = model.Sex;
            entity.Fullname = model.Fullname;
            entity.DateOfBirth = model.DateOfBirth;
            entity.RoleId = model.RoleId;
            entity.Lock = model.Lock;
            _context.Account.Update(entity);
            _context.SaveChanges();
        }
        public void Delete(Account model)
        {
            var entity = _context.Account.Where(x => x.Id == model.Id).FirstOrDefault();
            if (entity == default)
                throw new Exception("Không tìm thấy dữ liệu.");

            _context.Account.Remove(entity);
            _context.SaveChanges();
        }
        public Account GetById(int id)
        {
            return _context.Account.Where(x => x.Id == id).FirstOrDefault();
        }

    }
}

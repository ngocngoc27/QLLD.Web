using QL_LaoDong.Models;
using QL_LaoDong.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QL_LaoDong.Interfaces
{
    public interface IAccountService
    {
        List<Account> Get();
        Account GetById(int id);
        void Create(Account model);
        void Edit(Account model);
        void Delete(Account model);
        void Lock(Account model);
        bool AccountExists(long id);
        AppUser Login(Account model);

        Profile Details(long id);
        void ChangePass(Account model, int id);
    }
}

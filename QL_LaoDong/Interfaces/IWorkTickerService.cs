using QL_LaoDong.Models;
using QL_LaoDong.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QL_LaoDong.Interfaces
{
    public interface IWorkTickerService
    {
        List<Calendar> GetCalendar();
        List<Workticker> Get();
        List<Workticker> PageWorkTicker(long id);
        List<StudentVM> GetStudent(long id);
        Workticker GetById(int id);
        void Create(Workticker model);        
        void Edit(Workticker model);
        void Cancle(Workticker model);
        void Delete(Workticker model);
        bool TickerExists(long id);
        int CountsDS();
        int CountTT();
        int CountBan();
        int Choduyet();
    }
}

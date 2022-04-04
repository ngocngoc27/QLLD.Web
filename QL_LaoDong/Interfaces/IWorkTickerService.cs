﻿using QL_LaoDong.Models;
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
        List<Workticker> GetSundayAfter();
        List<Workticker> GetSundayMor();
        List<Workticker> GetMondayAfter();
        List<Workticker> GetMondayMor();
        List<Workticker> GetTuesdayAfter();
        List<Workticker> GetTuesdayMor();
        List<Workticker> GetWednesdayAfter();
        List<Workticker> GetWednesdayMor();
        List<Workticker> GetThursdayAfter();
        List<Workticker> GetThursdayMor();
        List<Workticker> GetFridayAfter();
        List<Workticker> GetFridayMor();
        List<Workticker> GetSaturdayAfter();
        List<Workticker> GetSaturdayMor();
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
        int CountDK();
        int CountDuyet();
        int CountCho();
        int CountBban();
        int CountHuy();
    }
}

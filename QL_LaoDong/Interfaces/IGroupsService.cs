using QL_LaoDong.Models;
using QL_LaoDong.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QL_LaoDong.Interfaces
{
    public interface IGroupsService
    {
        List<Groups> PageGroups(long id);
        Groups GetById(long id);
        void CreateGroups(Groups model, long id);
        void Edit(Groups model);
        void Delete(Groups model);
        bool GroupsExists(long id);
        int CountGrChuaSV();
        int CountGrChuaDD();
        int CountGr();
        List<Groups> GetSundayAfter();
        List<Groups> GetSundayMor();
        List<Groups> GetMondayAfter();
        List<Groups> GetMondayMor();
        List<Groups> GetTuesdayAfter();
        List<Groups> GetTuesdayMor();
        List<Groups> GetWednesdayAfter();
        List<Groups> GetWednesdayMor();
        List<Groups> GetThursdayAfter();
        List<Groups> GetThursdayMor();
        List<Groups> GetFridayAfter();
        List<Groups> GetFridayMor();
        List<Groups> GetSaturdayAfter();
        List<Groups> GetSaturdayMor();
    }
}

using QL_LaoDong.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QL_LaoDong.Interfaces
{
    public interface ICalendarService
    {
        List<Calendar> Get();
        Calendar GetById(long id);
        void Create(Calendar model);
        void Edit(Calendar model);
        void Delete(Calendar model);
        bool CalendarExists(long id);

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

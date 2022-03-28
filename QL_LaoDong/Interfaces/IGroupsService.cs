﻿using QL_LaoDong.Models;
using QL_LaoDong.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QL_LaoDong.Interfaces
{
    public interface IGroupsService
    {
        List<Groups> Get();
        Groups GetById(int id);
        void Edit(Groups model);
        void Delete(Groups model);
        bool GroupsExists(long id);
        void CreateMuster(Muster model);
    }
}

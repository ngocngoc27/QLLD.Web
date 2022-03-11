using QL_LaoDong.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QL_LaoDong.Interfaces
{
    public interface IToolService
    {
        List<Tool> Get();
        Tool GetById(int id);
        void Create(Tool model);
        void Edit(Tool model);
        void Lock(Tool model);

    }
}

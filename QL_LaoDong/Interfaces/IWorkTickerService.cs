using QL_LaoDong.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QL_LaoDong.Interfaces
{
    public interface IWorkTickerService
    {
        List<Workticker> Get();
        Workticker GetById(int id);
        void Create(Workticker model);
        void Edit(Workticker model);
        void Delete(Workticker model);
    }
}

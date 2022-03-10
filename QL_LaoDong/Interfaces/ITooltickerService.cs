using QL_LaoDong.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QL_LaoDong.Interfaces
{
    public interface ITooltickerService
    {
        List<Toolticker> Get();
        Toolticker GetById(int id);
        void Create(Toolticker model);
        void Edit(Toolticker model);
        void Delete(Toolticker model);
    }
}

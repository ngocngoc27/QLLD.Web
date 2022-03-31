using QL_LaoDong.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QL_LaoDong.Interfaces
{
    public interface ITooltickerService
    {
        List<Toolticker> PageToolTicker(long id);
        Toolticker GetById(long id);
        void Create(Toolticker model, long id);
        void Edit(Toolticker model);
        void Delete(Toolticker model);
        bool TooltickerExists(long id);
    }
}

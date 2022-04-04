using QL_LaoDong.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QL_LaoDong.Interfaces
{
    public interface IStudentService
    {
        List<Student> Get();
        List<Student> GetClass();
        Student GetById(int id);
        void Create(Student model);
        void Edit(Student model);
        void Delete(Student model);
        bool StudentExists(long Id);
        int CountHT();
        int CountSap();
        int CountChua();
    }
}

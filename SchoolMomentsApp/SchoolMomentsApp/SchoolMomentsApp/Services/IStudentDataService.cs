using SchoolMomentsApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMomentsApp.Services
{
    public interface IStudentDataService
    {
        Task<IEnumerable<Student>> GetAllStudents();

        Task<Student> GetStudent(int id);
    }
}

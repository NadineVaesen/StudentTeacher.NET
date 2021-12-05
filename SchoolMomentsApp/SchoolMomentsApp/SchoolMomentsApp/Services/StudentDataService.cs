using SchoolMomentsApp.Models;
using SchoolMomentsApp.Models.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMomentsApp.Services
{
    public class StudentDataService : IStudentDataService
    {
        public Task<IEnumerable<Student>> GetAllStudents()
        {
            return StudentRepository.GetStudents();
        }

        public Task<Student> GetStudent(int id)
        {
            return StudentRepository.GetStudent(id);
        }
    }
}

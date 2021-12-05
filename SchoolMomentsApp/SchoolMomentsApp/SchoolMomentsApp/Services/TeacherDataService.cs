using SchoolMomentsApp.Models;
using SchoolMomentsApp.Models.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMomentsApp.Services
{
    public class TeacherDataService : ITeacherDataService
    {
        public Task<IEnumerable<Teacher>> GetAllTeachers()
        {
            return TeacherRepository.GetTeachers();
        }

        public Task<Teacher> GetTeacher(int id)
        {
            return TeacherRepository.GetTeacher(id);
        }
    }
}

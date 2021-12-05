using SchoolMomentsApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMomentsApp.Services
{
    public interface ITeacherDataService
    {
        Task<IEnumerable<Teacher>> GetAllTeachers();

        Task<Teacher> GetTeacher(int id);
    }
}

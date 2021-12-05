using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolMomentsApp.Models
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        public string TeacherNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
    }
}

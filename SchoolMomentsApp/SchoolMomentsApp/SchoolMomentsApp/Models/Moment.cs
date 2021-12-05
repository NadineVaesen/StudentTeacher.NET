using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SchoolMomentsApp.Models
{
    public class Moment
    {
        public int MomentId { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }
        public String DateTime { get; set; }
        public int Duration { get; set; }
        //duration in hours
        public List<Student> RequestedStudents { get; set; }
        public List<Student> AttendedStudents { get; set; }


    }
}

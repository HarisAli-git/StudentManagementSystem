using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace flex.Models
{
    public class student
    {
        public string RollNo;
        public string name;
        public string Address;
        public string Email;
        public string Gender;
        public string CNIC;
        public string Section;
        public string DNO;
        public string CGPA;
    }

    public class loginstudent
    {
        public string Roll;
        public string Password;
    }

    public class courses
    {
        public string SemID;
        public string Code;
        public string name;
    }
    
    public class coursestaken
    {
        public string Roll;
        public string CourseCode;
    }

}
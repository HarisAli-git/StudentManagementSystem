using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using flex.Models;
namespace flex.Controllers
{
    public class HomeController : Controller
    {   
        public ActionResult AddSTDinSociety(String Roll, String code, String position)
        {
            int result = CRUD.AddSTDinSociety(Roll, code, position);
            if (result == 1)
            { 
                var m = new Tuple<List<RegSociety>, List<STDsociety>, string>(CRUD.getAllRegSocities(), CRUD.getAllSTDSocities(), "Student Successfully Added in Society!");
                return View("TRegSociety", (object)m);
            }
            else
            {
                String data = "Something went wrong while connecting with the database.";
                return View("TLogin", (object)data);
            }

        }
        public ActionResult AddCourse(String Semester, String Code, String Name)
        {
            int result = CRUD.AddCourse(Semester, Code, Name);
            if (result == 1)
            {
                var m = new Tuple<List<courses>, string>(CRUD.getAllCourses(), "Course Successfully Added!");
                return View("TCourses", (object)m);
            }
            else
            {
                String data = "Something went wrong while connecting with the database.";
                return View("TLogin", (object)data);
            }
        }
        public ActionResult TCourses()
        {
            if (Session["UserName"] == null)
            {
                return View("TLogin");
            }
            else
            {
                var m = new Tuple<List<courses>, string>(CRUD.getAllCourses(), null);
                return View(m);
            }
        }
        public ActionResult updateStudentLogin(String username, String oldpass, String updpass)
        {
            int result = CRUD.updateStudentLogin(username, oldpass, updpass);
            if (result == 1)
            {
                var m = new Tuple<List<loginstudent>, string, string>(CRUD.getAllStudentLogin(), null, "Student Login Info updated");
                return View("TStudentLogin", (object)m);
            }
            else if (result == 0)
            {
                var m = new Tuple<List<loginstudent>, string, string>(CRUD.getAllStudentLogin(), null, "Password doesnt match");
                return View("TStudentLogin", (object)m);
            }
            else
            {
                String data = "Something went wrong while connecting with the database.";
                return View("TLogin", (object)data);
            }
        }
        public ActionResult addStudentLogin(String username, String pass)
        {
            int result = CRUD.addStudentLogin(username, pass);
            if (result == 1)
            {
                var m = new Tuple<List<loginstudent>, string, string>(CRUD.getAllStudentLogin(), "Student Login Info added", null);
                return View("TStudentLogin", (object)m);
            }
            else
            {
                String data = "Something went wrong while connecting with the database.";
                return View("TLogin", (object)data);
            }
        }
        public ActionResult TStudentLogin()
        {
            if (Session["UserName"] == null)
            {
                return View("TLogin");
            }
            else
            {
                var m = new Tuple<List<loginstudent>, string, string>(CRUD.getAllStudentLogin(), null, null);
                return View(m);
            }
        }
        public ActionResult TRegSociety()
        {
            if (Session["UserName"] == null)
            {
                return View("TLogin");
            }
            else
            {
                var m = new Tuple<List<RegSociety>, List<STDsociety>, string>(CRUD.getAllRegSocities(), CRUD.getAllSTDSocities(), null);
                return View(m);
            }
        }
        public ActionResult updateTransript(String rollno, String coursecode, String semesterid, String grade)
        {
            int result = CRUD.updateTransript(rollno, coursecode, semesterid, grade);
            if (result == 1)
            {
                String data = "Grade Updated";
                return View("TGrades", (object)data);
            }
            else
            {
                String data = "Something went wrong while connecting with the database.";
                return View("TLogin", (object)data);
            }
        }

        public ActionResult AssignGrades(String Roll, String course_code)
        {
            int result = CRUD.AssignGrades(Roll, course_code);
            if (result == 1)
            {
                String data = "Grades Asssigned the Students";
                return View("TGrades", (object)data);
            }
            else
            {
                String data = "Something went wrong while connecting with the database.";
                return View("TLogin", (object)data);
            }
        }
        public ActionResult TGrades()
        {
            if (Session["UserName"] == null)
            {
                return View("TLogin");
            }
            else
            {
                return View();
            }
        }
        public ActionResult AddMarks(String Roll, String course_code, String Quiz1, String Quiz1Total, String Quiz2, String Quiz2Total, String Quiz3, String Quiz3Total, String Ass1, String Ass1Total, String Ass2, String Ass2Total, String Ass3, String Ass3Total, String Mid, String MidTotal, String Final, String FinalTotal)
        {
            int result = CRUD.AddMarks(Roll, course_code, Quiz1, Quiz1Total, Quiz2, Quiz2Total, Quiz3, Quiz3Total, Ass1, Ass1Total, Ass2, Ass2Total, Ass3, Ass3Total, Mid, MidTotal, Final, FinalTotal);

            if (result == 1)
            {
                return RedirectToAction("TMarks");
            }
            else
            {
                String data = "Something went wrong while connecting with the database.";
                return View("TLogin", (object)data);
            }
        }
        public ActionResult TMarks()
        {
            return View();
        }
        public ActionResult RemoveStudent(String input)
        {
            int result = CRUD.RemoveStudent(input);
            if (result != 1)
            {
                String data = "Something went wrong while connecting with the database.";
                return View("Login", (object)data);
            }
            else
                return RedirectToAction("TStudent");
        }
     
        public ActionResult AddStudent(String name, String Gender, String Roll, String Address, String Email, String Section, String CNIC, String DNO, String Cgpa)
        {
            int result = CRUD.AddStudent(name, Gender, Roll, Address, Email, Section, CNIC, DNO, Cgpa);
            if (result == 0 || result == 1)
                return RedirectToAction("TStudent");
            else
            {
                String data = "Something went wrong while connecting with the database.";
                return View("TLogin", (object)data);
            }
        }
        public ActionResult TStudent()
        {
            if (Session["UserName"] == null)
            {
                return View("TLogin");
            }
            else
            {
                var m = new Tuple<List<student>, student, string>(CRUD.getAllStudents(), null, null);
                if (m.Item1 == null)
                {
                    String data = "Students not found.";
                    return View("TLogin", (object)data);
                }
                else
                    return View(m);
            }
        }

        public ActionResult RemoveTeacher(String tid)
        {
            int result = CRUD.RemoveTeacher(tid);
            if (result == 1)
                return RedirectToAction("TTeacher");
            else
            {
                String data = "Something went wrong while connecting with the database.";
                return View("TLogin", (object)data);
            }
        }
        public ActionResult AddTeacher(String Id, String Name, String Email, String CNIC, String Department, String Gender, String Address)
        {
            int result = CRUD.AddTeacher(Id, Name, Email, CNIC, Department, Gender, Address);
            if (result == 1)
                return RedirectToAction("TTeacher");
            else
            {
                String data = "Something went wrong while connecting with the database.";
                return View("TLogin", (object)data);
            }
        }
        public ActionResult TTeacher()
        {
            if (Session["UserName"] == null)
            {
                return View("TLogin");
            }
            else
            {
                var m = new Tuple<List<Teacher>, Teacher, string>(CRUD.getAllTeachers(), null, null);
                if (m.Item1 == null)
                {
                    String data = "Teachers not found.";
                    return View("TLogin", (object)data);
                }
                else
                    return View(m);
            }
        }

        public ActionResult UpdateAttendance(String Rol, String CourseCode, String status)
        {
            int result = CRUD.UpdateAttendance(Rol, CourseCode, status);
            if (result == 1)
            {
                String data = "Attendance Successfully Updated";
                return RedirectToAction("TAttendance", (object)data);
            }
            else
            {
                String data = "Something went wrong while connecting with the database.";
                return View("TLogin", (object)data);
            }
        }
        public ActionResult AddAttendance(String courseName, String Semester, String section)
        {
            int result = CRUD.AddAttendance(courseName, Semester, section);
            if (result == 1)
            {
                StringWriter data = new StringWriter();
                data.WriteLine("Attendance Successfully Added");
                return RedirectToAction("TAttendance");
            }
            else
            {
                String data = "Something went wrong while connecting with the database.";
                return View("TLogin", (object)data);
            }
        }
        public ActionResult TAttendance()
        {
            if (Session["UserName"] == null)
                return View("TLogin");
            else
                return View();
        }
        public ActionResult TSociety()
        {
            if (Session["UserName"] == null)
            {
                return View("TLogin");
            }
            else
            {
                var m = new Tuple<List<Society>, Society>(CRUD.getAllSocities(), null);
                if (m.Item1 == null)
                {
                    String data = "Society not found.";
                    return View("TLogin", (object)data);
                }
                else
                    return View(m);
            }
        }

        public ActionResult AddSociety(String name, String code, String period)
        {
            int result = CRUD.AddSociety(name, code, period);
            if (result == 1)
            {
                StringWriter data = new StringWriter();
                data.WriteLine("Society Successfully Registered");
                return RedirectToAction("TSociety");
            }
            else
            {
                String data = "Something went wrong while connecting with the database.";
                return View("TLogin", (object)data);
            }
        }

        public ActionResult RemoveNotification(String input, String txt)
        {
            int result = CRUD.RemoveNotification(input, txt);
            if (result == 1)
            {
                var m = new Tuple<List<Notification>, string, string>(CRUD.getAllNotifications(), null, "Notification successfully removed.");
                return View("TNotification", (object)m);
            }
            else
            {
                String data = "Something went wrong while connecting with the database.";
                return View("Login", (object)data);
            }
        }
        public ActionResult AddNotification(String Roll, String txt)
        {
            int result = CRUD.AddNotification(Roll, txt);
            if (result == 1)
            {
                var m = new Tuple<List<Notification>, string, string>(CRUD.getAllNotifications(), "Notification Successfully Added", null);
                return View("TNotification", (object)m);
            }
            else
            {
                String data = "Something went wrong while connecting with the database.";
                return View("TLogin", (object)data);
            }
        }
        public ActionResult TNotification()
        {
            if (Session["UserName"] == null)
            {
                return View("TLogin");
            }
            else
            {
                var m = new Tuple<List<Notification>, string, string>(CRUD.getAllNotifications(), null, null);
                return View(m);
            }
        }
        public ActionResult Notification()
        {
            if (Session["Roll"] == null)
            {
                return View("Login");
            }
            else
            {
                List<Notification> n = CRUD.getNotification(Session["Roll"].ToString());
                if (n == null)
                {
                    Notification n1 = new Notification();
                    n1.Rollno = Session["Roll"].ToString();
                    n1.txt = "No notification posted yet!";
                    n.Add(n1);
                    return View(n);
                }
                else
                    return View(n);
            }
        }
        public ActionResult TLogin()
        {
            return View();
        }

        public ActionResult Tauthenticate(String UserName, String password)
        {
            int result = CRUD.TLogin(UserName, password);

            if (result == -1)
            {
                String data = "Something went wrong while connecting with the database.";
                return View("TLogin", (object)data);
            }
            else if (result == 0)
            {

                String data = "Incorrect Credentials";
                return View("TLogin", (object)data);
            }

            Session["UserName"] = UserName;
            return RedirectToAction("ThomePage");

        }

        public ActionResult ThomePage()
        {
            if (Session["UserName"] == null)
            {
                return View("TLogin");
            }
            else
            {
                Admin admin = CRUD.getAdmin(Session["UserName"].ToString());
                if (admin == null)
                {
                    String data = "Admin not found.";
                    return View("TLogin", (object)data);
                }
                else
                    return View(admin);
            }
        }

        public ActionResult RegSociety(String name, String code, String roll, String position)
        {
            int result = CRUD.RegSociety(name, code, roll, position);
            if (result == 0)
            {
                StringWriter data = new StringWriter();
                data.WriteLine("Society Period not Active yet");
                return RedirectToAction("Society");
            }
            else if (result == 1)
            {
                StringWriter data = new StringWriter();
                data.WriteLine("Society Successfully Registered");
                return RedirectToAction("Society");
            }
            else
            {
                String data = "Something went wrong while connecting with the database.";
                return View("Login", (object)data);
            }
        }
        public ActionResult Society()
        {
            if (Session["Roll"] == null)
            {
                return View("Login");
            }
            else
            {
                var m = new Tuple<List<Society>, RegSociety>(CRUD.getAllSocities(), null);
                if (m.Item1 == null)
                {
                    String data = "Society not found.";
                    return View("Login", (object)data);
                }
                else
                    return View(m);
            }
        }
        public ActionResult Transcript()
        {
            if (Session["Roll"] == null)
                return View("Login");
            else
            {
                List<Transcript> t = CRUD.getTranscript(Session["Roll"].ToString());
                return View(t);
            }
        }
        public ActionResult Marks()
        {
            if (Session["Roll"] == null)
            {
                return View("Login");
            }
            else
            {
                List<Marks> m = CRUD.getMarks(Session["Roll"].ToString());
                return View(m);
            }
        }

        public ActionResult Addcoursetaken(String rollno, String coursecode)
        {
            if (Session["Roll"] == null)
                return View("Login");
            else
            {
                int result = CRUD.Addcoursetaken(rollno, coursecode);
                if (result == -1)
                {
                    String data = "Something went wrong while connecting with the database.";
                    return View("Login", (object)data);
                }
                else
                    return RedirectToAction("CourseRegisteration");
            }
        }
        public ActionResult CourseRegisteration()
        {
            if (Session["Roll"] == null)
                return View("Login");
            else
            {
                var c = new Tuple<List<courses>, coursestaken>(CRUD.getAllcourses(Session["semid"].ToString()), null);
                return View(c);
            }
        }
        public ActionResult Login()
        {
            if(Session["Roll"] == null)
                return View();
            else
            {
                return RedirectToAction("homePage");
            }
        }

        public ActionResult Attendance()
        {
            if (Session["Roll"] == null)
            {
                return View("Login");
            }
            else
            {
                List<Attendance> a = CRUD.getAttendance(Session["Roll"].ToString());
                return View(a);
            }
        }

        public ActionResult authenticate(String Roll, String Password)
        {
            int result = CRUD.Login(Roll, Password);

            if (result == -1)
            {
                String data = "Something went wrong while connecting with the database.";
                return View("Login", (object)data);
            }
            else if (result == 0)
            {

                String data = "Incorrect Credentials";
                return View("Login", (object)data);
            }


            Session["Roll"] = Roll;
            Session["semid"] = CRUD.getsemid(Roll);
            return RedirectToAction("homePage");

        }
        public ActionResult homePage()
        {
            if (Session["Roll"] == null)
            {
                return View("Login");
            }
            else
            {
                student student = CRUD.getstudent(Session["Roll"].ToString());
                if (student == null)
                {
                    String data = "Student not found.";
                    return View("Login", (object)data);
                }
                else
                    return View(student);
            }
        }

    }
}
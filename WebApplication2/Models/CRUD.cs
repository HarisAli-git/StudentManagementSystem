using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;

namespace flex.Models
{
    public class CRUD
    {
        public static string connectionString = "data source=localhost; Initial Catalog=flex;Integrated Security=true";

        public static int getsemid(String Roll)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;
            int result = 0;

            try
            {
                cmd = new SqlCommand("getsemid", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@Roll", SqlDbType.VarChar, 20).Value = Roll;
                cmd.Parameters.Add("@semid", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();
                result = Convert.ToInt32(cmd.Parameters["@semid"].Value);

            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                result = -1; //-1 will be interpreted as "error while connecting with the database."
            }
            finally
            {
                con.Close();
            }
            return result;

        }
        public static int AssignGrades(String Roll, String course_code)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;

            try
            {
                cmd = new SqlCommand("addGradesOnTranscript", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@Roll", SqlDbType.VarChar, 20).Value = Roll;
                cmd.Parameters.Add("@course_code", SqlDbType.Int).Value = course_code;
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return -1;
            }
            finally
            {
                con.Close();
            }
            return 1;

        }

        public static int UpdateAttendance(String Rol, String CourseCode, String status)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;

            try
            {
                cmd = new SqlCommand("updateAttendance", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@Rol", SqlDbType.VarChar, 10).Value = Rol;
                cmd.Parameters.Add("@CourseCode", SqlDbType.Int).Value = CourseCode;
                cmd.Parameters.Add("@status", SqlDbType.Char).Value = status;
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return -1;
            }
            finally
            {
                con.Close();
            }
            return 1;

        }
        public static int updateTransript(String rollno, String coursecode, String semesterid, String grade)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;

            try
            {
                cmd = new SqlCommand("updateTransript", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@rollno", SqlDbType.VarChar, 20).Value = rollno;
                cmd.Parameters.Add("@coursecode", SqlDbType.VarChar, 20).Value = coursecode;
                cmd.Parameters.Add("@semesterid", SqlDbType.VarChar, 20).Value = semesterid;
                cmd.Parameters.Add("@grade", SqlDbType.VarChar, 2).Value = grade;
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return -1;
            }
            finally
            {
                con.Close();
            }
            return 1;
        }
        public static int AddMarks(String Roll, String course_code, String Quiz1, String Quiz1Total, String Quiz2, String Quiz2Total, String Quiz3, String Quiz3Total, String Ass1, String Ass1Total, String Ass2, String Ass2Total, String Ass3, String Ass3Total, String Mid, String MidTotal, String Final, String FinalTotal)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;

            try
            {
                cmd = new SqlCommand("InputMarks", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@Roll", SqlDbType.VarChar, 20).Value = Roll;
                cmd.Parameters.Add("@course_code", SqlDbType.VarChar, 20).Value = course_code;
                cmd.Parameters.Add("@Quiz1", SqlDbType.Int).Value = Quiz1;
                cmd.Parameters.Add("@Quiz1Total", SqlDbType.Int).Value = Quiz1Total;
                cmd.Parameters.Add("@Quiz2", SqlDbType.Int).Value = Quiz2;
                cmd.Parameters.Add("@Quiz2Total", SqlDbType.Int).Value = Quiz2Total;
                cmd.Parameters.Add("@Quiz3", SqlDbType.Int).Value = Quiz3;
                cmd.Parameters.Add("@Quiz3Total", SqlDbType.Int).Value = Quiz3Total;
                cmd.Parameters.Add("@Ass1", SqlDbType.Int).Value = Ass1;
                cmd.Parameters.Add("@Ass1Total", SqlDbType.Int).Value = Ass1Total;
                cmd.Parameters.Add("@Ass2", SqlDbType.Int).Value = Ass2;
                cmd.Parameters.Add("@Ass2Total", SqlDbType.Int).Value = Ass2Total;
                cmd.Parameters.Add("@Ass3", SqlDbType.Int).Value = Ass3;
                cmd.Parameters.Add("@Ass3Total", SqlDbType.Int).Value = Ass3Total;
                cmd.Parameters.Add("@Mid", SqlDbType.Int).Value = Mid;
                cmd.Parameters.Add("@MidTotal", SqlDbType.Int).Value = MidTotal;
                cmd.Parameters.Add("@Final", SqlDbType.Int).Value = Final;
                cmd.Parameters.Add("@FinalTotal", SqlDbType.Int).Value = FinalTotal;
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return -1;
            }
            finally
            {
                con.Close();
            }
            return 1;
        }

        public static int AddSTDinSociety(String Roll, String code, String position)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;

            try
            {
                cmd = new SqlCommand("AddStudinSociety", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@Roll", SqlDbType.VarChar, 20).Value = Roll;
                cmd.Parameters.Add("@code", SqlDbType.VarChar, 20).Value = code;
                cmd.Parameters.Add("@position", SqlDbType.VarChar, 50).Value = position;
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return -1;
            }
            finally
            {
                con.Close();
            }
            return 1;
        }
        public static int RemoveStudent(String input)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;

            try
            {
                cmd = new SqlCommand("RemoveStudent", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@input", SqlDbType.VarChar, 20).Value = input;
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return -1;
            }
            finally
            {
                con.Close();
            }
            return 1;
        }
        public static int RemoveNotification(String input, String txt)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;

            try
            {
                cmd = new SqlCommand("RemoveNotification", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@input", SqlDbType.VarChar, 20).Value = input;
                cmd.Parameters.Add("@txt", SqlDbType.VarChar, 1000).Value = txt;
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return -1;
            }
            finally
            {
                con.Close();
            }
            return 1;
        }
        public static int AddAttendance(String courseName, String Semester, String section)
        {

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;

            try
            {
                cmd = new SqlCommand("addAttendance", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@courseName", SqlDbType.VarChar, 30).Value = courseName;
                cmd.Parameters.Add("@Semester", SqlDbType.VarChar, 10).Value = Semester;
                cmd.Parameters.Add("@section", SqlDbType.VarChar, 10).Value = section;
                cmd.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return -1;
            }
            finally
            {
                con.Close();
            }
            return 1;
        }
        public static int AddSociety(String name, String code, String period)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;

            try
            {
                cmd = new SqlCommand("AddSociety", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@name", SqlDbType.VarChar, 20).Value = name;
                cmd.Parameters.Add("@code", SqlDbType.VarChar, 20).Value = code;
                cmd.Parameters.Add("@period", SqlDbType.Int).Value = period;
                cmd.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return -1;
            }
            finally
            {
                con.Close();
            }
            return 1;
        }
        public static int AddNotification(String Roll, String txt)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;

            try
            {
                cmd = new SqlCommand("AddNotification", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@Roll", SqlDbType.VarChar, 20).Value = Roll;
                cmd.Parameters.Add("@txt", SqlDbType.VarChar, 1000).Value = txt;
                cmd.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return -1;
            }
            finally
            {
                con.Close();
            }
            return 1;
        }

        public static int RemoveTeacher(String tid)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("RemoveTeacher", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@tid", SqlDbType.Int).Value = tid;
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return -1;
            }
            finally
            {
                con.Close();
            }
            return 1;

        }
        public static int AddTeacher(String Id, String Name, String Email, String CNIC, String Department, String Gender, String Address)
        {

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("addTeacher", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
                cmd.Parameters.Add("@Name", SqlDbType.VarChar, 40).Value = Name;
                cmd.Parameters.Add("@Email", SqlDbType.VarChar, 40).Value = Email;
                cmd.Parameters.Add("@CNIC", SqlDbType.VarChar, 40).Value = CNIC;
                cmd.Parameters.Add("@Department", SqlDbType.VarChar, 40).Value = Department;
                cmd.Parameters.Add("@Gender", SqlDbType.Char).Value = Gender;
                cmd.Parameters.Add("@Address", SqlDbType.VarChar, 50).Value = Address;
                cmd.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return -1;
            }
            finally
            {
                con.Close();
            }
            return 1;
        }

        public static int AddCourse(String Semester, String Code, String Name)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("addCourses", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@Semester", SqlDbType.Int).Value = Semester;
                cmd.Parameters.Add("@Code", SqlDbType.Int).Value = Code;
                cmd.Parameters.Add("@Name", SqlDbType.VarChar, 40).Value = Name;
                cmd.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return -1;
            }
            finally
            {
                con.Close();
            }
            return 1;

        }
        public static int Addcoursetaken(String rollno, String coursecode)
        {

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("addCoursetaken", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@rollno", SqlDbType.VarChar, 20).Value = rollno;
                cmd.Parameters.Add("@coursecode", SqlDbType.Int).Value = coursecode;
                cmd.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return -1;
            }
            finally
            {
                con.Close();
            }
            return 1;
        }
        public static int AddStudent(String name, String Gender, String Roll, String Address, String Email, String Section, String CNIC, String DNO, String Cgpa)
        {

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("addStudent", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@name", SqlDbType.VarChar, 40).Value = name;
                cmd.Parameters.Add("@Address", SqlDbType.VarChar, 100).Value = Address;
                cmd.Parameters.Add("@Roll", SqlDbType.VarChar, 10).Value = Roll;
                cmd.Parameters.Add("@Gender", SqlDbType.VarChar, 1).Value = Gender;
                cmd.Parameters.Add("@Email", SqlDbType.VarChar, 100).Value = Email;
                cmd.Parameters.Add("@Section", SqlDbType.VarChar, 1).Value = Section;
                cmd.Parameters.Add("@CNIC", SqlDbType.VarChar, 20).Value = CNIC;
                cmd.Parameters.Add("@DNO", SqlDbType.Int).Value = DNO;
                cmd.Parameters.Add("@Cgpa", SqlDbType.Int).Value = Cgpa;
                cmd.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return -1;
            }
            finally
            {
                con.Close();
            }
            return 1;
        }

        public static int RegSociety(String name, String code, String roll, String position)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;
            int result = 0;
            try
            {
                cmd = new SqlCommand("AddStudRegSociety", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@name", SqlDbType.VarChar, 20).Value = name;
                cmd.Parameters.Add("@code", SqlDbType.VarChar, 20).Value = code;
                cmd.Parameters.Add("@roll", SqlDbType.VarChar, 20).Value = roll;
                cmd.Parameters.Add("@position", SqlDbType.VarChar, 20).Value = position;
                cmd.Parameters.Add("@output", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();
                result = Convert.ToInt32(cmd.Parameters["@output"].Value);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return -1;
            }
            finally
            {
                con.Close();
            }
            return result;
        }

        public static List<loginstudent> getAllStudentLogin()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;

            try
            {
                cmd = new SqlCommand("viewStudentLogin", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader rdr = cmd.ExecuteReader();

                List<loginstudent> list = new List<loginstudent>();
                while (rdr.Read())
                {
                    loginstudent s = new loginstudent();

                    s.Roll = rdr["Username"].ToString();
                    s.Password = rdr["Password"].ToString();
                    list.Add(s);
                }
                rdr.Close();
                con.Close();

                return list;
            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return null;

            }
        }

        public static List<STDsociety> getAllSTDSocities()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;

            try
            {
                cmd = new SqlCommand("ViewSTDsociety", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader rdr = cmd.ExecuteReader();

                List<STDsociety> list = new List<STDsociety>();
                while (rdr.Read())
                {
                    STDsociety s = new STDsociety();

                    s.Name = rdr["Name"].ToString();
                    s.Code = rdr["Code"].ToString();
                    s.Rollno = rdr["Rollno"].ToString();
                    s.Position = rdr["position"].ToString();
                    list.Add(s);
                }
                rdr.Close();
                con.Close();

                return list;

            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return null;

            }
        }
        public static List<RegSociety> getAllRegSocities()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;

            try
            {
                cmd = new SqlCommand("ViewRegsociety", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader rdr = cmd.ExecuteReader();

                List<RegSociety> list = new List<RegSociety>();
                while (rdr.Read())
                {
                    RegSociety s = new RegSociety();

                    s.name = rdr["Name"].ToString();
                    s.Code = rdr["Code"].ToString();
                    s.Rollno = rdr["Rollno"].ToString();
                    s.position = rdr["position"].ToString();
                    list.Add(s);
                }
                rdr.Close();
                con.Close();

                return list;

            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return null;

            }
        }

        public static List<courses> getAllcourses(String semid)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;

            try
            {
                cmd = new SqlCommand("viewCourses", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@semid", SqlDbType.Int).Value = semid;
                cmd.ExecuteNonQuery();
                SqlDataReader rdr = cmd.ExecuteReader();

                List<courses> list = new List<courses>();
                while (rdr.Read())
                {
                    courses s = new courses();

                    s.SemID = rdr["SemesterID"].ToString();
                    s.Code = rdr["Code"].ToString();
                    s.name = rdr["name"].ToString();
                    list.Add(s);
                }
                rdr.Close();
                con.Close();

                return list;

            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return null;
            }
        }
        public static List<Society> getAllSocities()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;

            try
            {
                cmd = new SqlCommand("dbo.ViewSociety", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader rdr = cmd.ExecuteReader();

                List<Society> list = new List<Society>();
                while (rdr.Read())
                {
                    Society s = new Society();

                    s.Name = rdr["Name"].ToString();
                    s.Code = rdr["Code"].ToString();
                    s.period = rdr["period"].ToString();
                    list.Add(s);
                }
                rdr.Close();
                con.Close();

                return list;

            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return null;

            }

        }
        public static List<student> getAllStudents()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;

            try
            {
                cmd = new SqlCommand("ViewAllStudents", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader rdr = cmd.ExecuteReader();

                List<student> list = new List<student>();
                while (rdr.Read())
                {
                    student s = new student();

                    s.name = rdr["Name"].ToString();
                    s.Address = rdr["Address"].ToString();
                    s.CNIC = rdr["CNIC"].ToString();
                    s.CGPA = rdr["CGPA"].ToString();
                    s.DNO = rdr["DNO"].ToString();
                    s.Email = rdr["Email"].ToString();
                    s.Gender = rdr["Gender"].ToString();
                    s.RollNo = rdr["RollNo"].ToString();
                    s.Section = rdr["Section"].ToString();
                    list.Add(s);
                }
                rdr.Close();
                con.Close();

                return list;

            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return null;

            }

        }

        public static List<courses> getAllCourses()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;

            try
            {
                cmd = new SqlCommand("viewAllCourses", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader rdr = cmd.ExecuteReader();

                List<courses> list = new List<courses>();
                while (rdr.Read())
                {
                    courses c = new courses();

                    c.SemID = rdr["SemesterID"].ToString();
                    c.Code = rdr["Code"].ToString();
                    c.name = rdr["name"].ToString();
                    list.Add(c);
                }
                rdr.Close();
                con.Close();

                return list;

            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return null;

            }

        }
        public static List<Notification> getAllNotifications()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;

            try
            {
                cmd = new SqlCommand("ViewAllNotifications", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader rdr = cmd.ExecuteReader();

                List<Notification> list = new List<Notification>();
                while (rdr.Read())
                {
                    Notification t = new Notification();

                    t.Rollno = rdr["Rollno"].ToString();
                    t.txt = rdr["txt"].ToString();
                    list.Add(t);
                }
                rdr.Close();
                con.Close();

                return list;

            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return null;

            }

        }

        public static List<Teacher> getAllTeachers()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;

            try
            {
                cmd = new SqlCommand("ViewAllTeachers", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader rdr = cmd.ExecuteReader();

                List<Teacher> list = new List<Teacher>();
                while (rdr.Read())
                {
                    Teacher t = new Teacher();

                    t.Name = rdr["Name"].ToString();
                    t.Address = rdr["Address"].ToString();
                    t.CNIC = rdr["CNIC"].ToString();
                    t.Deptno = rdr["Deptno"].ToString();
                    t.T_id = rdr["T_id"].ToString();
                    t.Gender = rdr["Gender"].ToString();
                    t.Email = rdr["Email"].ToString();
                    list.Add(t);
                }
                rdr.Close();
                con.Close();

                return list;

            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return null;

            }

        }

        public static List<Marks> getMarks(string input)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;

            try
            {
                cmd = new SqlCommand("ViewMarks", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@input", SqlDbType.VarChar, 20).Value = input;

                SqlDataReader rdr = cmd.ExecuteReader();

                List<Marks> list = new List<Marks>();
                while (rdr.Read())
                {
                    Marks m = new Marks();

                    m.Roll = rdr["Rollno"].ToString();
                    m.course_cose = rdr["CourseCode"].ToString();
                    m.Quiz1 = rdr["Q1"].ToString();
                    m.Quiz1Total = rdr["Q1_total"].ToString();
                    m.Quiz2 = rdr["Q2"].ToString();
                    m.Quiz2Total = rdr["Q2_total"].ToString();
                    m.Quiz3 = rdr["Q3"].ToString();
                    m.Quiz3Total = rdr["Q3_total"].ToString();
                    m.Ass1 = rdr["A1"].ToString();
                    m.Ass1Total = rdr["A1_total"].ToString();
                    m.Ass2 = rdr["A2"].ToString();
                    m.Ass2Total = rdr["A2_total"].ToString();
                    m.Ass3 = rdr["A3"].ToString();
                    m.Ass3Total = rdr["A3_total"].ToString();
                    m.Mid = rdr["MID"].ToString();
                    m.MidTotal = rdr["MID_total"].ToString();
                    m.Final = rdr["FINAL"].ToString();
                    m.FinalTotal = rdr["FINAL_total"].ToString();
                    m.GrandTotal = rdr["GRAND_TOTAL"].ToString();
                    list.Add(m);
                }
                rdr.Close();
                con.Close();

                return list;
            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return null;
            }
        }
        public static List<Notification> getNotification(string input)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;

            try
            {
                cmd = new SqlCommand("ViewNotification", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@input", SqlDbType.VarChar, 20).Value = input;

                SqlDataReader rdr = cmd.ExecuteReader();

                List<Notification> list = new List<Notification>();
                while (rdr.Read())
                {
                    Notification a = new Notification();

                    a.Rollno = rdr["Rollno"].ToString();
                    a.txt = rdr["txt"].ToString();
                    list.Add(a);
                }
                rdr.Close();
                con.Close();

                return list;
            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return null;
            }
        }

        public static List<Transcript> getTranscript(string input)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;

            try
            {
                cmd = new SqlCommand("ViewTranscript", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@input", SqlDbType.VarChar, 20).Value = input;

                SqlDataReader rdr = cmd.ExecuteReader();

                List<Transcript> list = new List<Transcript>();
                while (rdr.Read())
                {
                    Transcript t = new Transcript();
                    t.SemID = rdr["Semesterid"].ToString();
                    t.Rollno = rdr["Rollno"].ToString();
                    t.CourseCode = rdr["Coursecode"].ToString();
                    t.CourseName = rdr["CourseName"].ToString();
                    t.Grade = rdr["Grade"].ToString();
                    list.Add(t);
                }
                rdr.Close();
                con.Close();

                return list;
            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return null;
            }
        }
        public static List<Attendance> getAttendance(string input)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;

            try
            {
                cmd = new SqlCommand("ViewAttendance", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@input", SqlDbType.VarChar, 20).Value = input;

                SqlDataReader rdr = cmd.ExecuteReader();

                List<Attendance> list = new List<Attendance>();
                while (rdr.Read())
                {
                    Attendance a = new Attendance();

                    a.Rollno = rdr["Rollno"].ToString();
                    a.Status = rdr["Status"].ToString();
                    a.Date = rdr["Date"].ToString();
                    a.courseCode = rdr["courseCode"].ToString();
                    list.Add(a);
                }
                rdr.Close();
                con.Close();

                return list;
            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return null;
            }
        }

        public static Admin getAdmin(string input)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;

            try
            {
                cmd = new SqlCommand("ViewAdmin", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@input", SqlDbType.VarChar, 20).Value = input;

                SqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    Admin admin = new Admin();
                    admin.Name = rdr["Name"].ToString();
                    admin.Email = rdr["Email"].ToString();
                    admin.CNIC = rdr["CNIC"].ToString();
                    admin.Gender = rdr["Gender"].ToString();
                    admin.password = rdr["password"].ToString();
                    admin.Address = rdr["Address"].ToString();
                    admin.UserName = rdr["UserName"].ToString();
                    rdr.Close();
                    con.Close();
                    return admin;
                }

                rdr.Close();
                con.Close();
                return null;
            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return null;
            }
        }

        public static student getstudent(string input)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;

            try
            {
                cmd = new SqlCommand("ViewStudentInfo", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@input", SqlDbType.VarChar, 20).Value = input;

                SqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    student student = new student();
                    student.RollNo = rdr["RollNo"].ToString();
                    student.name = rdr["name"].ToString();
                    student.Section = rdr["Section"].ToString();
                    student.Gender = rdr["Gender"].ToString();
                    student.Email = rdr["Email"].ToString();
                    student.CGPA = rdr["CGPA"].ToString();
                    student.Address = rdr["Address"].ToString();
                    student.DNO = rdr["DNO"].ToString();
                    rdr.Close();
                    con.Close();
                    return student;
                }

                rdr.Close();
                con.Close();
                return null;
            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return null;
            }
        }

        public static int TLogin(string UserName, string password)
        {

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;
            int result = 0;

            try
            {
                cmd = new SqlCommand("Adminloginproc", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@UserName", SqlDbType.VarChar, 20).Value = UserName;
                cmd.Parameters.Add("@password", SqlDbType.VarChar, 20).Value = password;
                cmd.Parameters.Add("@output", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();
                result = Convert.ToInt32(cmd.Parameters["@output"].Value);

            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                result = -1; //-1 will be interpreted as "error while connecting with the database."
            }
            finally
            {
                con.Close();
            }
            return result;

        }

        public static int updateStudentLogin(String username, String oldpass, String updpass)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;
            int result = 1;

            try
            {
                cmd = new SqlCommand("updateStudentlogin", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@username", SqlDbType.VarChar, 20).Value = username;
                cmd.Parameters.Add("@updpass", SqlDbType.VarChar, 20).Value = updpass;
                cmd.Parameters.Add("@oldpass", SqlDbType.VarChar, 20).Value = oldpass;
                cmd.Parameters.Add("@output", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();
                result = Convert.ToInt32(cmd.Parameters["@output"].Value);

                cmd.ExecuteNonQuery();
            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                result = -1; //-1 will be interpreted as "error while connecting with the database."
            }
            finally
            {
                con.Close();
            }
            return result;
        }
        public static int addStudentLogin(String username, String pass)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;
            int result = 1;

            try
            {
                cmd = new SqlCommand("addStudentlogin", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@username", SqlDbType.VarChar, 20).Value = username;
                cmd.Parameters.Add("@pass", SqlDbType.VarChar, 20).Value = pass;

                cmd.ExecuteNonQuery();
            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                result = -1; //-1 will be interpreted as "error while connecting with the database."
            }
            finally
            {
                con.Close();
            }
            return result;
        }
        public static int Login(string Roll, string Password)
        {

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;
            int result = 0;

            try
            {
                cmd = new SqlCommand("Studentloginproc", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@Roll", SqlDbType.VarChar, 20).Value = Roll;
                cmd.Parameters.Add("@Password", SqlDbType.VarChar, 20).Value = Password;
                cmd.Parameters.Add("@output", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();
                result = Convert.ToInt32(cmd.Parameters["@output"].Value);

            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                result = -1; //-1 will be interpreted as "error while connecting with the database."
            }
            finally
            {
                con.Close();
            }
            return result;

        }

    }
}
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using WellsFargo.EmployeeManagement.BusinessObjects.Entity;
using WellsFargo.EmployeeManagement.BusinessObjects.Interfaces;

namespace WellsFargo.EmployeeManagement.RepositoryLayer
{
    public class StudentDetailsRepository : IStudentDetailsRepository
    {
        //windows authentication connection string
        string connectionString = "data source=DESKTOP-NORDVAN\\MSSQLSERVER01; integrated security=yes; initial catalog=NagendraDB";
        //sqlserver authentication connectionstring
        // string connectionString = "data source=DESKTOP-N6885P9; user id=sa; password=S@12345; initial catalog=StudentManagement";
        public StudentDetailsRepository()
        {
                
        }
        public async Task<List<Student>> GetAllStudentDetails()
        {
            List <Student> lstStudent = new List<Student>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_Employe", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = await cmd.ExecuteReaderAsync();

                while (rdr.Read())
                {
                    Student student = new Student();
                    student.Id = Convert.ToInt32(rdr["Id"]);
                    student.FirstName = rdr["FirstName"].ToString();
                    student.LastName = rdr["LastName"].ToString();
                    student.Email = rdr["Email"].ToString();
                    student.Mobile = rdr["Mobile"].ToString();
                    student.Address = rdr["Address"].ToString();

                    lstStudent.Add(student);
                }
                con.Close();
            }
            return lstStudent;
        }

        public async Task<Student> GetStudentDetailsById(int id)
        {
            Student student = new Student();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM Employee WHERE Id= " + id;
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                con.Open();
                SqlDataReader rdr = await cmd.ExecuteReaderAsync();

                while (rdr.Read())
                {
                    student.Id = Convert.ToInt32(rdr["Id"]);
                    student.FirstName = rdr["FirstName"].ToString();
                    student.LastName = rdr["LastName"].ToString();
                    student.Email = rdr["Email"].ToString();
                    student.Mobile = rdr["Mobile"].ToString();
                    student.Address = rdr["Address"].ToString();
                }
            }
            return student;
        }
        public async Task<bool> AddStudentDetils(Student studentDetail)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spAddStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@FirstName", studentDetail.FirstName);
                cmd.Parameters.AddWithValue("@LastName", studentDetail.LastName);
                cmd.Parameters.AddWithValue("@Email", studentDetail.Email);
                cmd.Parameters.AddWithValue("@Mobile", studentDetail.Mobile);
                cmd.Parameters.AddWithValue("@Address", studentDetail.Address);
                con.Open();
                await  cmd.ExecuteNonQueryAsync();
                con.Close();
            }
            return true;
        }

        public async Task<bool> UpdateStudentDetils(Student studentDetail)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spUpdateStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", studentDetail.Id);
                cmd.Parameters.AddWithValue("@FirstName", studentDetail.FirstName);
                cmd.Parameters.AddWithValue("@LastName", studentDetail.LastName);
                cmd.Parameters.AddWithValue("@Email", studentDetail.Email);
                cmd.Parameters.AddWithValue("@Mobile", studentDetail.Mobile);
                cmd.Parameters.AddWithValue("@Address", studentDetail.Address);
                con.Open();
                await cmd.ExecuteNonQueryAsync();
                con.Close();
            }
            return true;
        }
        public async Task<bool> DeleteStudentDetilsById(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spDeleteStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);
                con.Open();
               await cmd.ExecuteNonQueryAsync();
                con.Close();
            }
            return true;
        }

       

        
    }
}

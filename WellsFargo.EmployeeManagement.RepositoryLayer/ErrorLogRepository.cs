using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using WellsFargo.EmployeeManagement.BusinessObjects.Entity;
namespace WellsFargo.EmployeeManagement.RepositoryLayer
{
    public class ErrorLogRepository
    {
        string connectionString = "data source=localhost; integrated security=yes; initial catalog=StudentManagement";
        public ErrorLogRepository()
        {
                
        }
        public async Task<bool> CreateErrorLog(ErrorLog errorLog)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("USP_ErrorLog_Text", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@p_ErrorDesc", errorLog.ErrorDesc);
                cmd.Parameters.AddWithValue("@p_ErrorMessage", errorLog.ErrorMessage);
                cmd.Parameters.AddWithValue("@p_Severity", "High");
                cmd.Parameters.AddWithValue("@p_MethodName", errorLog.MethodName);
                cmd.Parameters.AddWithValue("@p_Reference", errorLog.QueryString);
                cmd.Parameters.AddWithValue("@p_Host",errorLog.Host);
                cmd.Parameters.AddWithValue("@p_Controller", errorLog.Controller);
                cmd.Parameters.AddWithValue("@p_StackTrace", errorLog.StackTrace);
                cmd.Parameters.AddWithValue("@p_UserId",errorLog.CreatedBy);
                
                con.Open();
                await cmd.ExecuteNonQueryAsync();
                con.Close();
            }
            return true;
        }

    }
}

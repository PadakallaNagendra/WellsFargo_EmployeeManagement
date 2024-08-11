using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WellsFargo.EmployeeManagement.BusinessObjects.Entity;

namespace WellsFargo.EmployeeManagement.BusinessObjects.Interfaces
{
    public interface IStudentDetailsService
    {
        Task<List<Student>> GetAllStudentDetails();
        Task<Student> GetStudentDetailsById(int id);
        Task<bool> AddStudentDetils(Student studentDetail);
        Task<bool> UpdateStudentDetils(Student studentDetail);
        Task<bool> DeleteStudentDetilsById(int id);
    }
}

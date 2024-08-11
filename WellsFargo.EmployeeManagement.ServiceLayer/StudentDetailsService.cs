using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WellsFargo.EmployeeManagement.BusinessObjects.Entity;
using WellsFargo.EmployeeManagement.BusinessObjects.Interfaces;

namespace WellsFargo.EmployeeManagement.ServiceLayer
{
    public class StudentDetailsService : IStudentDetailsService
    {
        private readonly IStudentDetailsRepository _IStudentDetailsRepository;
        public StudentDetailsService(IStudentDetailsRepository IStudentDetailsRepository) 
        {
            this._IStudentDetailsRepository = IStudentDetailsRepository;
        }
        public async Task<bool> AddStudentDetils(Student studentDetail)
        {
          return  await this._IStudentDetailsRepository.AddStudentDetils(studentDetail);
        }

        public async Task<bool> DeleteStudentDetilsById(int id)
        {
            return await this._IStudentDetailsRepository.DeleteStudentDetilsById(id);
        }

        public async Task<List<Student>> GetAllStudentDetails()
        {
            return await this._IStudentDetailsRepository.GetAllStudentDetails();
        }

        public async Task<Student> GetStudentDetailsById(int id)
        {
            return await this._IStudentDetailsRepository.GetStudentDetailsById(id);
        }

        public async Task<bool> UpdateStudentDetils(Student studentDetail)
        {
            return await this._IStudentDetailsRepository.UpdateStudentDetils(studentDetail);
        }
    }
}

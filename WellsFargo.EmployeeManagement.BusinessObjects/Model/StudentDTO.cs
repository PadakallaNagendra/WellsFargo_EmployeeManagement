using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WellsFargo.EmployeeManagement.BusinessObjects.Model
{
    public class StudentDTO
    {
        public int Id { set; get; }
        [Required]
        public string FirstName { set; get; }
        [Required]
        public string LastName { set; get; }
        [Required]
        public string Email { set; get; }
        [Required]
        public string Mobile { set; get; }
        public string Address { set; get; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WellsFargo.EmployeeManagement.BusinessObjects.Entity
{
    public class ErrorLog:Exception
    {
        public string ErrorMessage { get; set; }
        public string Controller { get; set; }
        public string MethodName { get;set; }
        public string ErrorDesc { get; set; }
        public string Path { get; set; }
        public string Body { get; set; }
        public string QueryString { get; set; }
        public string ContextInfo { get; set; }
        public string Host { get; set; }
        public string? CreatedBy { get; set; }
        public string? ModifiedBy { get; set; }
    }
}

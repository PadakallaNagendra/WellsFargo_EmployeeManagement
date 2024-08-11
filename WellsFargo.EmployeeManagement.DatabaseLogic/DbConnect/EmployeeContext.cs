using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WellsFargo.EmployeeManagement.BusinessObjects.Entity;

namespace WellsFargo.EmployeeManagement.DatabaseLogic.DbConnect
{
    public class EmployeeContext : DbContext
    {
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Login> Login { get; set; }
       protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-N6885P9;Initial Catalog=WellsFargo.EmployeeManagement;Integrated Security=True");
        }
    }
}

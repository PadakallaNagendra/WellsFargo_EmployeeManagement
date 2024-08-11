using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WellsFargo.EmployeeManagement.BusinessObjects.Entity;

namespace WellsFargo.EmployeeManagement.DatabaseLogic.DbConnect
{
    public class PaymentDetailContext : DbContext
    {

        public DbSet<PaymentDetail> PaymentDetail { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-N6885P9;Initial Catalog=PaymentDetailDB1;Integrated Security=True");
        }
    }
}

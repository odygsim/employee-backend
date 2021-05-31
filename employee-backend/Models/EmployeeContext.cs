using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace employee_backend.Models
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options) 
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<EmployeeModel> Employees { get; set; }
    }
}

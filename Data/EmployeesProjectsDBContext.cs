using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EmployeesCRUD.Tables;

namespace EmployeesCRUD.Data
{
    public class EmployeesProjectsDBContext : DbContext
    {
        public EmployeesProjectsDBContext (DbContextOptions<EmployeesProjectsDBContext> options)
            : base(options)
        {
        }

        public DbSet<EmployeesCRUD.Tables.EmployeesTable> EmployeesTable { get; set; }

        public DbSet<EmployeesCRUD.Tables.JobOrdersTable> JobOrdersTable { get; set; }

        public DbSet<EmployeesCRUD.Tables.ProjectEmployeesTable> ProjectEmployeesTable { get; set; }

        public DbSet<EmployeesCRUD.Tables.ProjectsTable> ProjectsTable { get; set; }
    }
}

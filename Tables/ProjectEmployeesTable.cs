using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesCRUD.Tables
{
    // ProjectEmplyees table class
    public class ProjectEmployeesTable
    {
        // Primary-Key for ProjectEmplyees Table
        [Key]
        public int ProjectEmployeesId { get; set; }
        // Foregin Keys for table project employees
        [ForeignKey("ProjectsTable")]
        public int ProjectId { get; set; }
        public ProjectsTable Project { get; set; }
        [ForeignKey("EmployeesTable")]
        public int EmployeeId { get; set; }
        public EmployeesTable Employee { get; set; }
        // No of Work hours
        public int Hours { get; set; }
    }
}

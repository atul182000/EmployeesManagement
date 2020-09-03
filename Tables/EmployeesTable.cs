using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesCRUD.Tables
{
    // Table Emplyess class
    public class EmployeesTable
    {
        // setting emplyee id as primary key in table through annotations
        [Key]
        public int EmployeeId { get; set; }
        // First name of emp
        public string FirstName { get; set; }
        // Last name of emp
        public string LastName { get; set; }
        // hourly wage of employee
        public double HourlyWage { get; set; }
        // hire date for employee
        public DateTime HireDate { get; set; }

        // Employees->JobOrder, ProjectEmplyee Relationship
        public List<JobOrdersTable> JobOrder { get; set; }
        public List<ProjectEmployeesTable> ProjectEmployee { get; set; }
        public EmployeesTable() { JobOrder = new List<JobOrdersTable>(); ProjectEmployee = new List<ProjectEmployeesTable>(); }
    }
}

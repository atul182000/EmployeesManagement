using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesCRUD.Tables
{
    // Projects Table Class
    public class ProjectsTable
    {
        // A Primary-Key Attribute annotated
        [Key]
        public int ProjectId { get; set; }
        // Name attribute for table projects
        public string Name { get; set; }
        // Project Start Date
        public DateTime StartDate { get; set; }
        // Project End Date
        public DateTime EndDate { get; set; }
        // Project - > JobOrder, ProjectEmplyee Relationship
        public List<JobOrdersTable> JobOrder { get; set; }

        public ProjectsTable() { JobOrder = new List<JobOrdersTable>(); ProjectEmployee = new List<ProjectEmployeesTable>(); }

        public List<ProjectEmployeesTable> ProjectEmployee { get; set; }

    }
}

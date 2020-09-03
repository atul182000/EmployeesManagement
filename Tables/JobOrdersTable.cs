using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Threading.Tasks;

namespace EmployeesCRUD.Tables
{
    // Table JobOrders class
    public class JobOrdersTable
    {
        // setting JobOrdersId as Primary-Key in table through annotations
        [Key]
        public int JobOrdersId { get; set; }
        // attribute used as foreign key in this table
        [ForeignKey("EmployeesTable")]
        public int EmployeeId { get; set; }
        public EmployeesTable Employee { get; set; }
        // attribute used as foreign key in this table
        [ForeignKey("ProjectsTable")]
        public int ProjectId { get; set; }
        public ProjectsTable Project { get; set; }
        // Description for JobOrders
        public String Description { get; set; }
        // Order Date and time 
        public DateTime OrderDateTime { get; set; }
        // Quantity of Job Orders
        public int Quantity { get; set; }
        // Price for JobOrder
        public double  Price { get; set; }
    }
}

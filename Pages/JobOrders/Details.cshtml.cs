using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EmployeesCRUD.Data;
using EmployeesCRUD.Tables;

namespace EmployeesCRUD.Pages.JobOrders
{
    public class DetailsModel : PageModel
    {
        private readonly EmployeesCRUD.Data.EmployeesProjectsDBContext _context;

        public DetailsModel(EmployeesCRUD.Data.EmployeesProjectsDBContext context)
        {
            _context = context;
        }

        public JobOrdersTable JobOrdersTable { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            JobOrdersTable = await _context.JobOrdersTable
                .Include(j => j.Employee)
                .Include(j => j.Project).FirstOrDefaultAsync(m => m.JobOrdersId == id);

            if (JobOrdersTable == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}

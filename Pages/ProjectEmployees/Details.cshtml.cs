using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EmployeesCRUD.Data;
using EmployeesCRUD.Tables;

namespace EmployeesCRUD.Pages.ProjectEmployees
{
    public class DetailsModel : PageModel
    {
        private readonly EmployeesCRUD.Data.EmployeesProjectsDBContext _context;

        public DetailsModel(EmployeesCRUD.Data.EmployeesProjectsDBContext context)
        {
            _context = context;
        }

        public ProjectEmployeesTable ProjectEmployeesTable { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ProjectEmployeesTable = await _context.ProjectEmployeesTable
                .Include(p => p.Employee)
                .Include(p => p.Project).FirstOrDefaultAsync(m => m.ProjectEmployeesId == id);

            if (ProjectEmployeesTable == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EmployeesCRUD.Data;
using EmployeesCRUD.Tables;

namespace EmployeesCRUD.Pages.Employees
{
    public class DeleteModel : PageModel
    {
        private readonly EmployeesCRUD.Data.EmployeesProjectsDBContext _context;

        public DeleteModel(EmployeesCRUD.Data.EmployeesProjectsDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public EmployeesTable EmployeesTable { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            EmployeesTable = await _context.EmployeesTable.FirstOrDefaultAsync(m => m.EmployeeId == id);

            if (EmployeesTable == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            EmployeesTable = await _context.EmployeesTable.FindAsync(id);

            if (EmployeesTable != null)
            {
                _context.EmployeesTable.Remove(EmployeesTable);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

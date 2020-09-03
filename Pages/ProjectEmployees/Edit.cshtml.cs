using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EmployeesCRUD.Data;
using EmployeesCRUD.Tables;

namespace EmployeesCRUD.Pages.ProjectEmployees
{
    public class EditModel : PageModel
    {
        private readonly EmployeesCRUD.Data.EmployeesProjectsDBContext _context;

        public EditModel(EmployeesCRUD.Data.EmployeesProjectsDBContext context)
        {
            _context = context;
        }

        [BindProperty]
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
           ViewData["EmployeeId"] = new SelectList(_context.EmployeesTable, "EmployeeId", "EmployeeId");
           ViewData["ProjectId"] = new SelectList(_context.ProjectsTable, "ProjectId", "ProjectId");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ProjectEmployeesTable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectEmployeesTableExists(ProjectEmployeesTable.ProjectEmployeesId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ProjectEmployeesTableExists(int id)
        {
            return _context.ProjectEmployeesTable.Any(e => e.ProjectEmployeesId == id);
        }
    }
}

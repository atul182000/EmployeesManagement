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

namespace EmployeesCRUD.Pages.Projects
{
    public class EditModel : PageModel
    {
        private readonly EmployeesCRUD.Data.EmployeesProjectsDBContext _context;

        public EditModel(EmployeesCRUD.Data.EmployeesProjectsDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ProjectsTable ProjectsTable { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ProjectsTable = await _context.ProjectsTable.FirstOrDefaultAsync(m => m.ProjectId == id);

            if (ProjectsTable == null)
            {
                return NotFound();
            }
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

            _context.Attach(ProjectsTable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectsTableExists(ProjectsTable.ProjectId))
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

        private bool ProjectsTableExists(int id)
        {
            return _context.ProjectsTable.Any(e => e.ProjectId == id);
        }
    }
}

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
    public class IndexModel : PageModel
    {
        private readonly EmployeesCRUD.Data.EmployeesProjectsDBContext _context;

        public IndexModel(EmployeesCRUD.Data.EmployeesProjectsDBContext context)
        {
            _context = context;
        }

        public IList<ProjectEmployeesTable> ProjectEmployeesTable { get;set; }

        public async Task OnGetAsync()
        {
            ProjectEmployeesTable = await _context.ProjectEmployeesTable
                .Include(p => p.Employee)
                .Include(p => p.Project).ToListAsync();
        }
    }
}

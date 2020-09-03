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
    public class IndexModel : PageModel
    {
        private readonly EmployeesCRUD.Data.EmployeesProjectsDBContext _context;

        public IndexModel(EmployeesCRUD.Data.EmployeesProjectsDBContext context)
        {
            _context = context;
        }

        public IList<EmployeesTable> EmployeesTable { get;set; }

        public async Task OnGetAsync()
        {
            EmployeesTable = await _context.EmployeesTable.ToListAsync();
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EmployeesCRUD.Data;
using EmployeesCRUD.Tables;

namespace EmployeesCRUD.Pages.JobOrders
{
    public class CreateModel : PageModel
    {
        private readonly EmployeesCRUD.Data.EmployeesProjectsDBContext _context;

        public CreateModel(EmployeesCRUD.Data.EmployeesProjectsDBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["EmployeeId"] = new SelectList(_context.EmployeesTable, "EmployeeId", "EmployeeId");
        ViewData["ProjectId"] = new SelectList(_context.Set<ProjectsTable>(), "ProjectId", "ProjectId");
            return Page();
        }

        [BindProperty]
        public JobOrdersTable JobOrdersTable { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.JobOrdersTable.Add(JobOrdersTable);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

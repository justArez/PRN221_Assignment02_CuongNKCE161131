using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObject;

namespace CarSaleWebApp.Pages
{
    public class CreateModel : PageModel
    {
        private readonly BusinessObject.CarSaleManagementDbContext _context;

        public CreateModel(BusinessObject.CarSaleManagementDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["Roleid"] = new SelectList(_context.Roles, "Roleid", "Roleid");
            return Page();
        }

        [BindProperty]
        public User User { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Users.Add(User);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

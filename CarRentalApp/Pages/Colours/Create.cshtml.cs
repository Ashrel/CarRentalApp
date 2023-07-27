using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CarRentalApp.Data;

namespace CarRentalApp.Pages.Colours
{
    public class CreateModel : PageModel
    {
        private readonly CarRentalApp.Data.CarRentalAppDbContext _context;

        public CreateModel(CarRentalApp.Data.CarRentalAppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Colour Colour { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Colours.Add(Colour);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

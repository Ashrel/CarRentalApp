using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CarRentalApp.Data;
using Microsoft.EntityFrameworkCore;

namespace CarRentalApp.Pages.Cars
{
    public class CreateModel : PageModel
    {
        private readonly CarRentalApp.Data.CarRentalAppDbContext _context;

        public CreateModel(CarRentalApp.Data.CarRentalAppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Car Car { get; set; }

        public SelectList Makes { get; set; } 

        public async Task<IActionResult> OnGet()
        {
            await LoadInitialData();
            return Page();
        }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                await LoadInitialData();
                return Page();
            }

            _context.Cars.Add(Car);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        private async Task LoadInitialData()
        {
            Makes = new SelectList(await _context.Makes.ToListAsync(), "Id", "Name");
        }
    } 
}

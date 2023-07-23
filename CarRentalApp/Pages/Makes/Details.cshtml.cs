using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarRentalApp.Data;

namespace CarRentalApp.Pages.Makes
{
    public class DetailsModel : PageModel
    {
        private readonly CarRentalApp.Data.CarRentalAppDbContext _context;

        public DetailsModel(CarRentalApp.Data.CarRentalAppDbContext context)
        {
            _context = context;
        }

        public Make Make { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Make = await _context.Makes.FirstOrDefaultAsync(m => m.Id == id);

            if (Make == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}

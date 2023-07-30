using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarRentalApp.Data;

namespace CarRentalApp.Pages.Cars
{
    public class DetailsModel : PageModel
    {
        private readonly CarRentalApp.Data.CarRentalAppDbContext _context;

        public DetailsModel(CarRentalApp.Data.CarRentalAppDbContext context)
        {
            _context = context;
        }

        public Car Car { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Car = await _context.Cars
                .Include(q => q.Make)
                .Include(q => q.CarModel)
                .Include(q => q.Colour).FirstOrDefaultAsync(m => m.Id == id);

            if (Car == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}

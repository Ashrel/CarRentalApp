using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarRentalApp.Data;

namespace CarRentalApp.Pages.CarModels
{
    public class IndexModel : PageModel
    {
        private readonly CarRentalApp.Data.CarRentalAppDbContext _context;

        public IndexModel(CarRentalApp.Data.CarRentalAppDbContext context)
        {
            _context = context;
        }

        public IList<CarModel> CarModel { get;set; }

        public async Task OnGetAsync()
        {
            CarModel = await _context.CarModels.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int? recordid)
        {
            if (recordid == null)
            {
                return NotFound();
            }

            var carModel = await _context.CarModels.FindAsync(recordid);

            if (carModel != null)
            {
                _context.CarModels.Remove(carModel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage();
        }

    }
}

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
    public class IndexModel : PageModel
    {
        private readonly CarRentalApp.Data.CarRentalAppDbContext _context;

        public IndexModel(CarRentalApp.Data.CarRentalAppDbContext context)
        {
            _context = context;
        }

        public IList<Make> Make { get;set; }


        public async Task OnGetAsync()
        {
            Make = await _context.Makes.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int? recordid)
        {
            if (recordid == null)
            {
                return NotFound();
            }

            var makes = await _context.Makes.FindAsync(recordid);

            if (makes != null)
            {
                _context.Makes.Remove(makes);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage();
        }

    }
}

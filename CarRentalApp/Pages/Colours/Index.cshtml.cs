using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarRentalApp.Data;

namespace CarRentalApp.Pages.Colours
{
    public class IndexModel : PageModel
    {
        private readonly CarRentalApp.Data.CarRentalAppDbContext _context;

        public IndexModel(CarRentalApp.Data.CarRentalAppDbContext context)
        {
            _context = context;
        }

        public IList<Colour> Colour { get;set; }

        public async Task OnGetAsync()
        {
            Colour = await _context.Colours.ToListAsync();
        }
    }
}

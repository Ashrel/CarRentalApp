using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarRentalApp.Data;
using CarRentalApp.Repositories.Contracts;

namespace CarRentalApp.Pages.Cars
{
    public class EditModel : PageModel
    {
        private readonly IGenericRepository<Car> _carRepository;

        public EditModel(IGenericRepository<Car> carRepository)
        {
            this._carRepository = carRepository;
        }

        [BindProperty]
        public Car Car { get; set; }

        public SelectList Makes { get; set; }
        public SelectList Models { get; private set; }
        public SelectList Colours { get; private set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            Car = await _carRepository.Get(id.Value);

            if (Car == null)
            {
                return NotFound();
            }

            await LoadInitialData();


            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                await LoadInitialData();
                return Page();
            }

            _context.Attach(Car).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarExists(Car.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        public async Task<JsonResult> OnGetCarModels(int makeId)
        {
            var models = await _context.CarModels
                .Where(q => q.MakeId == makeId)
                .ToListAsync();

            return new JsonResult(models);
        }


        private async Task LoadInitialData()
        {
            Makes = new SelectList(await _context.Makes.ToListAsync(), "Id", "Name");
            Models = new SelectList(await _context.Makes.ToListAsync(), "Id", "Name");
            Colours = new SelectList(await _context.Colours.ToListAsync(), "Id", "Name");
        }

        private bool CarExists(int id)
        {
            return _context.Cars.Any(e => e.Id == id);
        }
    }
}

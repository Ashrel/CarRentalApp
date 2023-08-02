using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CarRentalApp.Data;
using Microsoft.EntityFrameworkCore;
using CarRentalApp.Repositories.Contracts;

namespace CarRentalApp.Pages.Cars
{
    public class CreateModel : PageModel
    {
        private readonly IGenericRepository<Car> _carRepository;
        private readonly IGenericRepository<CarModel> _carModelRepository;
        private readonly IGenericRepository<Colour> _colourRepository;
        private readonly IGenericRepository<Make> _makesRepository;

        public CreateModel(IGenericRepository<Car> carRepository,
            IGenericRepository<Make> makesRepository,
            IGenericRepository<CarModel> carModelRepository,
            IGenericRepository<Colour> colourRepository)
        {
            this._carRepository = carRepository;
            this._carModelRepository = carModelRepository;
            this._colourRepository = colourRepository;
            this._makesRepository = makesRepository;
        }

        [BindProperty]
        public Car Car { get; set; }

        public SelectList Makes { get; set; }

        public SelectList Colours { get; set; }

        public SelectList Models { get; set; }


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

            await _carRepository.Insert(Car);

            return RedirectToPage("./Index");
        }

        public async Task<JsonResult> OnGetCarModels(int makeId)
        {
            var models = await _context.CarModels
                .Where(q => q.MakeId == makeId)
                .ToListAsync();

            return new JsonResult(models);
        }




        public async Task LoadInitialData()
        {
            Makes = new SelectList(await _makesRepository.GetAll(), "Id", "Name");
            Models = new SelectList(await _carModelRepository.GetAll(), "Id", "Name");
            Colours = new SelectList(await _colourRepository.GetAll(), "Id", "Name");
        }
    }
} 

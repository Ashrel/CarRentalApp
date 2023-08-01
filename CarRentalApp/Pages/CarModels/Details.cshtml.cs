using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarRentalApp.Data;
using CarRentalApp.Repositories.Contracts;

namespace CarRentalApp.Pages.CarModels
{
    public class DetailsModel : PageModel
    {
        private readonly IGenericRepository<CarModel> _repository;

        public DetailsModel(IGenericRepository<CarModel> repository)
        {
            this._repository = repository;
        }

        public CarModel CarModel { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CarModel = await _repository.Get(id.Value);

            if (CarModel == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarRentalApp.Data;
using CarRentalApp.Repositories.Contracts;
using Microsoft.AspNetCore.Authorization;

namespace CarRentalApp.Pages.CarModels
{
    [Authorize(Roles = "Admin,Users")]
    public class IndexModel : PageModel
    {
        private readonly ICarModelsRepository _repository;

        public IndexModel(ICarModelsRepository repository)
        {
            this._repository = repository;
        }

        public IList<CarModel> CarModel { get;set; }

        public async Task OnGetAsync()
        {
            CarModel = await _repository.GetAll();
        }

        public async Task<IActionResult> OnPostDelete(int? recordid)
        {
            if (recordid == null)
            {
                return NotFound();
            }

            await _repository.Delete(recordid.Value);

            return RedirectToPage();
        }

    }
}

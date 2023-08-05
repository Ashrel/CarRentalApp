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

namespace CarRentalApp.Pages.Makes
{
    [Authorize(Roles = "Admin,Users")]
    public class IndexModel : PageModel
    {
        private readonly IGenericRepository<Make> _repository;

        public IndexModel(IGenericRepository<Make> repository)
        {
            this._repository = repository;
        }

        public IList<Make> Make { get;set; }


        public async Task OnGetAsync()
        {
            Make = await _repository.GetAll();
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

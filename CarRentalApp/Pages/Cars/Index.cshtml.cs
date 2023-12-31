﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarRentalApp.Data;
using CarRentalApp.Repositories.Contracts;
using Microsoft.AspNetCore.Authorization;

namespace CarRentalApp.Pages.Cars
{
    [Authorize(Roles = "Admin,Users")]

    public class IndexModel : PageModel
    {
        private readonly ICarsRepository _repository;

        public IndexModel(ICarsRepository repository)
        {
            this._repository = repository;
        }

        public IList<Car> Cars { get;set; }

        public async Task OnGetAsync()
        {
            Cars = await _repository.GetCarWithDetails();
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

    internal class AuthorizedAttribute : Attribute
    {
    }
}

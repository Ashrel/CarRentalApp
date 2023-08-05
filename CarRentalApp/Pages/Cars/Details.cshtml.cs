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
    public class DetailsModel : PageModel
    {
        private readonly ICarsRepository _repository;

        public DetailsModel(ICarsRepository repository)
        {
            this._repository = repository;
        }

        public Car Car { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Car = await _repository.GetCarWithDetails(id.Value);

            if (Car == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}

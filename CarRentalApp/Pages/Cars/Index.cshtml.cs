using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
namespace CarRentalApp.Pages.Cars
{
    public class IndexModel : PageModel
    {
        private readonly IConfiguration _configuration;

        public IndexModel(IConfiguration configuration)
        {
            this._configuration = configuration;
        }
        public string Heading { get; set; }
        public string Message { get; set; }
        public void OnGet()
        {
            Heading = "List of Cars";
            Message = _configuration["Message"];
        }
    }
}

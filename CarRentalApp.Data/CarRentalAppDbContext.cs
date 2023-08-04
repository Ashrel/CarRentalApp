using CarRentalApp.Data.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalApp.Data
{
    public class CarRentalAppDbContext : IdentityDbContext<ApplicationUser>
    {
        public CarRentalAppDbContext(DbContextOptions<CarRentalAppDbContext> options) : base(options)
        {

        }

        public DbSet<Car> Cars { get; set; }

        public DbSet<Make> Makes { get; set; }

        public DbSet<CarModel> CarModels { get; set; }

        public DbSet<Colour> Colours { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalApp.Data
{
    public class CarRentAppDbContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
    }
}

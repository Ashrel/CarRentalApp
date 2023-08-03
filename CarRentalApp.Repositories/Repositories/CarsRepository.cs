using CarRentalApp.Data;
using CarRentalApp.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalApp.Repositories.Repositories
{
    public class CarsRepository : GenericRepository<Car>, ICarsRepository
    {
        private readonly CarRentalAppDbContext _context;

        public CarsRepository(CarRentalAppDbContext context) : base(context)
        {
            this._context = context;
        }

        public async Task<List<Car>> GetCarWithDetails()
        {
            return await _context.Cars
                .Include(q => q.Make)
                .Include(q => q.CarModel)
                .Include(q => q.Colour)
                .ToListAsync();
        }

        public async Task<Car> GetCarWithDetails(int id)
        {
            return await _context.Cars
                .Include(q => q.Make)
                .Include(q => q.CarModel)
                .Include(q => q.Colour)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<bool> IsLicensePlateExists(string plateNumber)
        {
            return await _context.Cars.AnyAsync(q => q.LicensePlateNumber.ToLower().Trim() == plateNumber.ToLower().Trim());
        }
    }
}

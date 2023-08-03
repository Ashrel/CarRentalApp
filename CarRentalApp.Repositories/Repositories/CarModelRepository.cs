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
    public class CarModelRepository : GenericRepository<CarModel>, ICarModelsRepository
    {
        private readonly CarRentalAppDbContext _context;

        public CarModelRepository(CarRentalAppDbContext context) : base(context)
        {
            this._context = context;
        }

        public async Task<List<CarModel>> GetCarModelsByMake(int makeId)
        {
            var models = await _context.CarModels
               .Where(q => q.MakeId == makeId)
               .ToListAsync();

            return models;
        }

        public Task<CarModel> GetCarModelWithDetails(int id)
        {
            return _context.CarModels.Include(q => q.Make).FirstOrDefaultAsync(q => q.Id == id);
        }
    }
}

using CarRentalApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalApp.Repositories.Contracts
{
    public interface ICarsRepository : IGenericRepository<Car>
    {
        Task<Car> GetCarWithDetails(int id);
        Task<bool> IsLicensePlateExists(string plateNumber);
        Task<List<Car>> GetCarWithDetails();
    }
}

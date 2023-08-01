using CarRentalApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalApp.Repositories.Contracts
{
    public interface IGenericRepository<TEntity> where TEntity : BaseDomainEntity
    {
        Task<List<TEntity>> GetAll();
        Task<List<TEntity>> Get(int id);
        Task<bool> Exists(int id);
        Task Insert(TEntity entity);
        Task Delete(int id);
        void Update(TEntity entity);
    }
}

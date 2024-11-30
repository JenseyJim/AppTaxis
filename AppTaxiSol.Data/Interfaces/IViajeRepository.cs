using AppTaxiSol.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTaxiSol.Data.Interfaces
{
    public interface IViajeRepository
    {
        Task<IEnumerable<Viaje>> GetAllAsync();
        Task<Viaje> GetByIdAsync(int id);
        Task AddAsync(Viaje viaje);
        Task UpdateAsync(Viaje viaje);
        Task DeleteAsync(int id);
    }
}

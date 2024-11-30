using AppTaxiSol.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTaxiSol.Data.Interfaces
{
    public interface ITaxiRepository
    {
        Task<IEnumerable<Taxi>> GetAllAsync();
        Task<Taxi> GetByIdAsync(int id);
        Task AddAsync(Taxi taxi);
        Task UpdateAsync(Taxi taxi);
        Task DeleteAsync(int id);
    }
}

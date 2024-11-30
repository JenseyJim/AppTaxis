using AppTaxiSol.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTaxiSol.Data.Interfaces
{
    public interface IDetalleViajeRepository
    {
        Task<IEnumerable<DetalleViaje>> GetAllAsync();
        Task<DetalleViaje> GetByIdAsync(int id);
        Task AddAsync(DetalleViaje detalleViaje);
        Task UpdateAsync(DetalleViaje detalleViaje);
        Task DeleteAsync(int id);
    }
}

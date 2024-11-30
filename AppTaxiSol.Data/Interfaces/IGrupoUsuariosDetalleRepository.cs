using AppTaxiSol.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTaxiSol.Data.Interfaces
{
    public interface IGrupoUsuariosDetalleRepository
    {
        Task<IEnumerable<GrupoUsuariosDetalle>> GetAllAsync();
        Task<GrupoUsuariosDetalle> GetByIdAsync(int id);
        Task AddAsync(GrupoUsuariosDetalle grupoUsuariosDetalle);
        Task UpdateAsync(GrupoUsuariosDetalle grupoUsuariosDetalle);
        Task DeleteAsync(int id);
    }
}

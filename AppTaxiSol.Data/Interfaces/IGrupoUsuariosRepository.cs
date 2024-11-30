using AppTaxiSol.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTaxiSol.Data.Interfaces
{
    public interface IGrupoUsuariosRepository
    {
        Task<IEnumerable<GrupoUsuarios>> GetAllAsync();
        Task<GrupoUsuarios> GetByIdAsync(int id);
        Task AddAsync(GrupoUsuarios grupoUsuarios);
        Task UpdateAsync(GrupoUsuarios grupoUsuarios);
        Task DeleteAsync(int id);
    }
}

using AppTaxiSol.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTaxiSol.Data.Interfaces
{
    public interface IUserRoleRepository
    {
        Task<IEnumerable<UserRole>> GetAllAsync();
        Task<UserRole> GetByIdAsync(int id);
        Task AddAsync(UserRole userRole);
        Task UpdateAsync(UserRole userRole);
        Task DeleteAsync(int id);
    }
}

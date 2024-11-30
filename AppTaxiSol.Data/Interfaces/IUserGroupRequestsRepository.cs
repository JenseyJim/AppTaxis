using AppTaxiSol.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTaxiSol.Data.Interfaces
{
    public interface IUserGroupRequestsRepository
    {
        Task<IEnumerable<UserGroupRequests>> GetAllAsync();
        Task<UserGroupRequests> GetByIdAsync(int id);
        Task AddAsync(UserGroupRequests userGroupRequests);
        Task UpdateAsync(UserGroupRequests userGroupRequests);
        Task DeleteAsync(int id);
    }
}

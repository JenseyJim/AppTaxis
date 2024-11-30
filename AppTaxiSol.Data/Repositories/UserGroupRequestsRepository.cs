using AppTaxiSol.Data.Context;
using AppTaxiSol.Data.Interfaces;
using AppTaxiSol.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTaxiSol.Data.Repositories
{
    public class UserGroupRequestsRepository : IUserGroupRequestsRepository
    {
        private readonly AppTaxisContext _context;

        public UserGroupRequestsRepository(AppTaxisContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserGroupRequests>> GetAllAsync()
        {
            return await _context.UserGroupRequests.ToListAsync();
        }

        public async Task<UserGroupRequests> GetByIdAsync(int id)
        {
            return await _context.UserGroupRequests.FindAsync(id);
        }

        public async Task AddAsync(UserGroupRequests userGroupRequests)
        {
            await _context.UserGroupRequests.AddAsync(userGroupRequests);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(UserGroupRequests userGroupRequests)
        {
            _context.UserGroupRequests.Update(userGroupRequests);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _context.UserGroupRequests.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}

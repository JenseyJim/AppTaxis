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
    public class TaxiRepository : ITaxiRepository
    {
        private readonly AppTaxisContext _context;

        public TaxiRepository(AppTaxisContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Taxi>> GetAllAsync()
        {
            return await _context.Taxis.ToListAsync();
        }

        public async Task<Taxi> GetByIdAsync(int id)
        {
            return await _context.Taxis.FindAsync(id);
        }

        public async Task AddAsync(Taxi taxi)
        {
            await _context.Taxis.AddAsync(taxi);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Taxi taxi)
        {
            _context.Taxis.Update(taxi);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _context.Taxis.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}

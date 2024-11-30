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
    public class ViajeRepository : IViajeRepository
    {
        private readonly AppTaxisContext _context;

        public ViajeRepository(AppTaxisContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Viaje>> GetAllAsync()
        {

            return await _context.Viajes.ToListAsync();
        }

        public async Task<Viaje> GetByIdAsync(int id)
        {
            return await _context.Viajes.FindAsync(id);
        }

        public async Task AddAsync(Viaje viaje)
        {
            await _context.Viajes.AddAsync(viaje);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Viaje viaje)
        {
            _context.Viajes.Update(viaje);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _context.Viajes.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}

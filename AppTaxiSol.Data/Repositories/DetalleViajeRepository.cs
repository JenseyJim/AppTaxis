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
    public class DetalleViajeRepository : IDetalleViajeRepository
    {
        private readonly AppTaxisContext _context;

        public DetalleViajeRepository(AppTaxisContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DetalleViaje>> GetAllAsync()
        {
            return await _context.DetalleViajes.ToListAsync();
        }

        public async Task<DetalleViaje> GetByIdAsync(int id)
        {
            return await _context.DetalleViajes.FindAsync(id);
        }

        public async Task AddAsync(DetalleViaje detalleViaje)
        {
            await _context.DetalleViajes.AddAsync(detalleViaje);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(DetalleViaje detalleViaje)
        {
            _context.DetalleViajes.Update(detalleViaje);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _context.DetalleViajes.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}

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
    public class GrupoUsuariosDetalleRepository : IGrupoUsuariosDetalleRepository
    {
        private readonly AppTaxisContext _context;

        public GrupoUsuariosDetalleRepository(AppTaxisContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GrupoUsuariosDetalle>> GetAllAsync()
        {
            return await _context.GrupoUsuariosDetalles.ToListAsync();
        }

        public async Task<GrupoUsuariosDetalle> GetByIdAsync(int id)
        {
            return await _context.GrupoUsuariosDetalles.FindAsync(id);
        }

        public async Task AddAsync(GrupoUsuariosDetalle grupoUsuariosDetalle)
        {
            await _context.GrupoUsuariosDetalles.AddAsync(grupoUsuariosDetalle);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(GrupoUsuariosDetalle grupoUsuariosDetalle)
        {
            _context.GrupoUsuariosDetalles.Update(grupoUsuariosDetalle);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _context.GrupoUsuariosDetalles.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}

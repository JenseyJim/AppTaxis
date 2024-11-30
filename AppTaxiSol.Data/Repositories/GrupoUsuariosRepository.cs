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
    public class GrupoUsuariosRepository : IGrupoUsuariosRepository
    {
        private readonly AppTaxisContext _context;

        public GrupoUsuariosRepository(AppTaxisContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GrupoUsuarios>> GetAllAsync()
        {
            return await _context.GrupoUsuarios.ToListAsync();
        }

        public async Task<GrupoUsuarios> GetByIdAsync(int id)
        {
            return await _context.GrupoUsuarios.FindAsync(id);
        }

        public async Task AddAsync(GrupoUsuarios grupoUsuarios)
        {
            await _context.GrupoUsuarios.AddAsync(grupoUsuarios);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(GrupoUsuarios grupoUsuarios)
        {
            _context.GrupoUsuarios.Update(grupoUsuarios);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _context.GrupoUsuarios.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}

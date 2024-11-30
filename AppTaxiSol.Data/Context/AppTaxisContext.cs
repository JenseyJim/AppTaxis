using AppTaxiSol.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTaxiSol.Data.Context
{
     public class AppTaxisContext : DbContext
    {
        public AppTaxisContext(DbContextOptions<AppTaxisContext> options) : base(options) { }

        public DbSet<DetalleViaje> DetalleViajes { get; set; }
        public DbSet<GrupoUsuarios> GrupoUsuarios { get; set; }
        public DbSet<GrupoUsuariosDetalle> GrupoUsuariosDetalles { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Taxi> Taxis { get; set; }
        public DbSet<UserGroupRequests> UserGroupRequests { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Viaje> Viajes { get; set; }
    }
}

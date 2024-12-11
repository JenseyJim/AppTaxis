using AppTaxiSol.Web.Api.DTOs;
using AppTaxiSol.Web.Api.Models;

namespace AppTaxiSol.Web.Api.Services
{
    public class ViajeService
    {
        private readonly List<Viaje> _viajes = new();

        public List<ViajeDTO> GetAllViajes() =>
            _viajes.Select(v => new ViajeDTO { Id = v.Id, FechaInicio = v.FechaInicio, FechaFin = v.FechaFin, Desde = v.Desde, Hasta = v.Hasta, Calificacion = v.Calificacion, TaxiId = v.TaxiId, UserId = v.UserId }).ToList();

        public ViajeDTO GetViajeById(int id) =>
            _viajes.Where(v => v.Id == id).Select(v => new ViajeDTO { Id = v.Id, FechaInicio = v.FechaInicio, FechaFin = v.FechaFin, Desde = v.Desde, Hasta = v.Hasta, Calificacion = v.Calificacion, TaxiId = v.TaxiId, UserId = v.UserId }).FirstOrDefault();

        public void CreateViaje(ViajeDTO viaje)
        {
            var newViaje = new Viaje { Id = _viajes.Count + 1, FechaInicio = viaje.FechaInicio, FechaFin = viaje.FechaFin, Desde = viaje.Desde, Hasta = viaje.Hasta, Calificacion = viaje.Calificacion, TaxiId = viaje.TaxiId, UserId = viaje.UserId };
            _viajes.Add(newViaje);
        }

        public bool UpdateViaje(int id, ViajeDTO viaje)
        {
            var existingViaje = _viajes.FirstOrDefault(v => v.Id == id);
            if (existingViaje == null) return false;
            existingViaje.FechaInicio = viaje.FechaInicio;
            existingViaje.FechaFin = viaje.FechaFin;
            existingViaje.Desde = viaje.Desde;
            existingViaje.Hasta = viaje.Hasta;
            existingViaje.Calificacion = viaje.Calificacion;
            existingViaje.TaxiId = viaje.TaxiId;
            existingViaje.UserId = viaje.UserId;
            return true;
        }

        public bool DeleteViaje(int id)
        {
            var viaje = _viajes.FirstOrDefault(v => v.Id == id);
            if (viaje == null) return false;
            _viajes.Remove(viaje);
            return true;
        }
    }
}

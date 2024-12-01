using AppTaxiSol.Api.Dtos;
using AppTaxiSol.Data.Interfaces;
using AppTaxiSol.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppTaxiSol.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViajeController : ControllerBase
    {
        private readonly IViajeRepository _repository;

        public ViajeController(IViajeRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var viajes = await _repository.GetAllAsync();
            return Ok(viajes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var viaje = await _repository.GetByIdAsync(id);
            if (viaje == null)
                return NotFound();

            return Ok(viaje);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ViajeDto viajeDto)
        {
            var viaje = new Viaje
            {
                FechaInicio = viajeDto.FechaInicio,
                FechaFin = viajeDto.FechaFin,
                Desde = viajeDto.Desde,
                Hasta = viajeDto.Hasta,
                Calificacion = viajeDto.Calificacion,
                TaxiId = viajeDto.TaxiId,
                UserId = viajeDto.UserId
            };

            await _repository.AddAsync(viaje);
            return CreatedAtAction(nameof(GetById), new { id = viaje.Id }, viaje);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ViajeDto viajeDto)
        {
            var viaje = await _repository.GetByIdAsync(id);
            if (viaje == null)
                return NotFound();

            viaje.FechaInicio = viajeDto.FechaInicio;
            viaje.FechaFin = viajeDto.FechaFin;
            viaje.Desde = viajeDto.Desde;
            viaje.Hasta = viajeDto.Hasta;
            viaje.Calificacion = viajeDto.Calificacion;
            viaje.TaxiId = viajeDto.TaxiId;
            viaje.UserId = viajeDto.UserId;

            await _repository.UpdateAsync(viaje);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var viaje = await _repository.GetByIdAsync(id);
            if (viaje == null)
                return NotFound();

            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }
}

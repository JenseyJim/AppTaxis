using AppTaxiSol.Api.Dtos;
using AppTaxiSol.Data.Interfaces;
using AppTaxiSol.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppTaxiSol.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetalleViajeController : ControllerBase
    {
        private readonly IDetalleViajeRepository _repository;

        public DetalleViajeController(IDetalleViajeRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var detalles = await _repository.GetAllAsync();
            return Ok(detalles);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var detalle = await _repository.GetByIdAsync(id);
            if (detalle == null)
                return NotFound();

            return Ok(detalle);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] DetalleViajeDto detalleDto)
        {
            var detalle = new DetalleViaje
            {
                Fecha = detalleDto.Fecha,
                Latitude = detalleDto.Latitude,
                Longitude = detalleDto.Longitude,
                ViajeId = detalleDto.ViajeId
            };

            await _repository.AddAsync(detalle);
            return CreatedAtAction(nameof(GetById), new { id = detalle.Id }, detalle);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] DetalleViajeDto detalleDto)
        {
            var detalle = await _repository.GetByIdAsync(id);
            if (detalle == null)
                return NotFound();

            detalle.Fecha = detalleDto.Fecha;
            detalle.Latitude = detalleDto.Latitude;
            detalle.Longitude = detalleDto.Longitude;
            detalle.ViajeId = detalleDto.ViajeId;

            await _repository.UpdateAsync(detalle);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var detalle = await _repository.GetByIdAsync(id);
            if (detalle == null)
                return NotFound();

            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }
}

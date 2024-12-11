using AppTaxiSol.Web.Api.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppTaxiSol.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViajeController : ControllerBase
    {
        private readonly ViajeService _service;

        public ViajeController(ViajeService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var viajes = _service.GetAllViajes();
            return Ok(viajes);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var viaje = _service.GetViajeById(id);
            if (viaje == null) return NotFound();
            return Ok(viaje);
        }

        [HttpPost]
        public IActionResult Create(ViajeDTO viaje)
        {
            _service.CreateViaje(viaje);
            return CreatedAtAction(nameof(GetById), new { id = viaje.Id }, viaje);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, ViajeDTO viaje)
        {
            var updated = _service.UpdateViaje(id, viaje);
            if (!updated) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deleted = _service.DeleteViaje(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}

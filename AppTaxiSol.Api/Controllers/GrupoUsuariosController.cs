using AppTaxiSol.Api.Dtos;
using AppTaxiSol.Data.Interfaces;
using AppTaxiSol.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppTaxiSol.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GrupoUsuariosController : ControllerBase
    {
        private readonly IGrupoUsuariosRepository _repository;

        public GrupoUsuariosController(IGrupoUsuariosRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var grupos = await _repository.GetAllAsync();
            return Ok(grupos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var grupo = await _repository.GetByIdAsync(id);
            if (grupo == null)
                return NotFound();

            return Ok(grupo);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] GrupoUsuariosDto grupoDto)
        {
            var grupo = new GrupoUsuarios
            {
                Nombre = grupoDto.Nombre
            };

            await _repository.AddAsync(grupo);
            return CreatedAtAction(nameof(GetById), new { id = grupo.Id }, grupo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] GrupoUsuariosDto grupoDto)
        {
            var grupo = await _repository.GetByIdAsync(id);
            if (grupo == null)
                return NotFound();

            grupo.Nombre = grupoDto.Nombre;

            await _repository.UpdateAsync(grupo);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var grupo = await _repository.GetByIdAsync(id);
            if (grupo == null)
                return NotFound();

            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }
}

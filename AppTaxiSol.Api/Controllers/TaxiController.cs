using AppTaxiSol.Api.Dtos;
using AppTaxiSol.Data.Interfaces;
using AppTaxiSol.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppTaxiSol.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaxiController : ControllerBase
    {
        private readonly ITaxiRepository _repository;

        public TaxiController(ITaxiRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var taxis = await _repository.GetAllAsync();
            return Ok(taxis);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var taxi = await _repository.GetByIdAsync(id);
            if (taxi == null)
                return NotFound();

            return Ok(taxi);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TaxiDto taxiDto)
        {
            var taxi = new Taxi
            {
                Placa = taxiDto.Placa
            };

            await _repository.AddAsync(taxi);
            return CreatedAtAction(nameof(GetById), new { id = taxi.Id }, taxi);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] TaxiDto taxiDto)
        {
            var taxi = await _repository.GetByIdAsync(id);
            if (taxi == null)
                return NotFound();

            taxi.Placa = taxiDto.Placa;

            await _repository.UpdateAsync(taxi);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var taxi = await _repository.GetByIdAsync(id);
            if (taxi == null)
                return NotFound();

            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }
}

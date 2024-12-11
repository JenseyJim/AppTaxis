using AppTaxiSol.Web.Api.DTOs;
using AppTaxiSol.Web.Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppTaxiSol.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        private readonly UsuarioService _service;

        public UsuarioController(UsuarioService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var usuarios = _service.GetAllUsuarios();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var usuario = _service.GetUsuarioById(id);
            if (usuario == null) return NotFound();
            return Ok(usuario);
        }

        [HttpPost]
        public IActionResult Create(UsuarioDTO usuario)
        {
            _service.CreateUsuario(usuario);
            return CreatedAtAction(nameof(GetById), new { id = usuario.Id }, usuario);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, UsuarioDTO usuario)
        {
            var updated = _service.UpdateUsuario(id, usuario);
            if (!updated) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deleted = _service.DeleteUsuario(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}

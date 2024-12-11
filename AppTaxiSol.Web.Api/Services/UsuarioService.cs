using AppTaxiSol.Web.Api.DTOs;
using AppTaxiSol.Web.Api.Models;

namespace AppTaxiSol.Web.Api.Services
{
    public class UsuarioService
    {
        private readonly List<Usuario> _usuarios = new();

        public List<UsuarioDTO> GetAllUsuarios() =>
            _usuarios.Select(u => new UsuarioDTO { Id = u.Id, Nombre = u.Nombre, Apellido = u.Apellido, Documento = u.Documento }).ToList();

        public UsuarioDTO GetUsuarioById(int id) =>
            _usuarios.Where(u => u.Id == id).Select(u => new UsuarioDTO { Id = u.Id, Nombre = u.Nombre, Apellido = u.Apellido, Documento = u.Documento }).FirstOrDefault();

        public void CreateUsuario(UsuarioDTO usuario)
        {
            var newUsuario = new Usuario { Id = _usuarios.Count + 1, Nombre = usuario.Nombre, Apellido = usuario.Apellido, Documento = usuario.Documento };
            _usuarios.Add(newUsuario);
        }

        public bool UpdateUsuario(int id, UsuarioDTO usuario)
        {
            var existingUsuario = _usuarios.FirstOrDefault(u => u.Id == id);
            if (existingUsuario == null) return false;
            existingUsuario.Nombre = usuario.Nombre;
            existingUsuario.Apellido = usuario.Apellido;
            existingUsuario.Documento = usuario.Documento;
            return true;
        }

        public bool DeleteUsuario(int id)
        {
            var usuario = _usuarios.FirstOrDefault(u => u.Id == id);
            if (usuario == null) return false;
            _usuarios.Remove(usuario);
            return true;
        }
    }
}

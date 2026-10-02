using System.Security.Claims;
using Pagin_Web_Zoonosis.Models;

namespace Pagin_Web_Zoonosis.Services
{
    public class HistorialService
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _http;

        public HistorialService(ApplicationDbContext context, IHttpContextAccessor http)
        {
            _context = context;
            _http = http;
        }

        // No hace SaveChanges: lo hace el controlador junto con el cambio principal.
        public void Registrar(string accion, string entidad, int? idEntidad, string descripcion)
        {
            var user = _http.HttpContext?.User;
            int.TryParse(user?.FindFirstValue(ClaimTypes.NameIdentifier), out var uid);

            _context.Historiales.Add(new Historial
            {
                IDusuario = uid == 0 ? null : uid,
                UsuarioEmail = user?.Identity?.Name ?? "desconocido",
                Accion = accion,
                Entidad = entidad,
                IDentidad = idEntidad,
                Descripcion = descripcion
            });
        }
    }
}
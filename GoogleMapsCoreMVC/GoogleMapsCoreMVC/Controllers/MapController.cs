using GoogleMapsCoreMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GoogleMapsCoreMVC.Controllers
{
    public class MapController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MapController(ApplicationDbContext context)
        {
            _context = context;
        }

        // ✅ Vista principal de marcadores (tu mapa)
        public IActionResult Marcadores()
        {
            return View(); // Buscará Views/Map/Marcadores.cshtml
        }

        // ✅ Endpoint que devuelve registros como JSON
        [HttpGet]
        public async Task<IActionResult> GetRegistros()
        {
            var data = await _context.Registros
                .Include(r => r.User) // Incluye usuario
                .ThenInclude(u => u.Agentes) // Incluye agentes
                .Select(r => new
                {
                    id = r.IdReporte,
                    latitud = r.Latitud,
                    longitud = r.Longitud,
                    hora = r.HoraReporte,
                    userId = r.User.UserId,
                    userRol = r.User.UserRol,
                    email = r.User.Email,
                    agente = r.User.Agentes.FirstOrDefault() != null
                        ? r.User.Agentes.FirstOrDefault().NameAgente + " " + r.User.Agentes.FirstOrDefault().LastNameAgente
                        : "Sin nombre"
                })
                .ToListAsync();

            return Json(data);
        }
    }
}

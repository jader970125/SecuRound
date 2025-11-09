using GoogleMapsCoreMVC.Filters;
using GoogleMapsCoreMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GoogleMapsCoreMVC.Controllers
{
    [AuthFilter]
    public class MapController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MapController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Vista del mapa
        public IActionResult Marcadores()
        {
            return View();
        }

        // ✅ Endpoint para obtener SOLO el último registro por agente
        [HttpGet]
        public async Task<IActionResult> GetUltimosRegistros()
        {
            // 1️⃣ Traer registros con login asociado
            var registros = await _context.Registro
                .Include(r => r.Login)
                .OrderByDescending(r => r.HoraReporte)
                .ToListAsync();

            // 2️⃣ Tomar el último por usuario
            var ultimos = registros
                .GroupBy(r => r.Login.UserId)
                .Select(g => g.First())
                .ToList();

            // 3️⃣ Armar respuesta JSON
            var resultado = ultimos.Select(r => new
            {
                id = r.IdReporte,
                latitud = r.Latitud,
                longitud = r.Longitud,
                hora = r.HoraReporte,
                userId = r.Login.UserId,
                userRol = r.Login.UserRol,
                email = r.Login.Email,
                agente = _context.Agentes
                    .Where(a => a.UserId == r.Login.UserId)
                    .Select(a => a.NameAgente + " " + a.LastNameAgente)
                    .FirstOrDefault() ?? "Sin nombre"
            }).ToList();

            return Json(resultado);
        }

        // ✅ Endpoint para obtener TODOS los registros
        [HttpGet]
        public async Task<IActionResult> GetRegistros()
        {
            var data = await _context.Registro
                .Include(r => r.Login)
                .Select(r => new
                {
                    id = r.IdReporte,
                    latitud = r.Latitud,
                    longitud = r.Longitud,
                    hora = r.HoraReporte,
                    userId = r.Login.UserId,
                    userRol = r.Login.UserRol,
                    email = r.Login.Email,
                    agente = _context.Agentes
                        .Where(a => a.UserId == r.Login.UserId)
                        .Select(a => a.NameAgente + " " + a.LastNameAgente)
                        .FirstOrDefault() ?? "Sin nombre"
                })
                .ToListAsync();

            return Json(data);
        }
    }
}

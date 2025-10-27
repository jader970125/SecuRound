using GoogleMapsCoreMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace GoogleMapsCoreMVC.Controllers
{
    public class LoginController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LoginController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            // Si ya hay sesión iniciada, redirige al mapa directamente
            if (HttpContext.Session.GetString("UserName") != null)
            {
                return RedirectToAction("Marcadores", "Map");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                ViewBag.Error = "Debe ingresar usuario y contraseña.";
                return View();
            }

            var user = await _context.Logins
                .FirstOrDefaultAsync(u => u.UsernameLogin == username && u.UserPassword == password);

            if (user == null)
            {
                ViewBag.Error = "Usuario o contraseña incorrectos.";
                return View();
            }

            // Guarda la sesión
            HttpContext.Session.SetString("UserName", user.UsernameLogin);
            HttpContext.Session.SetString("UserRol", user.UserRol ?? "Usuario");

            // Redirigir al mapa (o Home)
            return RedirectToAction("Marcadores", "Map");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace OpenStreetMapMVC.Controllers
{
    public class MapController : Controller
    {
        // Mapa básico (puedes moverte libremente)
        public IActionResult Index()
        {
            return View();
        }

        // Varios marcadores con icono personalizado
        public IActionResult Marcadores()
        {
            return View();
        }

        // Marcadores con ventanas emergentes (popup)
        public IActionResult MarcadoresConPopup()
        {
            return View();
        }

    }
}

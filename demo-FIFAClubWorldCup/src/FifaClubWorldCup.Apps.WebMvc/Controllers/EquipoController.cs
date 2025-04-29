using Microsoft.AspNetCore.Mvc;

namespace FifaClubWorldCup.Apps.WebMvc.Controllers
{
    public class EquipoController : Controller
    {
        public IActionResult Index()
        {
            var equipoNegocio = new FifaClubWorldCup.Core.Negocio.EquipoNegocio();
            var equipos = equipoNegocio.Listado();

            return View(equipos);
        }
    }
}

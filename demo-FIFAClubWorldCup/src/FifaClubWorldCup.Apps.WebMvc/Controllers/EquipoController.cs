using FifaClubWorldCup.Core.Negocio;
using Microsoft.AspNetCore.Mvc;

namespace FifaClubWorldCup.Apps.WebMvc.Controllers
{
    public class EquipoController : Controller
    {
        private EquipoNegocio _equipoNegocio;


        public EquipoController(EquipoNegocio equipoNegocio)
        {
            _equipoNegocio = equipoNegocio;
        }


        [Route("listado-de-equipos.html")]
        [Route("list")]
        public IActionResult Index()
        {
            //var equipoNegocio = new FifaClubWorldCup.Core.Negocio.EquipoNegocio();
            var equipos = _equipoNegocio.Listado();

            return View(equipos);
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Starwars.App.Api.Controllers
{
    [Authorize]
    public class ControllerBase: Controller 
    {
    }
}

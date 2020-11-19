using IntelutionsTest.Api.Core;
using Microsoft.AspNetCore.Mvc;

namespace IntelutionsTest.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TipoPermisoController : IntelutionsTestBaseController
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(MapToApp(tipoPermisoSvc.LoadAllTypes()));
        }
    }
}

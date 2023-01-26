using Detecto.API.Case.DTOs;
using Detecto.API.Case.Services.Implementation;
using Detecto.API.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace Detecto.API.Data
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViktimaController : ControllerBase
    {
        private readonly ViktimaService _viktimaService;
        public ViktimaController(ViktimaService viktimaService)
        {
               _viktimaService = viktimaService;
        }

        [HttpGet("GetViktimat")]
                                            //ViktimaDTO
        public async Task<ActionResult<List<Viktima>>> GetViktimat()
        {
            return await _viktimaService.GetViktimat();
        }

        /*[HttpPost]
        public IActionResult AddViktima([FromBody]ViktimaDTO viktima)
        {
            _viktimaService.AddViktima(viktima);
            return Ok();
        }*/
    }
}

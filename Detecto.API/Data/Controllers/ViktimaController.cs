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
        public async Task<ActionResult<List<ViktimaDTO>>> GetViktimat()
        {
            return await _viktimaService.GetViktimat();
        }

        [HttpPost]
        public async Task<ActionResult> AddViktima(ViktimaDTO viktimaDTO)
        {
            return await _viktimaService.AddViktima(viktimaDTO);
        }
    }
}

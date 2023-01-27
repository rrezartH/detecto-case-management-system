using Detecto.API.Data.DTOs;
using Detecto.API.Data.Services.Implementation;
using Microsoft.AspNetCore.Mvc;

namespace Detecto.API.Data.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeklarataController : ControllerBase
    {
        private readonly DeklarataService _deklarataService;

        public DeklarataController(DeklarataService deklarataService)
        {
            _deklarataService = deklarataService;
        }

        [HttpGet]
        public async Task<ActionResult<List<DeklarataDTO>>> GetDeklaratat()
        {
            return await _deklarataService.GetDeklaratat();
        }
    }
}

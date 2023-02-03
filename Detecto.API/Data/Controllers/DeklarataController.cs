using Detecto.API.Data.DTOs;
using Detecto.API.Data.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Detecto.API.Data.Controllers
{
    [Route("api/Data/[controller]")]
    [ApiController]
    public class DeklarataController : ControllerBase
    {
        private readonly IDeklarataService _deklarataService;

        public DeklarataController(IDeklarataService deklarataService)
        {
            _deklarataService = deklarataService;
        }

        [HttpGet("deklaratat")]
        public async Task<ActionResult<List<DeklarataDTO>>> GetDeklaratat()
        {
            return await _deklarataService.GetDeklaratat();
        }

        [HttpGet("deklaraten/{id}")]
        public async Task<ActionResult<DeklarataDTO>> GetDeklarataById(int id)
        {
            return await _deklarataService.GetDeklarataById(id);
        }

        [HttpGet("perbajtja-e-deklarates/{id}")]
        public async Task<ActionResult<string>> GetPerbajtjaEDeklarates(int id)
        {
            return await _deklarataService.GetPerbajtjaEDeklarates(id);
        }

        [HttpDelete("deklaraten/{id}")]
        public async Task<ActionResult> DeleteDeklarata(int id)
        {
            return await _deklarataService.DeleteDeklarata(id);
        }
    }
}

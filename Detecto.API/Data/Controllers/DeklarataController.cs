using Detecto.API.Data.DTOs;
using Detecto.API.Data.Services.Implementation;
using Detecto.API.Data.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Detecto.API.Data.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeklarataController : ControllerBase
    {
        private readonly IDeklarataService _deklarataService;

        public DeklarataController(IDeklarataService deklarataService)
        {
            _deklarataService = deklarataService;
        }

        [HttpGet("GetDeklaratat")]
        public async Task<ActionResult<List<DeklarataDTO>>> GetDeklaratat()
        {
            return await _deklarataService.GetDeklaratat();
        }

        [HttpGet("GetDeklarataById")]
        public async Task<ActionResult<DeklarataDTO>> GetDeklarataById(int id)
        {
            return await _deklarataService.GetDeklarataById(id);
        }

        [HttpPost("AddDeklarata")]
        public async Task<ActionResult> AddDeklarata(DeklarataDTO deklarataDTO)
        {
            return await _deklarataService.AddDeklarata(deklarataDTO);
        }

        [HttpPut("UpdateDeklarata")]
        public async Task<ActionResult> UpdateDeklarata(int id, UpdateDeklarataDTO updateDeklarataDTO)
        {
            return await _deklarataService.UpdateDeklarata(id, updateDeklarataDTO);
        }

        [HttpDelete("DeleteDeklarata")]
        public async Task<ActionResult> DeleteDeklarata(int id)
        {
            return await _deklarataService.DeleteDeklarata(id);
        }
    }
}

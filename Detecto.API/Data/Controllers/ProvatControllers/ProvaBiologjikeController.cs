using Detecto.API.Data.DTOs.ProvatDTOs;
using Detecto.API.Data.Services.Interfaces.ProvatInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace Detecto.API.Data.Controllers.ProvatControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvaBiologjikeController : ControllerBase
    {
        private readonly IProvaBiologjikeService _provaBiologjikeService;

        public ProvaBiologjikeController(IProvaBiologjikeService provaService)
        {
            _provaBiologjikeService = provaService;
        }

        [HttpGet("GetProvatBiologjike")]
        public async Task<ActionResult<List<ProvaBiologjikeDTO>>> GetProvatBiologjike()
        {
            return await _provaBiologjikeService.GetProvatBiologjike();
        }

        [HttpGet("GetProvenBiologjikeById")]
        public async Task<ActionResult<List<ProvaBiologjikeDTO>>> GetProvenBiologjikeById(int id)
        {
            return await _provaBiologjikeService.GetProvenBiologjikeById(id);
        }

        [HttpPost("AddProvaBiologjike")]
        public async Task<ActionResult> AddProvaBiologjike(ProvaBiologjikeDTO provaDTO)
        {
            return await _provaBiologjikeService.AddProvaBiologjike(provaDTO);
        }

        [HttpPut("UpdateProvaBiologjike")]
        public async Task<ActionResult> UpdateProvaBiologjike(int id, UpdateProvaBiologjikeDTO updateProvaDTO)
        {
            return await _provaBiologjikeService.UpdateProvaBiologjike(id, updateProvaDTO);
        }

        [HttpDelete("DeleteProvaBiologjike")]
        public async Task<ActionResult> DeleteProvaBiologjike(int id)
        {
            return await _provaBiologjikeService.DeleteProvaBiologjike(id);
        }
    }
}

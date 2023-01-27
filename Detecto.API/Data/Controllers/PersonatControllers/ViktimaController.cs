using Detecto.API.Data.DTOs.PersonatDTOs;
using Detecto.API.Data.Services.Implementation.PersonatServices;
using Microsoft.AspNetCore.Mvc;

namespace Detecto.API.Data.Controllers.Personat
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

        [HttpGet("GetViktimatById")]
        public async Task<ActionResult<List<ViktimaDTO>>> GetViktimatById(int id)
        {
            return await _viktimaService.GetViktimaById(id);
        }

        [HttpPost("AddViktima")]
        public async Task<ActionResult> AddViktima(ViktimaDTO viktimaDTO)
        {
            return await _viktimaService.AddViktima(viktimaDTO);
        }

        [HttpPut("UpdateViktima")]
        public async Task<ActionResult> UpdateViktima(int id, UpdateViktimaDTO updateViktimaDTO)
        {
            return await _viktimaService.UpdateViktima(id, updateViktimaDTO);
        }

        [HttpDelete("DeleteViktimen")]
        public async Task<ActionResult> DeleteViktima(int id)
        {
            return await _viktimaService.DeleteViktima(id);
        }
    }
}

using Detecto.API.Data.DTOs.PersonatDTOs;
using Detecto.API.Data.Services.Implementation.PersonatServices;
using Detecto.API.Data.Services.Interfaces.PersonatIntrefaces;
using Microsoft.AspNetCore.Mvc;

namespace Detecto.API.Data.Controllers.Personat
{
    [Route("api/Data/[controller]")]
    [ApiController]
    public class ViktimaController : ControllerBase
    {
        private readonly IViktimaService _viktimaService;

        public ViktimaController(IViktimaService viktimaService)
        {
            _viktimaService = viktimaService;
        }

        [HttpGet("viktimat")]
        public async Task<ActionResult<List<ViktimaDTO>>> GetViktimat()
        {
            return await _viktimaService.GetViktimat();
        }

        [HttpGet("viktima/{id}")]
        public async Task<ActionResult<List<ViktimaDTO>>> GetViktimaById(int id)
        {
            return await _viktimaService.GetViktimaById(id);
        }

        [HttpGet("info/{id}")]
        public async Task<ActionResult<string>> GetInfo(int id)
        {
            return await _viktimaService.GetInfo(id);
        }

        [HttpPost("viktimen")]
        public async Task<ActionResult> AddViktima(ViktimaDTO viktimaDTO)
        {
            return await _viktimaService.AddViktima(viktimaDTO);
        }

        [HttpPut("viktimen/{id}")]
        public async Task<ActionResult> UpdateViktima(int id, UpdateViktimaDTO updateViktimaDTO)
        {
            return await _viktimaService.UpdateViktima(id, updateViktimaDTO);
        }

        [HttpDelete("viktimen/{id}")]
        public async Task<ActionResult> DeleteViktima(int id)
        {
            return await _viktimaService.DeleteViktima(id);
        }
    }
}

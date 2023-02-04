using Detecto.API.Data.DTOs;
using Detecto.API.Data.DTOs.ProvatDTOs;
using Detecto.API.Data.Services.Interfaces.ProvatInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace Detecto.API.Data.Controllers.ProvatControllers
{
    [Route("api/Data/[controller]")]
    [ApiController]
    public class ProvaBiologjikeController : ControllerBase
    {
        private readonly IProvaBiologjikeService _provaBiologjikeService;

        public ProvaBiologjikeController(IProvaBiologjikeService provaService)
        {
            _provaBiologjikeService = provaService;
        }

        [HttpGet("provat-biologjike")]
        public async Task<ActionResult<List<ProvaBiologjikeDTO>>> GetProvatBiologjike()
        {
            return await _provaBiologjikeService.GetProvatBiologjike();
        }

        [HttpGet("proven-biologjike/{id}")]
        public async Task<ActionResult<List<ProvaBiologjikeDTO>>> GetProvenBiologjikeById(int id)
        {
            return await _provaBiologjikeService.GetProvenBiologjikeById(id);
        }

        [HttpPost("proven-biologjike")]
        public async Task<ActionResult> AddProvaBiologjike(ProvaBiologjikeDTO provaDTO)
        {
            return await _provaBiologjikeService.AddProvaBiologjike(provaDTO);
        }

        [HttpPut("proven-biologjike/{id}")]
        public async Task<ActionResult> UpdateProvaBiologjike(int id, UpdateProvaBiologjikeDTO updateProvaDTO)
        {
            return await _provaBiologjikeService.UpdateProvaBiologjike(id, updateProvaDTO);
        }

        [HttpGet("krahaso-provat")]
        public async Task<ActionResult<List<GjurmaBiologjikeDTO>>> KrahasoProvat(int provaId, int personiId)
        {
            return await _provaBiologjikeService.Krahaso(provaId, personiId);
        }
    }
}

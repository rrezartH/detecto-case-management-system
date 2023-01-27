using Detecto.API.Data.DTOs;
using Detecto.API.Data.Services.Implementation;
using Microsoft.AspNetCore.Mvc;

namespace Detecto.API.Data.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GjurmaBiologjikeController : ControllerBase
    {
        private readonly GjurmaBiologjikeService _gjurmetBiologjikeService;

        public GjurmaBiologjikeController(GjurmaBiologjikeService gjurmetBiologjikeService)
        {
            _gjurmetBiologjikeService = gjurmetBiologjikeService;
        }

        [HttpGet("GetGjurmetBiologjike")]
        public async Task<ActionResult<List<GjurmaBiologjikeDTO>>> GetGjurmetBiologjike()
        {
            return await _gjurmetBiologjikeService.GetGjurmetBiologjike();
        }

        [HttpGet("GetGjurmaBiologjikeById")]
        public async Task<ActionResult<GjurmaBiologjikeDTO>> GetGjurmaBiologjikeById(int id)
        {
            return await _gjurmetBiologjikeService.GetGjurmaBiologjikeById(id);
        }

        [HttpPost("AddGjurmaBiologjike")]
        public async Task<ActionResult> AddGjurmaBiologjike(GjurmaBiologjikeDTO gjurmaBiologjikeDTO)
        {
            return await _gjurmetBiologjikeService.AddGjurmaBiologjike(gjurmaBiologjikeDTO);
        }

        [HttpPut("UpdateGjurmaBiologjike")]
        public async Task<ActionResult> UpdateGjurmaBiologjike(int id, UpdateGjurmaBiologjikeDTO updateGjurmaBiologjikeDTO)
        {
            return await _gjurmetBiologjikeService.UpdateGjurmaBiologjike(id, updateGjurmaBiologjikeDTO);
        }

        [HttpDelete("DeleteGjurmenBiologjike")]
        public async Task<ActionResult> DeleteGjurmaBiologjike(int id)
        {
            return await _gjurmetBiologjikeService.DeleteGjurmenBiologjike(id);
        }
    }
}

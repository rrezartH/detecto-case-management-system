using Detecto.API.Data.DTOs;
using Detecto.API.Data.Services.Implementation;
using Detecto.API.Data.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Detecto.API.Data.Controllers
{
    [Route("api/Data/[controller]")]
    [ApiController]
    public class GjurmaBiologjikeController : ControllerBase
    {
        private readonly IGjurmaBiologjikeService _gjurmetBiologjikeService;

        public GjurmaBiologjikeController(IGjurmaBiologjikeService gjurmetBiologjikeService)
        {
            _gjurmetBiologjikeService = gjurmetBiologjikeService;
        }

        [HttpGet("gjurmet-biologjike")]
        public async Task<ActionResult<List<GjurmaBiologjikeDTO>>> GetGjurmetBiologjike()
        {
            return await _gjurmetBiologjikeService.GetGjurmetBiologjike();
        }

        [HttpGet("gjurmen-biologjike/{id}")]
        public async Task<ActionResult<GjurmaBiologjikeDTO>> GetGjurmaBiologjikeById(int id)
        {
            return await _gjurmetBiologjikeService.GetGjurmaBiologjikeById(id);
        }

        [HttpDelete("gjurmen-biologjike/{id}")]
        public async Task<ActionResult> DeleteGjurmaBiologjike(int id)
        {
            return await _gjurmetBiologjikeService.DeleteGjurmenBiologjike(id);
        }
    }
}

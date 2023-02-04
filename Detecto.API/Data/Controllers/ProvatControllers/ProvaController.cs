using Detecto.API.Data.DTOs.ProvatDTOs;
using Detecto.API.Data.Services.Implementation.ProvatServices;
using Detecto.API.Data.Services.Interfaces.ProvatInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace Detecto.API.Data.Controllers.ProvatControllers
{
    [Route("api/Data/[controller]")]
    [ApiController]
    public class ProvaController
    {
        private readonly IProvaService _provaService;

        public ProvaController(IProvaService provaService)
        {
            _provaService = provaService;
        }

        [HttpGet("te-gjitha-provat")]
        public async Task<ActionResult<List<ProvaDTO>>> GetProvat()
        {
            return await _provaService.GetProvat();
        }

        [HttpGet("proven/{id}")]
        public async Task<ActionResult<List<ProvaDTO>>> GetProvaById(int id)
        {
            return await _provaService.GetProvaById(id);
        }

        [HttpDelete("proven/{id}")]
        public async Task<ActionResult> DeleteProva(int id)
        {
            return await _provaService.DeleteProva(id);
        }
    }
}

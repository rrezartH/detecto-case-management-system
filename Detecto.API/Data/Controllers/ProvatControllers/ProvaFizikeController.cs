using Detecto.API.Data.DTOs.PersonatDTOs;
using Detecto.API.Data.DTOs.ProvatDTOs;
using Detecto.API.Data.Services.Implementation.PersonatServices;
using Detecto.API.Data.Services.Implementation.ProvatServices;
using Detecto.API.Data.Services.Interfaces.ProvatInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace Detecto.API.Data.Controllers.Provat
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvaFizikeController : ControllerBase
    {
        private readonly IProvaFizikeService _provaFizikeService;

        public ProvaFizikeController(IProvaFizikeService provaService)
        {
            _provaFizikeService = provaService;
        }

        [HttpGet("GetProvatFizike")]
        public async Task<ActionResult<List<ProvaFizikeDTO>>> GetProvatFizike()
        {
            return await _provaFizikeService.GetProvatFizike();
        }

        [HttpGet("GetProvenFizikeById")]
        public async Task<ActionResult<List<ProvaFizikeDTO>>> GetProvenFizikeById(int id)
        {
            return await _provaFizikeService.GetProvenFizikeById(id);
        }

        [HttpPost("AddProvaFizike")]
        public async Task<ActionResult> AddProvaFizike(ProvaFizikeDTO provaDTO)
        {
            return await _provaFizikeService.AddProvaFizike(provaDTO);
        }

        [HttpPut("UpdateProvaFizike")]
        public async Task<ActionResult> UpdateProvaFizike(int id, UpdateProvaFizikeDTO updateProvaDTO)
        {
            return await _provaFizikeService.UpdateProvaFizike(id, updateProvaDTO);
        }

        [HttpDelete("DeleteProvaFizike")]
        public async Task<ActionResult> DeleteProvaFizike(int id)
        {
            return await _provaFizikeService.DeleteProvaFizike(id);
        }
    }
}

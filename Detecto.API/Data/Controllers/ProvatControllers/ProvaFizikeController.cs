using Detecto.API.Data.DTOs.PersonatDTOs;
using Detecto.API.Data.DTOs.ProvatDTOs;
using Detecto.API.Data.Services.Implementation.PersonatServices;
using Detecto.API.Data.Services.Implementation.ProvatServices;
using Detecto.API.Data.Services.Interfaces.ProvatInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace Detecto.API.Data.Controllers.Provat
{
    [Route("api/Data/[controller]")]
    [ApiController]
    public class ProvaFizikeController : ControllerBase
    {
        private readonly IProvaFizikeService _provaFizikeService;

        public ProvaFizikeController(IProvaFizikeService provaService)
        {
            _provaFizikeService = provaService;
        }

        [HttpGet("provat-fizike")]
        public async Task<ActionResult<List<ProvaFizikeDTO>>> GetProvatFizike()
        {
            return await _provaFizikeService.GetProvatFizike();
        }

        [HttpGet("proven-fizike/{id}")]
        public async Task<ActionResult<List<ProvaFizikeDTO>>> GetProvenFizikeById(int id)
        {
            return await _provaFizikeService.GetProvenFizikeById(id);
        }

        [HttpGet("per-ekzaminim")]
        public async Task<ActionResult<List<ProvaFizikeDTO>>> GetPerEkzaminim(bool b)
        {
            return await _provaFizikeService.GetPerEkzaminim(b);
        }

        [HttpGet("me-gjurme-biologjike")]
        public async Task<ActionResult<List<ProvaFizikeDTO>>> GetMeGjurmeBiologjike(bool b)
        {
            return await _provaFizikeService.GetMeGjurmeBiologjike(b);
        }

        [HttpGet("sipas-rrezikut")]
        public async Task<ActionResult<List<ProvaFizikeDTO>>> GetSipasRrezikut(string str)
        {
            return await _provaFizikeService.GetSipasRrezikut(str);
        }

        [HttpPost("proven-fizike")]
        public async Task<ActionResult> AddProvaFizike(ProvaFizikeDTO provaDTO)
        {
            return await _provaFizikeService.AddProvaFizike(provaDTO);
        }

        [HttpPut("proven-fizike/{id}")]
        public async Task<ActionResult> UpdateProvaFizike(int id, UpdateProvaFizikeDTO updateProvaDTO)
        {
            return await _provaFizikeService.UpdateProvaFizike(id, updateProvaDTO);
        }

        [HttpDelete("proven-fizike/{id}")]
        public async Task<ActionResult> DeleteProvaFizike(int id)
        {
            return await _provaFizikeService.DeleteProvaFizike(id);
        }

    }
}

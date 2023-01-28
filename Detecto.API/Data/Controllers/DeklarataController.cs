using Detecto.API.Data.DTOs;
using Detecto.API.Data.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Detecto.API.Data.Controllers
{
    [Route("api/Data/[controller]")]
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

        [HttpGet("GetDeklarataById/{id}")]
        public async Task<ActionResult<DeklarataDTO>> GetDeklarataById(int id)
        {
            return await _deklarataService.GetDeklarataById(id);
        }

        [HttpGet("GetDeklaratatEPersonit/{id}")]
        public async Task<ActionResult<List<DeklarataDTO>>> GetDeklaratatEPersonit(int id)
        {
            return await _deklarataService.GetDeklaratatEPersonit(id);
        }

        [HttpGet("GetPerbajtjaEDeklarates/{id}")]
        public async Task<ActionResult<string>> GetPerbajtjaEDeklarates(int id)
        {
            return await _deklarataService.GetPerbajtjaEDeklarates(id);
        }

        [HttpPost("AddDeklarata")]
        public async Task<ActionResult> AddDeklarata(DeklarataDTO deklarataDTO)
        {
            return await _deklarataService.AddDeklarata(deklarataDTO);
        }

        [HttpPut("UpdateDeklarata/{id}")]
        public async Task<ActionResult> UpdateDeklarata(int id, UpdateDeklarataDTO updateDeklarataDTO)
        {
            return await _deklarataService.UpdateDeklarata(id, updateDeklarataDTO);
        }

        [HttpDelete("DeleteDeklarata/{id}")]
        public async Task<ActionResult> DeleteDeklarata(int id)
        {
            return await _deklarataService.DeleteDeklarata(id);
        }

        /*[HttpPost("KrahasoDeklaratat")]
        public void Compare(string deklarata1, string deklarata2)
        {
            _deklarataService.Compare(deklarata1, deklarata2);
        }*/
    }
}

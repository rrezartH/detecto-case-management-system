using Detecto.API.Data.DTOs;
using Detecto.API.Data.DTOs.PersonatDTOs;
using Detecto.API.Data.Services.Implementation.PersonatServices;
using Detecto.API.Data.Services.Interfaces.PersonatIntrefaces;
using Microsoft.AspNetCore.Mvc;

namespace Detecto.API.Data.Controllers.Personat
{
    [Route("api/Data/[controller]")]
    [ApiController]
    public class IDyshuariController : ControllerBase
    {
        private readonly IiDyshuariService _iDyshuariService;

        public IDyshuariController(IiDyshuariService iDyshuariSrv)
        {
            _iDyshuariService = iDyshuariSrv;
        }

        [HttpGet("te-dyshuarit")]
        public async Task<ActionResult<List<iDyshuariDTO>>> GetTeDyshuarit()
        {
            return await _iDyshuariService.GetTeDyshuarit();
        }

        [HttpGet("i-dyshuari/{id}")]
        public async Task<ActionResult> GetTeDyshuarinById(int id)
        {
            return await _iDyshuariService.GetTeDyshuarinById(id);
        }

        [HttpGet("dyshimi-mbi-te-dyshuarin/{id}")]
        public async Task<ActionResult<string>> GetDyshimiMbiTeDyshuarin(int id)
        {
            return await _iDyshuariService.GetDyshimiMbiTeDyshuarin(id);
        }

        [HttpGet("info/{id}")]
        public async Task<ActionResult<string>> GetInfo(int id)
        {
            return await _iDyshuariService.GetInfo(id);
        }

        [HttpPost("i-dyshuari")]
        public async Task<ActionResult> AddTeDyshuarin(iDyshuariDTO iDyshuariDto)
        {
            return await _iDyshuariService.AddTeDyshuarin(iDyshuariDto);
        }

        /*[HttpPost("shto-deklarata")]
        public async Task<ActionResult> AddDeklarata(DeklarataDTO deklarataDTO)
        {
            return await _iDyshuariService.AddDeklarata(deklarataDTO);
        }*/

        [HttpPut("te-dyshuarin/{id}")]
        public async Task<ActionResult> UpdateTeDyshuarin(int id, UpdateiDyshuariDTO UpdateiDyshuariDto)
        {
            return await _iDyshuariService.UpdateTeDyshuarin(id, UpdateiDyshuariDto);
        }

        [HttpDelete("te-dyshuarin/{id}")]
        public async Task<ActionResult> DeleteTeDyshuarin(int id)
        {
            return await _iDyshuariService.DeleteTeDyshuarin(id);
        }
    }
}

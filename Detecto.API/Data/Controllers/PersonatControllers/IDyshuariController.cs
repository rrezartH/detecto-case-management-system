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

        [HttpGet("GetTeDyshuarit")]
        public async Task<ActionResult<List<iDyshuariDTO>>> GetTeDyshuarit()
        {
            return await _iDyshuariService.GetTeDyshuarit();
        }

        [HttpGet("GetTeDyshuaritById/{id}")]
        public async Task<ActionResult<iDyshuariDTO>> GetTeDyshuarinById(int id)
        {
            return await _iDyshuariService.GetTeDyshuarinById(id);
        }

        [HttpGet("GetDyshimiMbiTeDyshuarin/{id}")]
        public async Task<ActionResult<string>> GetDyshimiMbiTeDyshuarin(int id)
        {
            return await _iDyshuariService.GetDyshimiMbiTeDyshuarin(id);
        }

        [HttpPost("AddTeDyshuar")]
        public async Task<ActionResult> AddTeDyshuarin(iDyshuariDTO iDyshuariDto)
        {
            return await _iDyshuariService.AddTeDyshuarin(iDyshuariDto);
        }

        [HttpPut("UpdateTeDyshuarin/{id}")]
        public async Task<ActionResult> UpdateTeDyshuarin(int id, UpdateiDyshuariDTO UpdateiDyshuariDto)
        {
            return await _iDyshuariService.UpdateTeDyshuarin(id, UpdateiDyshuariDto);
        }

        [HttpDelete("DeleteTeDyshuarin/{id}")]
        public async Task<ActionResult> DeleteTeDyshuarin(int id)
        {
            return await _iDyshuariService.DeleteTeDyshuarin(id);
        }
    }
}

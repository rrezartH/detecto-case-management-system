using Detecto.API.Data.DTOs.PersonatDTOs;
using Detecto.API.Data.Services.Implementation.PersonatServices;
using Detecto.API.Data.Services.Interfaces.PersonatIntrefaces;
using Microsoft.AspNetCore.Mvc;

namespace Detecto.API.Data.Controllers.Personat
{
    [Route("api/[controller]")]
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

        [HttpGet("GetTeDyshuaritById")]
        public async Task<ActionResult<iDyshuariDTO>> GetTeDyshuarinById(int id)
        {
            return await _iDyshuariService.GetTeDyshuarinById(id);
        }

        [HttpPost("AddTeDyshuar")]
        public async Task<ActionResult> AddTeDyshuarin(iDyshuariDTO iDyshuariDto)
        {
            return await _iDyshuariService.AddTeDyshuarin(iDyshuariDto);
        }

        [HttpPut("UpdateTeDyshuarin")]
        public async Task<ActionResult> UpdateTeDyshuarin(int id, UpdateiDyshuariDTO UpdateiDyshuariDto)
        {
            return await _iDyshuariService.UpdateTeDyshuarin(id, UpdateiDyshuariDto);
        }

        [HttpDelete("DeleteTeDyshuarin")]
        public async Task<ActionResult> DeleteTeDyshuarin(int id)
        {
            return await _iDyshuariService.DeleteTeDyshuarin(id);
        }
    }
}

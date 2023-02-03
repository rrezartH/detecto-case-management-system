using Detecto.API.Data.DTOs;
using Detecto.API.Data.DTOs.PersonatDTOs;
using Detecto.API.Data.Models;
using Detecto.API.Data.Services.Implementation.PersonatServices;
using Detecto.API.Data.Services.Interfaces.PersonatIntrefaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;

namespace Detecto.API.Data.Controllers.Personat
{
    [Route("api/Data/[controller]")]
    [ApiController]
    public class DeshmitariController : ControllerBase
    {
        private readonly IDeshmitariService _deshmitariService;

        public DeshmitariController(IDeshmitariService deshmitariService)
        {
            _deshmitariService = deshmitariService;
        }

        [HttpGet("deshmitaret")]
        public async Task<ActionResult<List<DeshmitariDTO>>> GetDeshmitaret()
        {
            return await _deshmitariService.GetDeshmitaret();
        }

        [HttpGet("deshmitari/{id}")]
        public async Task<ActionResult> GetDeshmitariById(int id)
        {
            return await _deshmitariService.GetDeshmitariById(id);
        }

        [HttpGet("a-dyshohet/{id}")]
        public async Task<ActionResult<bool>> ADyshohet(int id)
        {
            return await _deshmitariService.ADyshohet(id);
        }

        [HttpGet("a-vezhgohet/{id}")]
        public async Task<ActionResult<bool>> AVezhgohet(int id)
        {
            return await _deshmitariService.AVezhgohet(id);
        }

        [HttpGet("info/{id}")]
        public async Task<ActionResult<string>> GetInfo(int id)
        {
            return await _deshmitariService.GetInfo(id);
        }

        [HttpPost("deshmitar")]
        public async Task<ActionResult> AddDeshmitari(DeshmitariDTO deshmitariDTO)
        {
            return await _deshmitariService.AddDeshmitari(deshmitariDTO);
        }

        [HttpPut("deshmitari/{id}")]
        public async Task<ActionResult> UpdateDeshmitari(int id, UpdateDeshmitariDTO updateDeshmitariDTO)
        {
            return await _deshmitariService.UpdateDeshmitari(id, updateDeshmitariDTO);
        }

        [HttpDelete("deshmitari/{id}")]
        public async Task<ActionResult> DeleteDeshmitari(int id)
        {
            return await _deshmitariService.DeleteDeshmitari(id);
        }

        [HttpPatch("ruaj-si-i-dyshuar/{id}")]
        public async Task<ActionResult> RuajSiIDyshuar(int id)
        {
            return await _deshmitariService.RuajSiIDyshuar(id);
        }
    }
}
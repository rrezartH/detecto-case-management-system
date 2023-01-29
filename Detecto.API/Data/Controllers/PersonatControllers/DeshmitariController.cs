using Detecto.API.Data.DTOs.PersonatDTOs;
using Detecto.API.Data.Services.Interfaces.PersonatIntrefaces;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet("GetDeshmitaret")]
        public async Task<ActionResult<List<DeshmitariDTO>>> GetViktimat()
        {
            return await _deshmitariService.GetDeshmitaret();
        }

        [HttpGet("GetDeshmitaretById/{id}")]
        public async Task<ActionResult<List<DeshmitariDTO>>> GetDeshmitaritById(int id)
        {
            return await _deshmitariService.GetDeshmitariById(id);
        }

        [HttpGet("ADyshohet/{id}")]
        public async Task<ActionResult<bool>> ADyshohet(int id)
        {
            return await _deshmitariService.ADyshohet(id);
        }

        [HttpGet("AVezhgohet/{id}")]
        public async Task<ActionResult<bool>> AVezhgohet(int id)
        {
            return await _deshmitariService.AVezhgohet(id);
        }

        [HttpGet("GetInfo/{id}")]
        public async Task<ActionResult<string>> GetInfo(int id)
        {
            return await _deshmitariService.GetInfo(id);
        }

        [HttpPost("AddDeshmitari")]
        public async Task<ActionResult> AddDeshmitari(DeshmitariDTO deshmitariDTO)
        {
            return await _deshmitariService.AddDeshmitari(deshmitariDTO);
        }

        [HttpPut("UpdateDeshmitari/{id}")]
        public async Task<ActionResult> UpdateDeshmitari(int id, UpdateDeshmitariDTO updateDeshmitariDTO)
        {
            return await _deshmitariService.UpdateDeshmitari(id, updateDeshmitariDTO);
        }

        [HttpDelete("DeleteDeshmitari/{id}")]
        public async Task<ActionResult> DeleteDeshmitari(int id)
        {
            return await _deshmitariService.DeleteDeshmitari(id);
        }

    }
}
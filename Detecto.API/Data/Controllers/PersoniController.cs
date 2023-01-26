using Detecto.API.Case.DTOs;
using Detecto.API.Case.Services.Implementation;
using Detecto.API.Data.DTOs;
using Detecto.API.Data.Models;
using Detecto.API.Data.Services.Implementation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Detecto.API.Data
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersoniController : ControllerBase
    {
        private readonly ViktimaService _viktimaService;
        private readonly DeshmitariService _deshmitariService;
        private readonly PersoniService _personiService;

        public PersoniController(PersoniService personiService, ViktimaService viktimaService, DeshmitariService deshmitariService)
        {
            _personiService = personiService;
            _viktimaService = viktimaService;
            _deshmitariService = deshmitariService;
        }

        [HttpGet("GetPersonat")]
        public async Task<ActionResult<List<PersoniDTO>>> GetPersonat()
        {
            return await _personiService.GetPersonat();
        }

        [HttpGet("GetViktimat")]
        public async Task<ActionResult<List<ViktimaDTO>>> GetViktimat()
        {
            return await _viktimaService.GetViktimat();
        }

        [HttpGet("GetDëshmitarët")]
        public async Task<ActionResult<List<DeshmitariDTO>>> GetDeshmitaret()
        {
            return await _deshmitariService.GetDeshmitaret();
        }

        [HttpGet("GetViktimatById")]
        public async Task<ActionResult<List<ViktimaDTO>>> GetViktimatById(int id)
        {
            return await _viktimaService.GetViktimaById(id);
        }

        [HttpPost("AddPersoni")]
        public async Task<ActionResult> AddPersoni(PersoniDTO personiDTO, string str)
        {
                return await _personiService.AddPersoni(personiDTO, str);
        }

        [HttpPost("AddViktima")]
        public async Task<ActionResult> AddViktima(ViktimaDTO viktimaDTO)
        {
            return await _viktimaService.AddViktima(viktimaDTO);
        }

        [HttpPut("UpdateViktima")]
        public async Task<ActionResult> UpdateViktima(int id, UpdateViktimaDTO updateViktimaDTO)
        {
            return await _viktimaService.UpdateViktima(id, updateViktimaDTO);
        }

        [HttpDelete("DeleteViktimen")]
        public async Task<ActionResult> DeleteViktima(int id)
        {
            return await _viktimaService.DeleteViktima(id);
        }
    }
}

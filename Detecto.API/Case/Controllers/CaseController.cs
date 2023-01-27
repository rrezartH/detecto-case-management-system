using Detecto.API.Case.DTOs;
using Detecto.API.Case.Services.Implementation;
using Detecto.API.Data.DTOs.PersonatDTOs;
using Detecto.API.Data.Services.Implementation.PersonatServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Detecto.API.Case.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CaseController : ControllerBase
    {
        private readonly CaseService _caseService;

        public CaseController(CaseService caseService)
        {
            _caseService = caseService;
        }

        [HttpGet("GetCases")]
        public async Task<ActionResult<List<GetCaseDTO>>> GetCases()
        {
            return await _caseService.GetCases();
        }

        [HttpGet("GetCaseById")]
        public async Task<ActionResult<List<GetCaseDTO>>> GetCaseById(int id)
        {
            return await _caseService.GetCaseById(id);
        }

        [HttpPost("AddCase")]
        public async Task<ActionResult> AddCase(AddCaseDTO caseDTO)
        {
            return await _caseService.AddCase(caseDTO);
        }

        [HttpPut("UpdateCase/{id}")]
        public async Task<ActionResult> UpdateCase(int id, UpdateCaseDTO updateCaseDTO)
        {
            return await _caseService.UpdateCase(id, updateCaseDTO);
        }

        [HttpDelete("DeleteCase/{id}")]
        public async Task<ActionResult> DeleteCase(int id)
        {
            return await _caseService.DeleteCase(id);
        }
    }
}

using Detecto.API.Case.DTOs;
using Detecto.API.Case.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Detecto.API.Case.Controllers
{
    [Route("api/Case/[controller]")]
    [ApiController]
    public class CaseController : ControllerBase
    {
        private readonly ICaseService _caseService;

        public CaseController(ICaseService caseService)
        {
            _caseService = caseService;
        }

        [HttpGet("cases")]
        public async Task<ActionResult<List<GetCasesDetailsDTO>>> GetCases()
        {
            return await _caseService.GetCases();
        }

        [HttpGet("case/{id}")]
        public async Task<ActionResult<List<GetCaseDTO>>> GetCaseById(int id)
        {
            return await _caseService.GetCaseById(id);
        }

        [HttpPost("case")]
        public async Task<ActionResult> AddCase(AddCaseDTO caseDTO)
        {
            return await _caseService.AddCase(caseDTO);
        }

        [HttpPut("case/{id}")]
        public async Task<ActionResult> UpdateCase(int id, UpdateCaseDTO updateCaseDTO)
        {
            return await _caseService.UpdateCase(id, updateCaseDTO);
        }

        [HttpDelete("case/{id}")]
        public async Task<ActionResult> DeleteCase(int id)
        {
            return await _caseService.DeleteCase(id);
        }

        [HttpPatch("change-case-status/{id}")]
        public async Task<ActionResult> ChangeCaseStatus(int id, string status)
        {
            return await _caseService.ChangeCaseStatus(id, status);
        }
    }
}

using Detecto.API.Case.DTOs;
using Detecto.API.Case.Services.Implementation;
using Detecto.API.Data.DTOs.PersonatDTOs;
using Detecto.API.Data.Services.Implementation.PersonatServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Detecto.API.Case.Controllers
{
    [Route("api/Case/[controller]")]
    [ApiController]
    public class CaseController : ControllerBase
    {
        private readonly CaseService _caseService;

        public CaseController(CaseService caseService)
        {
            _caseService = caseService;
        }

        [HttpGet("get-cases")]
        public async Task<ActionResult<List<GetCasesDetailsDTO>>> GetCases()
        {
            return await _caseService.GetCases();
        }

        [HttpGet("get-case-by-id/{id}")]
        public async Task<ActionResult<List<GetCaseDTO>>> GetCaseById(int id)
        {
            return await _caseService.GetCaseById(id);
        }

        [HttpPost("add-case")]
        public async Task<ActionResult> AddCase(AddCaseDTO caseDTO)
        {
            return await _caseService.AddCase(caseDTO);
        }

        [HttpPut("update-case/{id}")]
        public async Task<ActionResult> UpdateCase(int id, UpdateCaseDTO updateCaseDTO)
        {
            return await _caseService.UpdateCase(id, updateCaseDTO);
        }

        [HttpDelete("delete-case/{id}")]
        public async Task<ActionResult> DeleteCase(int id)
        {
            return await _caseService.DeleteCase(id);
        }
    }
}

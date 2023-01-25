using Detecto.API.Case.DTOs;
using Detecto.API.Case.Services.Implementation;
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

        [HttpGet("GetCase")]
        public async Task<ActionResult<List<GetCaseDTO>>> GetCases()
        {
            return await _caseService.GetCases();
        }
    }
}

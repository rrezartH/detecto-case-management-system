using Detecto.API.Case.DTOs;
using Detecto.API.Suspicion.DTOs;
using Detecto.API.Suspicion.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Detecto.API.Suspicion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DyshimiController : ControllerBase
    {

            private readonly IDyshimiService _dyshimiService;

            public DyshimiController(IDyshimiService dyshimiService)
            {
                _dyshimiService = dyshimiService;
            }

            [HttpGet("dyshimet")]
            public async Task<IEnumerable<DyshimiDTO>> GetDyshimis()
            {
                return await _dyshimiService.GetDyshimet();

            }

            [HttpGet("get-dyshimi-by-id/{id}")]
            public async Task<ActionResult<DyshimiDTO>> GetDyshimiByID(int id)
            {
                return await _dyshimiService.GetDyshimiByID(id);
                //if (dyshimi == null)
                //    return NotFound();

                //return Ok(dyshimi);
            }

            [HttpPost("add-dyshimi")]
            public async Task<ActionResult<DyshimiDTO>> CreateDyshimi(DyshimiDTO dyshimiDto)
            {
                return await _dyshimiService.CreateDyshimi(dyshimiDto);

            }

            [HttpPut("put-dyshimi/{id}")]
            public async Task<ActionResult<DyshimiDTO>> UpdateDyshimi(UpdateDyshimiDTO dyshimiDto, int id)
            {
                return await _dyshimiService.UpdateDyshimi(dyshimiDto, id);
                //if (dyshimi == null)
                //    return NotFound();

                //return Ok(dyshimi);
            }

            [HttpDelete("delete-dyshimi/{id}")]
            public async Task<ActionResult> DeleteDyshimi(int id)
            {
                return await _dyshimiService.DeleteDyshimi(id);
                //if (dyshimi == null)
                //    return NotFound();

                //return Ok();
            }
        }
}

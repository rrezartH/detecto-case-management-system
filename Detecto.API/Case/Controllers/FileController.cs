using Detecto.API.Case.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace Detecto.API.Case.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IFileService _uploadService;

        public FileController(IFileService uploadService)
        {
            _uploadService = uploadService;
        }


        [HttpPost("upload/{caseId}")]
        public async Task<IActionResult> PostSingleFile(IFormFile fileData, int caseId)
        {
            if (fileData == null)
                return BadRequest("File data is null.");
            if (fileData.Length == 0) return BadRequest("File is empty.");


            await _uploadService.PostFileAsync(fileData, caseId);
            return Ok("File uploaded successfully.");
        }

        [HttpGet("download/{id}")]
        public async Task<IActionResult> DownloadFileById(int id)
        {
            await _uploadService.DownloadFileById(id);
            return Ok("File downloaded successfully.");
        }
    }
}

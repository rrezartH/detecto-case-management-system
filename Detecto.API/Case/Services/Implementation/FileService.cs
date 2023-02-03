using Detecto.API.Case.Models;
using Detecto.API.Case.Services.Interfaces;
using Detecto.API.Configurations;
using NuGet.Packaging;

namespace Detecto.API.Case.Services.Implementation
{
    public class FileService : IFileService
    {
        private readonly DetectoDbContext _context;
        private IFileUpload? _fileUpload;
        private readonly Dictionary<string, IFileUpload> supportedFiles = new()
        {
            {"application/pdf", new PdfService() },
            {"image/png", new PngService() }
        };

        public FileService(DetectoDbContext context)
        {
            _context = context;
        }

        public async Task PostFileAsync(IFormFile fileData, int caseId)
        {
            try
            {
                _fileUpload = supportedFiles[fileData.ContentType];
                if (_fileUpload == null)
                    throw new Exception("Unsupported file type.");

                var uploadedFile = _fileUpload.UploadFile(fileData, caseId);
                await _context.Files.AddAsync(uploadedFile);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task DownloadFileById(int id)
        {
            try
            {
                var file = await _context.Files.FindAsync(id);

                if (file != null)
                {
                    var content = new System.IO.MemoryStream(file.FileData);
                    var path = Path.Combine(
                        Directory.GetCurrentDirectory(), "FilesDownloaded",
                        file.FileName);

                    await CopyStream(content, path);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private async Task CopyStream(Stream stream, string downloadPath)
        {
            using (var fileStream = new FileStream(downloadPath, FileMode.Create, FileAccess.Write))
            {
                await stream.CopyToAsync(fileStream);
            }
        }
    }
}

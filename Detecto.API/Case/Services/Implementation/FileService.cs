using Detecto.API.Case.Models;
using Detecto.API.Case.Services.Interfaces;
using Detecto.API.Configurations;

namespace Detecto.API.Case.Services.Implementation
{
    public class FileService : IFileService
    {
        private readonly DetectoDbContext _context;

        public FileService(DetectoDbContext context)
        {
            _context = context;
        }

        public async Task PostFileAsync(IFormFile fileData, int caseId)
        {
            try
            {
                DFile file = new();

                if (fileData.ContentType.Equals("application/pdf"))
                {
                    file = new PDF()
                    {
                        CaseId = caseId,
                        FileName = fileData.FileName,
                    };
                    (file as PDF).SetFileSize(fileData);
                }
                else if (fileData.ContentType.Equals("image/png"))
                {
                    file = new PNG()
                    {
                        CaseId = caseId,
                        FileName = fileData.FileName,
                    };
                }

                if (file == null)
                {
                    throw new Exception("Unsupported file type.");
                }


                using (var stream = new MemoryStream())
                {
                    fileData.CopyTo(stream);
                    file.FileData = stream.ToArray();
                }

                var result = _context.Files.Add(file);
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

        public async Task CopyStream(Stream stream, string downloadPath)
        {
            using (var fileStream = new FileStream(downloadPath, FileMode.Create, FileAccess.Write))
            {
                await stream.CopyToAsync(fileStream);
            }
        }
    }
}

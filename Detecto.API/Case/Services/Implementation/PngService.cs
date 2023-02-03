using Detecto.API.Case.Models;
using Detecto.API.Case.Services.Interfaces;
using Detecto.API.Configurations;

namespace Detecto.API.Case.Services.Implementation
{
    public class PngService: IFileUpload
    {
        public PngService() { }

        public DFile UploadFile(IFormFile uploadedFile, int caseId)
        {
            try
            {
                PNG png = new()
                {
                    CaseId = caseId,
                    FileName = uploadedFile.FileName
                };

                var stream = new MemoryStream();

                uploadedFile.CopyTo(stream);
                png.FileData = stream.ToArray();
                return png;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

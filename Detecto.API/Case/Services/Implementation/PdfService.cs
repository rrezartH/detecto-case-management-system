using Detecto.API.Case.Models;
using Detecto.API.Case.Services.Interfaces;
using Detecto.API.Configurations;

namespace Detecto.API.Case.Services.Implementation
{
    public class PdfService: IFileUpload
    {
        public PdfService() { }

        public DFile UploadFile(IFormFile uploadedFile, int caseId)
        {
            try
            {
                PDF pdf = new()
                {
                    CaseId = caseId,
                    FileName = uploadedFile.FileName,
                    FileSize = uploadedFile.Length
                };

                var stream = new MemoryStream();

                uploadedFile.CopyTo(stream);
                pdf.FileData = stream.ToArray();
                return pdf;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

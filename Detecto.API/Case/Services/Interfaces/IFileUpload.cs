using Detecto.API.Case.Models;

namespace Detecto.API.Case.Services.Interfaces
{
    public interface IFileUpload
    {
        public DFile UploadFile(IFormFile uploadedFile, int caseId);
    }
}

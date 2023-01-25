using Detecto.API.Case.Services.Interfaces;

namespace Detecto.API.Case.Models
{
    public class Photo : IFileUploader
    {
        public Task<bool> UploadFile(IFormFile file)
        {
            throw new NotImplementedException();
        }
    }
}

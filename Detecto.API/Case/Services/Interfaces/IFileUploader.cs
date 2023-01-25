namespace Detecto.API.Case.Services.Interfaces
{
    public interface IFileUploader
    {
        Task<bool> UploadFile(IFormFile file);
    }
}

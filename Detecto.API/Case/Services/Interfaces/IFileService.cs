namespace Detecto.API.Case.Services.Interfaces
{
    public interface IFileService
    {
        public Task PostFileAsync(IFormFile fileData, int caseId);

        public Task DownloadFileById(int fileName);
    }
}

using Detecto.API.Case.Services.Interfaces;

namespace Detecto.API.Case.Models
{
    public class DFile
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        //public IFileUploader FileUploader { get; set; }
    }
}

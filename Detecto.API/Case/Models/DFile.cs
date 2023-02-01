using Detecto.API.Case.Services.Interfaces;

namespace Detecto.API.Case.Models
{
    public class DFile
    {
        public int Id { get; set; }
        public string FileName { get; set; } = null!;
        public byte[] FileData { get; set; } = null!;
        public int CaseId { get; set; }
    }
}


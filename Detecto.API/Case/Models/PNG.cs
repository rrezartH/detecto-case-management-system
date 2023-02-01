using Detecto.API.Case.Services.Interfaces;

namespace Detecto.API.Case.Models
{
    public class PNG : DFile
    {
        public DateTime DateUploaded { get; set; } = DateTime.Now;

    }
}

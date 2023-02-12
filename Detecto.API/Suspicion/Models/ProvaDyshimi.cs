using Detecto.API.Data.Models;
using Detecto.API.Data.Services.Interfaces.PersonatIntrefaces;

namespace Detecto.API.Suspicion.Models
{
    public class ProvaDyshimi :Prova
    {
        public int provaID { get; set; }
        public string kategoria { get; set; }
        public bool iPerketTeDyshuarit { get; set; }
        public string relevanca { get; set; }
    }
}

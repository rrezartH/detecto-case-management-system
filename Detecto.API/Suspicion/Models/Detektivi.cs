using Detecto.API.Case.Models;

namespace Detecto.API.Suspicion.Models
{
    public class Detektivi 
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string Hulumtimi { get; set; }
    }
}

using Detecto.API.Data.Models;

namespace Detecto.API.Suspicion.Models
{
    public class Dyshimi
    {
        public int Id { get; set; }
        public int? CaseId { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public DateTime DateEqeshtjes { get; set; } 

        public ICollection<Prova> provat { get; set; }
        public ICollection<Personi> personat { get; set; }

    }
}

namespace Detecto.API.Data.Models
{
    public class GjurmaBiologjike
    {
        public int Id { get; set; }
        public string Emri { get; set; } = null!;
        public string Lloji { get; set; } = null!;
        public string Specifikimi { get; set; } = null!;

        // Composition requires the relationship to be exclusive, so the Personi property
        // should be mandatory
        public int PersoniId { get; set; }
        public Personi Personi { get; set; } = null!;
    }
}
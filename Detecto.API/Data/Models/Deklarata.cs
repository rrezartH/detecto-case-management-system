namespace Detecto.API.Data.Models
{
    public class Deklarata
    {
        public int Id { get; set; }
        public DateTime KohaEMarrjes { get; set; }
        public string Permbajtja { get; set; } = null!;

        // Composition requires the relationship to be exclusive, so the Personi property
        // should be mandatory
        public int PersoniId { get; set; }
        public Personi Personi { get; set; } = null!;
    }
}
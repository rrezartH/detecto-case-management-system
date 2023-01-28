namespace Detecto.API.Data.Models
{
    public class Deklarata
    {
        public int Id { get; set; }
        public DateTime KohaEMarrjes { get; set; }
        public string Permbajtja { get; set; } = null!;

        //Navigation Properties
        public int PersoniId { get; set; }
        public Personi Personi { get; set; } = null!;
    }
}

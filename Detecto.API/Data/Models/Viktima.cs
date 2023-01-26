namespace Detecto.API.Data.Models
{
    public class Viktima : Personi
    {
        public string Vendi { get; set; } = null!;
        public DateTime Koha { get; set; }
        public string? Menyra { get; set; }
        public string Gjendja { get; set; } = null!;
    }
}

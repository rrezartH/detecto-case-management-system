namespace Detecto.API.Data.Models
{
    public class ProvaBiologjike : Prova
    {
        public string Lloji { get; set; } = null!;
        public string Specifikimi { get; set; } = null!;
        public string? TeknikaENxjerrjes { get; set; }
    }
}

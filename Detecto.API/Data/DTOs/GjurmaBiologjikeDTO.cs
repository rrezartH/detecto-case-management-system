namespace Detecto.API.Data.DTOs
{
    public class GjurmaBiologjikeDTO
    {
        public string Emri { get; set; } = null!;
        public string Lloji { get; set; } = null!;
        public int PersoniId { get; set; }
        public string Specifikimi { get; set; } = null!;
    }

    public class UpdateGjurmaBiologjikeDTO
    {
        public string? Emri { get; set; }
        public string? Lloji { get; set; }
        public int? PersoniId { get; set; }
        public string? Specifikimi { get; set; }
    }
}

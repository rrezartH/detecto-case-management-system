namespace Detecto.API.Data.DTOs
{
    public class GjurmaBiologjikeDTO
    {
        public string Emertimi { get; set; } = null!;
        public string Lloji { get; set; } = null!;
        public int PersoniId { get; set; }
    }

    public class UpdateGjurmaBiologjikeDTO
    {
        public string? Emertimi { get; set; }
        public string? Lloji { get; set; }
        public int? PersoniId { get; set; }
    }
}

namespace Detecto.API.Data.DTOs
{
    public class GjurmaBiologjikeDTO
    {
        public string Emertimi { get; set; } = null!;
        public string Lloji { get; set; } = null!;
    }

    public class UpdateGjurmaBiologjikeDTO
    {
        public string? Emertimi { get; set; }
        public string? Lloji { get; set; }
    }
}

namespace Detecto.API.Data.DTOs.PersonatDTOs
{
    public class ViktimaDTO: PersoniDTO
    {
        public string Vendi { get; set; } = null!;
        public DateTime Koha { get; set; }
        public string? Menyra { get; set; }
        public string Gjendja { get; set; } = null!;
    }

    public class UpdateViktimaDTO: UpdatePersoniDTO
    {
        public string? Vendi { get; set; }
        public DateTime? Koha { get; set; }
        public string? Menyra { get; set; }
        public string? Gjendja { get; set; }
    }
}

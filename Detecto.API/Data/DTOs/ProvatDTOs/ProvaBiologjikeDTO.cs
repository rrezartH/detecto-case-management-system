namespace Detecto.API.Data.DTOs.ProvatDTOs
{
    public class ProvaBiologjikeDTO : ProvaDTO
    {
        public string Lloji { get; set; } = null!;
        public string Specifikimi { get; set; } = null!;
        public string? TeknikaENxjerrjes { get; set; }
    }

    public class UpdateProvaBiologjikeDTO : UpdateProvaDTO
    {
        public string? Lloji { get; set; }
        public string? Specifikimi { get; set; }
        public string? TeknikaENxjerrjes { get; set; }
    }
}

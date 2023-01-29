namespace Detecto.API.Data.DTOs.ProvatDTOs
{
    public class ProvaBiologjikeDTO
    {
        public string Emri { get; set; } = null!;
        public DateTime KohaENxjerrjes { get; set; }
        public string? Vendndodhja { get; set; }
        public string Attachment { get; set; } = null!;
        public string Lloji { get; set; } = null!;
        public string Specifikimi { get; set; } = null!;
        public string? TeknikaENxjerrjes { get; set; }
    }

    public class UpdateProvaBiologjikeDTO
    {
        public string? Emri { get; set; }
        public DateTime? KohaENxjerrjes { get; set; }
        public string? Vendndodhja { get; set; }
        public string? Attachment { get; set; }
        public string? Lloji { get; set; }
        public string? Specifikimi { get; set; }
        public string? TeknikaENxjerrjes { get; set; }
    }
}

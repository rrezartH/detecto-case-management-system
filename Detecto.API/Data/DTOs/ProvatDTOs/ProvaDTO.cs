namespace Detecto.API.Data.DTOs.ProvatDTOs
{
    public class ProvaDTO
    {
        public string Emri { get; set; } = null!;
        public DateTime KohaENxjerrjes { get; set; }
        public string? Vendndodhja { get; set; }
        public string Attachment { get; set; } = null!;
        public int PersoniId { get; set; }
    }

    public class UpdateProvaDTO
    {
        public string? Emri { get; set; }
        public DateTime? KohaENxjerrjes { get; set; }
        public string? Vendndodhja { get; set; }
        public string? Attachment { get; set; }
        public int? PersoniId { get; set; }

    }
}

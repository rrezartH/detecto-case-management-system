namespace Detecto.API.Data.DTOs.ProvatDTOs
{
    public class ProvaFizikeDTO
    {
        public string Emri { get; set; } = null!;
        public DateTime KohaENxjerrjes { get; set; }
        public string? Vendndodhja { get; set; }
        public string Attachment { get; set; } = null!;
        public bool EPerdorurNeKrim { get; set; }
        public string? Rrezikshmeria { get; set; }
        public string Klasifikimi { get; set; } = null!;
        public bool DuhetEkzaminim { get; set; }
        public bool KaGjurmeBiologjike { get; set; }
    }

    public class UpdateProvaFizikeDTO
    {
        public string? Emri { get; set; }
        public DateTime? KohaENxjerrjes { get; set; }
        public string? Vendndodhja { get; set; }
        public string? Attachment { get; set; }
        public bool? EPerdorurNeKrim { get; set; }
        public string? Rrezikshmeria { get; set; }
        public string? Klasifikimi { get; set; }
        public bool? DuhetEkzaminim { get; set; }
        public bool? KaGjurmeBiologjike { get; set; }
    }
}

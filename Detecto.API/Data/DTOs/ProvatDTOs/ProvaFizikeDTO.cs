namespace Detecto.API.Data.DTOs.ProvatDTOs
{
    public class ProvaFizikeDTO : ProvaDTO
    {
        public bool EPerdorurNeKrim { get; set; }
        public string? Rrezikshmeria { get; set; }
        public string Klasifikimi { get; set; } = null!;
        public bool DuhetEkzaminim { get; set; }
        public bool KaGjurmeBiologjike { get; set; }
    }

    public class UpdateProvaFizikeDTO : UpdateProvaDTO
    {
        public bool? EPerdorurNeKrim { get; set; }
        public string? Rrezikshmeria { get; set; }
        public string? Klasifikimi { get; set; }
        public bool? DuhetEkzaminim { get; set; }
        public bool? KaGjurmeBiologjike { get; set; }
    }
}

namespace Detecto.API.Data.Models
{
    public class ProvaFizike : Prova
    {
        public bool EPerdorurNeKrim { get; set; }
        public string? Rrezikshmeria { get; set; } 
        public string Klasifikimi { get; set; } = null!;
        public bool DuhetEkzaminim { get; set; }
        public bool KaGjurmeBiologjike { get; set; }
    }
}

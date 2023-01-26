namespace Detecto.API.Data.Models
{
    public class ProvaFizike : Prova
    {
        public bool ePerdorurNeKrim { get; set; }
        public string Rrezikshmeria { get; set; }
        public string Klasifikimi { get; set; }
        public bool DuhetEkzaminim { get; set; }
        public bool KaGjurmeBiologjike { get; set; }
    }
}

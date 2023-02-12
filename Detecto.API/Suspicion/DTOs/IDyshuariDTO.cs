namespace Detecto.API.Suspicion.DTOs
{
    public class IDyshuariDTO
    {
        public int Id { get; set; }
        public int PersoniID { get; set; }
        public int CaseID { get; set; }
        public bool DyshimIAutomatizuar { get; set; }
        public string Arsyeja { get; set; }
        public int Propabiliteti { get; set; }
    }
    public class UpdateIDyshuariDTO
    {
        public bool DyshimIAutomatizuar { get; set; }
        public string Arsyeja { get; set; }
        public int Propabiliteti { get; set; }

    }
}

namespace Detecto.API.Data.Models
{
    public class GjurmaBiologjike
    {
        public int Id { get; set; }
        public string Emertimi { get; set; } = null!;
        public string Lloji { get; set; } = null!;

        //Navigation Properties
        public int PersoniId { get; set; }
        public Personi Personi { get; set; } = null!;
    }
}

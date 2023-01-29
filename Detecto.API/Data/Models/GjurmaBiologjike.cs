namespace Detecto.API.Data.Models
{
    public class GjurmaBiologjike
    {
        public int Id { get; set; }
        public string Emri { get; set; } = null!;
        public string Lloji { get; set; } = null!;
        public string Specifikimi { get; set; } = null!;

        //Navigation Properties
        public int PersoniId { get; set; }
        public Personi Personi { get; set; } = null!;
    }
}

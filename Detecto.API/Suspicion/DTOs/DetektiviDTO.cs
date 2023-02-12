namespace Detecto.API.Suspicion.DTOs
{
    public class DetektiviDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string Hulumtimi { get; set; }
    }

    public class UpdateHulumtimiDTO
    {
        public string Hulumtimi { get; set; }
    }
}

namespace Detecto.API.Data.Models
{
    public class Personi
    {
        public int Id { get; set; }
        public string Emri { get; set; } = null!;
        public char Gjinia { get; set; }
        public string Profesioni { get; set; } = null!;
        public string Statusi { get; set; } = null!;
        public string Vendbanimi { get; set; } = null!;
        public string GjendjaMendore { get; set; } = null!;
        public string eKaluara { get; set; } = null!;
    }
}

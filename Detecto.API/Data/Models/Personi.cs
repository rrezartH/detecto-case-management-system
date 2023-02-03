namespace Detecto.API.Data.Models
{
    public class Personi
    {
        public int Id { get; set; }
        public int CaseId { get; set; }
        public string Emri { get; set; } = null!;
        public char Gjinia { get; set; }
        public string Profesioni { get; set; } = null!;
        public string Statusi { get; set; } = null!;
        public string Vendbanimi { get; set; } = null!;
        public string GjendjaMendore { get; set; } = null!;
        public string EKaluara { get; set; } = null!;

        //Krijohen lidhjet mes klases Personi dhe klasave tjera te nevojshme
        public List<Deklarata>? Deklaratat { get; set; }
        public List<GjurmaBiologjike>? GjurmetBiologjike { get; set; }
        public List<Prova> Provat { get; set; } = null!;
    }
}

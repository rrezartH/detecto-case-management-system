namespace Detecto.API.Data.DTOs.PersonatDTOs
{
    public class iDyshuariDTO
    {
        public string Emri { get; set; } = null!;
        public char Gjinia { get; set; }
        public string Profesioni { get; set; } = null!;
        public string Statusi { get; set; } = null!;
        public string Vendbanimi { get; set; } = null!;
        public string GjendjaMendore { get; set; } = null!;
        public string eKaluara { get; set; } = null!;
        public string Dyshimi { get; set; } = null!;
    }

    public class UpdateiDyshuariDTO
    {
        public string? Emri { get; set; }
        public char? Gjinia { get; set; }
        public string? Profesioni { get; set; }
        public string? Statusi { get; set; }
        public string? Vendbanimi { get; set; }
        public string? GjendjaMendore { get; set; }
        public string? eKaluara { get; set; }
        public string? Dyshimi { get; set; }
    }
}

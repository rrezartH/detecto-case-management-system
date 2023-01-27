namespace Detecto.API.Data.DTOs.PersonatDTOs
{
    public class DeshmitariDTO
    {
        public string Emri { get; set; } = null!;
        public char Gjinia { get; set; }
        public string Profesioni { get; set; } = null!;
        public string Statusi { get; set; } = null!;
        public string Vendbanimi { get; set; } = null!;
        public string GjendjaMendore { get; set; } = null!;
        public string eKaluara { get; set; } = null!;
        public string RaportiMeViktimen { get; set; } = null!;
        public bool Vezhgohet { get; set; }
        public bool Dyshohet { get; set; }
    }

    public class UpdateDeshmitariDTO
    {
        public string? Emri { get; set; }
        public char? Gjinia { get; set; }
        public string? Profesioni { get; set; }
        public string? Statusi { get; set; }
        public string? Vendbanimi { get; set; }
        public string? GjendjaMendore { get; set; }
        public string? eKaluara { get; set; }
        public string? RaportiMeViktimen { get; set; }
        public bool? Vezhgohet { get; set; }
        public bool? Dyshohet { get; set; }
    }
}

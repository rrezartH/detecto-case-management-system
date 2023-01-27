namespace Detecto.API.Data.DTOs.PersonatDTOs
{
    public class DeshmitariDTO: PersoniDTO
    {
        public string RaportiMeViktimen { get; set; } = null!;
        public bool Vezhgohet { get; set; }
        public bool Dyshohet { get; set; }
    }

    public class UpdateDeshmitariDTO: UpdatePersoniDTO
    {
        public string? RaportiMeViktimen { get; set; }
        public bool? Vezhgohet { get; set; }
        public bool? Dyshohet { get; set; }
    }
}

namespace Detecto.API.Data.DTOs.PersonatDTOs
{
    public class iDyshuariDTO : PersoniDTO
    {
        public string Dyshimi { get; set; } = null!;
    }

    public class UpdateiDyshuariDTO : UpdatePersoniDTO
    {
        public string? Dyshimi { get; set; }
    }
}

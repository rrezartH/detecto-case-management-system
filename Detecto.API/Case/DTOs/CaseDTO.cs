namespace Detecto.API.Case.DTOs
{
    public class GetCaseDTO
    {
        public string Identifier { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Status { get; set; } = "E Hapur";
        public string? Details { get; set; }
        public DateTime DateOpened { get; set; }
        public DateTime? DateClosed { get; set; }
        public string? Palet { get; set; }
        public string? CaseTasks { get; set; }
        public string? Files { get; set; }
    }
}

namespace Detecto.API.Case.Models
{
    public class DCase
    {
        public int Id { get; set; }
        public string Identifier { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Status { get; set; } = "E Hapur";
        public string? Details { get; set; }
        public DateTime DateOpened { get; set; }
        public DateTime? DateClosed { get; set; }
        public string? Palet { get; set; }
        public ICollection<CaseTask>? CaseTasks { get; set; }
        public ICollection<File>? Files { get; set; }
    }
}

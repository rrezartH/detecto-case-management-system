namespace Detecto.API.Case.Models
{
    public class DTask
    {
        public int Id { get; set; }
        public int? CaseId { get; set; }

        public string Title { get; set; } = null!;
        public string Details { get; set; } = null!;
        public bool Statusi { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DueDate { get; set; }

    }
}

namespace Detecto.API.Case.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string Details { get; set; } = null!;
        public DateTime DateCreated { get; set; }
        public DateTime DueDate { get; set; }

    }
}

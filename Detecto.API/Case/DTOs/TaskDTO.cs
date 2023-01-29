namespace Detecto.API.Case.DTOs
{
    public class TaskDTO
    {
        public int Id { get; set; }
        public string Details { get; set; } = null!;
        public DateTime DateCreated { get; set; }
        public DateTime DueDate { get; set; }
    }

    public class UpdateTaskDTO
    {

        public string Details { get; set; }
        public DateTime DueDate { get; set; }
    }

}

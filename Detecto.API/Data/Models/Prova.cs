namespace Detecto.API.Data.Models
{
    public class Prova
    {
        public int Id { get; set; }
        public string Emri { get; set; } = null!;
        public DateTime KohaENxjerrjes { get; set; } 
        public string? Vendndodhja { get; set; } 
        public string Attachment { get; set; } = null!;
    }
}

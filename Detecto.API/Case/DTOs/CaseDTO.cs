using Detecto.API.Case.Models;
using Detecto.API.Data.DTOs.PersonatDTOs;
using Detecto.API.Data.Models;

namespace Detecto.API.Case.DTOs
{
    public class GetCasesDetailsDTO
    {
        public int Id { get; set; }
        public string? ImageUrl { get; set; }
        public string Identifier { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Status { get; set; } = "E Hapur";
        public string? Details { get; set; }
        public DateTime DateOpened { get; set; }
        public DateTime? DateClosed { get; set; }
    }
    public class GetCaseDTO
    {
        public string? ImageUrl { get; set; }
        public string Identifier { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Status { get; set; } = "E Hapur";
        public string? Details { get; set; }
        public DateTime DateOpened { get; set; }
        public DateTime? DateClosed { get; set; }
        public ICollection<ViktimaDTO>? Viktimat { get; set; }
        public ICollection<DeshmitariDTO>? Deshmitaret { get; set; }
        public ICollection<iDyshuariDTO>? TeDyshuarit { get; set; }
        public ICollection<CaseTask>? CaseTasks { get; set; }
        public ICollection<DFile>? Files { get; set; }
    }

    public class AddCaseDTO
    {
        public string? ImageUrl { get; set; }
        public string Identifier { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Status { get; set; } = "E Hapur";
        public string? Details { get; set; }
        public DateTime DateOpened { get; set; } = DateTime.Now;
    }

    public class UpdateCaseDTO
    {
        public string? ImageUrl { get; set; }
        public string? Identifier { get; set; } = null!;
        public string? Title { get; set; } = null!;
        public string? Status { get; set; } = "E Hapur";
        public string? Details { get; set; }
        public DateTime? DateClosed { get; set; }
    }
}

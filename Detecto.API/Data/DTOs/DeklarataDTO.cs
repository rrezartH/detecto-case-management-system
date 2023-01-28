namespace Detecto.API.Data.DTOs
{
    public class DeklarataDTO
    {
        public DateTime KohaEMarrjes { get; set; }
        public string Permbajtja { get; set; } = null!;
        public int PersoniId { get; set; }
    }

    public class UpdateDeklarataDTO
    {
        public DateTime? KohaEMarrjes { get; set; }
        public string? Permbajtja { get; set; }
        public int? PersoniId { get; set; }
    }
}

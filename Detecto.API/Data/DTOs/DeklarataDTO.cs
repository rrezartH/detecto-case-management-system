namespace Detecto.API.Data.DTOs
{
    public class DeklarataDTO
    {
        public DateTime KohaEMarrjes { get; set; }
        public string Permbajtja { get; set; } = null!;
    }

    public class UpdateDeklarataDTO
    {
        public DateTime? KohaEMarrjes { get; set; }
        public string? Permbajtja { get; set; }
    }
}

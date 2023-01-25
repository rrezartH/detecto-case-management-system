using Microsoft.EntityFrameworkCore;
using Detecto.API.Case.Models;

namespace Detecto.API.Configurations
{
    public class DetectoDbContext : DbContext
    {
        public DetectoDbContext(DbContextOptions<DetectoDbContext> options) : base(options)
        {

        }

        public DbSet<DCase> Cases { get; set; } = null!;       

    }
}

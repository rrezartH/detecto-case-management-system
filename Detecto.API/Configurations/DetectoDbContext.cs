using Microsoft.EntityFrameworkCore;
using Detecto.API.Case.Models;
using Detecto.API.Data.Models;

namespace Detecto.API.Configurations
{
    public class DetectoDbContext : DbContext
    {
        public DetectoDbContext(DbContextOptions<DetectoDbContext> options) : base(options)
        {

        }

        public DbSet<DCase> Cases { get; set; } = null!;
        public DbSet<Personi> Personat { get; set; } = null;
        public DbSet<Viktima> Viktimat { get; set; } = null;

    }
}

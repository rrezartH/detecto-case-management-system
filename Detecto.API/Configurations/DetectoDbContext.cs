using Detecto.API.Data.Models;
using Detecto.API.Case.Models;

using Microsoft.EntityFrameworkCore;

namespace Detecto.API.Configurations
{
    public class DetectoDbContext : DbContext
    {
        public DetectoDbContext(DbContextOptions<DetectoDbContext> options) : base(options)
        {

        }


        public DbSet<DCase> Cases { get; set; } = null!;
        public DbSet<DTask> Tasks { get; set; } = null!;
        public DbSet<Detective> Detectives { get; set; } = null!;
        public DbSet<Personi> Personat { get; set; } = null!;
        public DbSet<Viktima> Viktimat { get; set; } = null!;
        public DbSet<Deshmitari> Deshmitaret { get; set; } = null!;
        public DbSet<iDyshuari> TeDyshuarit { get; set; } = null!;
        public DbSet<Prova> Provat { get; set; } = null!;
        public DbSet<ProvaFizike> ProvatFizike { get; set; } = null!;
        public DbSet<ProvaBiologjike> ProvatBiologjike { get; set; } = null!;
        public DbSet<GjurmaBiologjike> GjurmetBiologjike { get; set; } = null!;
        public DbSet<Deklarata> Deklaratat { get; set; } = null!;
        public DbSet<DFile> Files { get; set; } = null!;
    }
}

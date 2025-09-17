using GoogleMapsCoreMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace GoogleMapsCoreMVC.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Logins> Logins { get; set; }
        public DbSet<Agente> Agentes { get; set; }
        public DbSet<Registros> Registros { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Mapear nombres exactos de tablas si difieren (opcional)
            modelBuilder.Entity<Logins>().ToTable("logins");
            modelBuilder.Entity<Agente>().ToTable("Agentes");
            modelBuilder.Entity<Registros>().ToTable("Registros");

            // Opcional: precisión decimal ya establecida por el atributo [Column] en Registro
        }
    }
}

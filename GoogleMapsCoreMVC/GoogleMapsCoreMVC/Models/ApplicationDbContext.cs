using Microsoft.EntityFrameworkCore;

namespace GoogleMapsCoreMVC.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        // Tablas
        public DbSet<Login> Login { get; set; }
        public DbSet<Registro> Registro { get; set; }
        public DbSet<Agente> Agentes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Login>().ToTable("Logins");   // <-- nombre correcto en la BD
            modelBuilder.Entity<Registro>().ToTable("Registros");
            modelBuilder.Entity<Agente>().ToTable("Agentes");

            // Relaciones
            modelBuilder.Entity<Registro>()
                .HasOne(r => r.Login)
                .WithMany(l => l.Registros)
                .HasForeignKey(r => r.UserId);

            modelBuilder.Entity<Agente>()
                .HasOne(a => a.Login)
                .WithMany(l => l.Agente)
                .HasForeignKey(a => a.UserId);
        }
    }
}

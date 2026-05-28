using Microsoft.EntityFrameworkCore;
using Veterinaria_MaxPets.Models;

namespace Veterinaria_MaxPets.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Mascota> Mascotas { get; set; }
        public DbSet<Cita> Citas { get; set; }
        public DbSet<DetalleServicio> DetalleServicios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cita>()
                .HasOne(c => c.Mascota)
                .WithMany(m => m.Citas)
                .HasForeignKey(c => c.MascotaId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<DetalleServicio>()
                .HasOne(d => d.Cita)
                .WithMany(c => c.Detalles)
                .HasForeignKey(d => d.CitaId);

            modelBuilder.Entity<Cita>()
                .Property(c => c.Total)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<DetalleServicio>()
                .Property(d => d.Precio)
                .HasColumnType("decimal(18,2)");
        }
    }
}
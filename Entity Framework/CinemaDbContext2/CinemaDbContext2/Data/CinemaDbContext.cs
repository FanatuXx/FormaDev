using CinemaDbContext2.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CinemaDbContext2.Data
{
    public class CinemaDbContext : DbContext
    {
        public CinemaDbContext(DbContextOptions<CinemaDbContext> options) : base(options) { }

        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Film> Films { get; set; }
        public DbSet<Salle> Salles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Cinema>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Nom)
                .IsRequired()
                .HasMaxLength(100);

                entity.Property(e => e.Adresse);

                entity.Property(e => e.Ville)
                .HasMaxLength(50);

                //entity.HasIndex(e => e.Ville)
                //.IsUnique();

                //entity.HasOne(e => e.Salles)
                //.WithMany(f => f.Cinema)
                //.HasForeignKey(e => e.SubscriptionId)
                //.OnDelete(DeleteBehavior.Restrict);
            });


            modelBuilder.Entity<Salle>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Numero)
                .IsRequired();

                entity.Property(e => e.NombrePlaces)
                .HasDefaultValue(50);

                entity.HasOne(e => e.Cinema)
                .WithMany(f => f.Salles)
                .HasForeignKey(e => e.CinemaId)
                .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Film>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Titre)
                .IsRequired()
                .HasMaxLength(150);

                entity.Property(e => e.PrixTicket)
                .HasColumnType("decimal(18,2)");
            });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=GOS-VDI205\\TFTIC;Database=CinemaDb;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}

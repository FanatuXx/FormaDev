using AuLitBabaCodeFirst.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuLitBabaCodeFirst.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Client> Clients { get; set; }                   //Entités qui vont être récupérée sous forme de table
        public DbSet<Subscription> Subscriptions { get; set; }  
        public DbSet<Bed> Beds { get; set; }
        public DbSet<Pastry> Pastries { get; set; }
        public DbSet<PastryCommand> PastryCommands { get; set; }
        public DbSet<Reservation> Reservations { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(50);

                entity.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(50);

                entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(150);

                entity.ToTable(                     //Permet de créer une contrainte check pour notre mail
                    "CK_Email_regex",
                    "[Email] LIKE '%_@_%._%'"
                    );

                entity.HasIndex(e => e.Email)
                .IsUnique();

                entity.HasOne(e => e.Subscription)
                .WithMany(f => f.Clients)
                .HasForeignKey (e => e.SubscriptionId)
                .OnDelete(DeleteBehavior.Restrict);
            });


        }
    }
}

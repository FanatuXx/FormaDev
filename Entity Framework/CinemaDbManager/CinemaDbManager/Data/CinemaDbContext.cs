using CinemaDbManager.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaDbManager.Data
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
                .HasMaxLength(50);

                entity.Property(e => e.Adresse)
                .IsRequired()
                .HasMaxLength(150);

                entity.Property(e => e.Nom)
                .IsRequired()
                .HasMaxLength(50);

                entity.HasOne(e => e.Sall)
            }); 
        }


    }
}

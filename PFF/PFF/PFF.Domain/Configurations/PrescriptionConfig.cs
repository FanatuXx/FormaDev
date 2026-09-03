using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PFF.Domain.Model.Entities;

namespace PFF.Domain.Configurations
{
    internal class PrescriptionConfig : IEntityTypeConfiguration<Prescription>
    {
        public void Configure(EntityTypeBuilder<Prescription> builder)
        {
            builder.HasKey(pre => pre.Id);

            builder.ToTable("Prescription", t =>
            {
                t.HasCheckConstraint("CK_Prescription_Dates", "StartDate < EndDate");
            });

            builder.Property(pre => pre.StartDate)
                .IsRequired()
                .HasColumnType("DATETIME")
                .HasColumnName("DateDebut");

            builder.Property(pre => pre.EndDate)
                .IsRequired()
                .HasColumnType("DATETIME")
                .HasColumnName("DateFin");

            builder.Property(pre => pre.TakeFrequency)
                .IsRequired()
                .HasColumnType("NVARCHAR(128)")
                .HasColumnName("FrenquencePrise");

            builder.HasOne(pre => pre.Worker)
                .WithMany(pra => pra.Prescriptions)
                .HasForeignKey(pre => pre.WorkerSSIN);

            builder.HasOne(pre => pre.Consultation)
                .WithMany(c => c.Prescriptions)
                .HasForeignKey(pre => pre.ConsultationId);

            builder.HasOne(pre => pre.Patient)
                .WithMany(p => p.Prescriptions)
                .HasForeignKey(pre => pre.PatientId);

            builder.HasMany(pre => pre.Medicines)
                .WithMany(m => m.Prescriptions)
                .UsingEntity("Prescriptions_Medicaments_JoinTable");
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PFF.Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PFF.Domain.Configurations
{
    internal class VitalSignConfig : IEntityTypeConfiguration<VitalSign>
    {
        public void Configure(EntityTypeBuilder<VitalSign> builder)
        {
            builder.HasKey(vsm => vsm.Id);


            builder.ToTable("ParamètresVitaux", t =>
            {
                t.HasCheckConstraint("CK_Paramètres_FréquenceCardiaque", "HeartRate <= 220");
                t.HasCheckConstraint("CK_Paramètres_Température", "Temperature >= 30 AND Temperature <= 45");
                t.HasCheckConstraint("CK_Paramètres_FréquenceRespiratoire", "RespiratoryRate >= 1 AND RespiratoryRate <= 60");
                t.HasCheckConstraint("CK_Paramètres_Saturation", "OxygenSaturation >= 1 AND OxygenSaturation <= 100");
            });


            builder.Property(vs => vs.HeartRate)
                .HasColumnType("INT")
                .HasColumnName("FréquenceCardiaque");

            builder.Property(vs => vs.BloodPressure)
                .HasColumnType("NVARCHAR(50)")
                .HasColumnName("PressionArtérielle");

            builder.Property(vs => vs.Temperature)
                .HasColumnType("DECIMAL(3, 1)")
                .HasColumnName("Température");

            builder.Property(vs => vs.RespiratoryRate)
                .HasColumnType("INT")
                .HasColumnName("FréquenceRespiratoire");

            builder.Property(vs => vs.OxygenSaturation)
                .HasColumnType("INT")
                .HasColumnName("Saturation");


            builder.HasOne(vs => vs.Consultation)
                .WithMany(c => c.VitalSigns)
                .HasForeignKey(vs => vs.ConsultationId);
        }
    }
}

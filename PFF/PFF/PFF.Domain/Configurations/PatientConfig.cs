using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PFF.Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PFF.Domain.Configurations
{
    internal class PatientConfig : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.HasKey(patient => patient.Id);


            builder.ToTable("Patient", t =>
            {
                t.HasCheckConstraint("CK_Patient_Identification", "LEN(FirstName) > 0 OR LEN(LastName) > 0 OR LEN(Alias) > 0");
                t.HasCheckConstraint("CK_Patient_DernièreVisite", "LastVisit >= RegistrationDate");
            });


            builder.Property(patient => patient.SSIN)
                .HasColumnType("INT")
                .HasColumnName("NISS");

            builder.Property(patient => patient.FirstName)
                .HasColumnType("NVARCHAR(50)")
                .HasColumnName("Prénom");

            builder.Property(patient => patient.LastName)
                .HasColumnType("NVARCHAR(50)")
                .HasColumnName("Nom");

            builder.Property(patient => patient.Alias)
                .HasColumnType("NVARCHAR(50)")
                .HasColumnName("Surnom");

            builder.Property(patient => patient.Gender) 
                .HasColumnType("NVARCHAR(50)")
                .HasColumnName("Genre");

            builder.Property(patient => patient.BirthDate)
                .IsRequired()
                .HasColumnType("DATETIME")
                .HasColumnName("DateNaissance");

            builder.Property(patient => patient.PhoneNumber)
                .HasColumnType("NVARCHAR(50)")
                .HasColumnName("NuméroTéléphone");

            builder.Property(patient => patient.RegistrationDate)
                .IsRequired()
                .HasColumnType("DATETIME")
                .HasColumnName("DateInscription");

            builder.Property(patient => patient.LastVisit)
                .HasColumnType("DATETIME")
                .HasColumnName("DateDernièreVisite");


            builder.HasIndex(patient => patient.SSIN)
                .IsUnique();


            builder.HasOne(patient => patient.PatientAddress)
                .WithMany(pAddress => pAddress.Patients)
                .HasForeignKey(patient => patient.PatientAddressId);

            builder.HasMany(patient => patient.Prescriptions)
                .WithOne(pre => pre.Patient);

            builder.HasMany(patient => patient.Consultations)
                .WithOne(c => c.Patient);






        }
    }
}

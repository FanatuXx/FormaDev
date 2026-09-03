using Microsoft.EntityFrameworkCore;
using PFF.Domain.Model.Entities;

namespace PFF.Domain.Model
{
    class ApplicationDbContext : DbContext
    {
        public virtual DbSet<Worker> Praticioners { get { return Set<Worker>(); } }
        public virtual DbSet<Patient> Patients { get { return Set<Patient>(); } }
        public virtual DbSet<PatientAddress> PatientAddresses { get { return Set<PatientAddress>(); } }
        public virtual DbSet<Consultation> Consultations { get { return Set<Consultation>(); } }
        public virtual DbSet<Medicine> Medicines { get { return Set<Medicine>(); } }
        public virtual DbSet<Pathology> Pathologies { get { return Set<Pathology>(); } }
        public virtual DbSet<Prescription> Prescriptions { get { return Set<Prescription>(); } }
        public virtual DbSet<VitalSignsMonitoring> VitalSignsMonitorings { get { return Set<VitalSignsMonitoring>(); } }

        public ApplicationDbContext(DbContextOptions options) : base (options) 
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}

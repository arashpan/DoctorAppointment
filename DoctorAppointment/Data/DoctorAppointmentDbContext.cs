using DoctorAppointment.Model;
using Microsoft.EntityFrameworkCore;

namespace DoctorAppointment.Data
{
    public class DoctorAppointmentDbContext : DbContext
    {
        public DoctorAppointmentDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Clinic> Clinics { get; set; }
        //public DbSet<Reservation> Reservations { get; set; }
        //public DbSet<DeletedRecord> DeletedRecords { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clinic>()
                .HasMany(e => e.Doctors)
                .WithOne(e => e.Clinic)
                .HasForeignKey(e => e.ClinicId)
                .IsRequired();

            modelBuilder.Entity<Clinic>()
                .HasMany(e => e.Patients)
                .WithOne(e => e.Clinic)
                .HasForeignKey(e => e.ClinicId)
                .IsRequired();

        }
    }
}

using Cw6.Models;
using Cw6.Models.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cw6.DataAccess
{
    public class PjatkDbContext : DbContext
    {
        public PjatkDbContext()
        {
        }

        public PjatkDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Prescription_Medicament> Prescription_Medicaments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Prescription_Medicament>(p =>
            {
                p.HasKey(e => new { e.IdMedicament, e.IdPrescription });
                p.HasData(
                    new Prescription_Medicament { IdMedicament = 1, IdPrescription = 1, Dose = 1, Details = "test" }
                    );
            });

            modelBuilder.Entity<Prescription>(p =>
            {
               
                p.HasData(
                    new Prescription { IdPrescription= 1, Date = System.DateTime.Parse("2000-01-01"), DueDate = System.DateTime.Parse("2001-01-01"), IdPatient = 1, IdDoctor=1 }
                    );
            });

            modelBuilder.Entity<Medicament>(p =>
            {

                p.HasData(
                    new Medicament {IdMedicament = 1, Name="Ibuprom", Description="zalecany na ból głowy", Type= "NLPZ" }
                    );
            });

            modelBuilder.Entity<Patient>(p =>
            {

                p.HasData(
                    new Patient {IdPatient=1, FirstName="Jan", LastName="Tomczak", BirthDate = System.DateTime.Parse("1999-01-01") }
                    );
            });

            modelBuilder.Entity<Doctor>(p =>
            {

                p.HasData(
                    new Doctor {IdDoctor=1, FirstName="Tomasz", LatName="Janusiak", Email="tomasz@janusiak.com" }
                    );
            });

        }

       
    }
}


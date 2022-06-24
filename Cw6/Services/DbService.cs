using Cw6.Models;
using Cw6.Models.DTO;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cw6.DataAccess
{
    public class DbService : IDbService
    {
        private readonly PjatkDbContext _context;

        public DbService(PjatkDbContext context)
        {
            _context = context;
        }

        public async Task<IList<SomeKindOfDoctor>> GetDoctors()
        {
            return await _context.Doctors
            .Select(e => new SomeKindOfDoctor
            {
                IdDoctor = e.IdDoctor,
                FirstName = e.FirstName,
                LastName = e.LatName,
                Email = e.Email
            }).ToListAsync();
        }

        public async Task<bool> AddDoctor(SomeKindOfDoctor someKindOfDoctor)
        {
            var existingDoctor = await _context.Doctors.SingleOrDefaultAsync(e => e.IdDoctor == someKindOfDoctor.IdDoctor);
            if (existingDoctor != null)
            {
                return false;
            }

            var newDoctor = new Doctor
            {
                FirstName = someKindOfDoctor.FirstName,
                LatName = someKindOfDoctor.LastName,
                Email = someKindOfDoctor.Email
            };
            await _context.Doctors.AddAsync(newDoctor);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateDoctor(int idDoctor, SomeKindOfDoctor someKindOfDoctor)
        {
            var existingDoctor = await _context.Doctors.SingleOrDefaultAsync(e => e.IdDoctor == idDoctor);
            if (existingDoctor == null)
            {
                return false;
            }
            existingDoctor.FirstName = someKindOfDoctor.FirstName;
            existingDoctor.LatName = someKindOfDoctor.LastName;
            existingDoctor.Email = someKindOfDoctor.Email;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RemoveDoctor(int idDoctor)
        {
            var existingDoctor = await _context.Doctors.SingleOrDefaultAsync(e => e.IdDoctor == idDoctor);
            if (existingDoctor == null)
            {
                return false;
            }
            _context.Doctors.Remove(existingDoctor);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<SomePrescription> GetPrescription(int id)
        {
            return await _context.Prescriptions
                .Include(e => e.Doctor)
                .Include(e => e.Patient)
                .Include(e => e.Prescription_Medicaments)
                .Select(e => new SomePrescription
                {
                    IdPrescription = e.IdPrescription,
                    Date = e.Date,
                    DueDate = e.DueDate,
                    SomeDoctor = new SomeKindOfDoctor
                    {
                        IdDoctor = e.IdDoctor,
                        FirstName = e.Doctor.FirstName,
                        LastName = e.Doctor.LatName,
                        Email = e.Doctor.Email
                    },
                    SomePatient = new SomePatient
                    {
                        IdPatient = e.IdPatient,
                        FirstName = e.Patient.FirstName,
                        LastName = e.Patient.LastName,
                        BirthDate = e.Patient.BirthDate
                    },
                    PrescriptionMedicaments = e.Prescription_Medicaments
                    .Select(e => new SomePrescriptionMedicament
                    {
                        Name = e.Medicament.Name,
                        IdMedicament = e.IdMedicament,
                        Dose = e.Dose,
                        Details = e.Details
                    }).ToList()
                })
                .SingleOrDefaultAsync(e => e.IdPrescription == id);
        }
    }
}

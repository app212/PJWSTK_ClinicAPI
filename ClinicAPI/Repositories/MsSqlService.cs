using ClinicAPI.DTOs;
using ClinicAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicAPI.Repositories
{
    public class MsSqlService : IDbService
    {
        private readonly ClinicContext _context;
        public MsSqlService(ClinicContext context)
        {
            _context = context;
        }

        public async Task<bool> DeleteDoctorAsync(int idDoctor)
        {
            var doctor = await _context.Doctors.SingleOrDefaultAsync(x => x.IdDoctor == idDoctor);
            if (doctor == null) return false;
            var prescriptions = await _context.Prescriptions.Where(x => x.IdDoctor == doctor.IdDoctor).ToListAsync();
            if (prescriptions != null)
            {
                foreach (var p in prescriptions)
                {
                    var meds = await _context.PrescriptionMedicaments.Where(x => x.IdPrescription == p.IdPresciption).ToListAsync();
                    _context.PrescriptionMedicaments.RemoveRange(meds);
                    _context.Prescriptions.Remove(p);
                }
            }

            _context.Doctors.Remove(doctor);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<ICollection<DoctorDTO>> GetDoctorsAsync()
        {
            return await _context.Doctors.Select(x => new DoctorDTO
            {
                FirstName = x.FirstName,
                LastName = x.LastName,
                Email = x.Email
            }).ToListAsync();
        }

        public async Task<bool> InsertDoctorAsync(DoctorDTO doctor)
        {
            await _context.Doctors.AddAsync(new Doctor
            {
                FirstName = doctor.FirstName,
                LastName = doctor.LastName,
                Email = doctor.Email
            });

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateDoctorAsync(int idDoctor, DoctorDTO doctor)
        {
            var doc = await _context.Doctors.SingleOrDefaultAsync(x => x.IdDoctor == idDoctor);
            if (doc == null) return false;

            doc.FirstName = doctor.FirstName;
            doc.LastName = doctor.LastName;
            doc.Email = doctor.Email;

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<PrescriptionDTO> GetPrescriptionByIdAsync(int idPrescription)
        {
            var prescription = await _context.Prescriptions
                .Where(x => x.IdPresciption == idPrescription)
                .Include(x => x.PrescriptionMedicaments)
                .Select(x => new PrescriptionDTO
                {
                    Date = x.Date,
                    DueDate = x.DueDate,
                    Patient = new PatientDTO
                    {
                        FirstName = x.IdPatientNavigation.FirstName,
                        LastName = x.IdPatientNavigation.LastName,
                        Birthdate = x.IdPatientNavigation.Birthdate
                    },
                    Doctor = new DoctorDTO
                    {
                        FirstName = x.IdDoctorNavigation.FirstName,
                        LastName = x.IdDoctorNavigation.LastName,
                        Email = x.IdDoctorNavigation.Email
                    },
                    Medicaments = x.PrescriptionMedicaments.Select(y => new MedicamentDTO
                    {
                        Name = y.IdMedicamentNavigation.Name,
                        Description = y.IdMedicamentNavigation.Description,
                        Type = y.IdMedicamentNavigation.Type,
                        Dose = y.Dose,
                        Details = y.Details
                    }).ToList()
                }).SingleOrDefaultAsync();
            return prescription;
        }
    }
}

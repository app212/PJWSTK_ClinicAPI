using ClinicAPI.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClinicAPI.Repositories
{
    public interface IDbService
    {
        public Task<ICollection<DoctorDTO>> GetDoctorsAsync();
        public Task<bool> InsertDoctorAsync(DoctorDTO doctor);
        public Task<bool> UpdateDoctorAsync(int idDoctor, DoctorDTO doctor);
        public Task<bool> DeleteDoctorAsync(int idDoctor);
        public Task<PrescriptionDTO> GetPrescriptionByIdAsync(int idPrescription);
    }
}

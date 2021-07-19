using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicAPI.DTOs
{
    public class PrescriptionDTO
    {
        public DateTime Date { get; set; }
        public DateTime DueDate { get; set; }
        public PatientDTO Patient { get; set; }
        public DoctorDTO Doctor { get; set; }
        public ICollection<MedicamentDTO> Medicaments { get; set; }
    }
}

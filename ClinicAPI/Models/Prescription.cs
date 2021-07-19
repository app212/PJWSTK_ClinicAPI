using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicAPI.Models
{
    public class Prescription
    {
        public int IdPresciption { get; set; }
        public DateTime Date { get; set; }
        public DateTime DueDate { get; set; }
        public int IdPatient { get; set; }
        public int IdDoctor { get; set; }

        public virtual Patient IdPatientNavigation { get; set; }
        public virtual Doctor IdDoctorNavigation { get; set; }
        public virtual ICollection<PrescriptionMedicament> PrescriptionMedicaments { get; set; }

        public Prescription()
        {
            PrescriptionMedicaments = new HashSet<PrescriptionMedicament>();
        }
    }
}

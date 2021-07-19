using System;
using System.ComponentModel.DataAnnotations;

namespace ClinicAPI.DTOs
{
    public class PatientDTO
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateTime Birthdate { get; set; }
    }
}

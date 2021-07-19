using System.ComponentModel.DataAnnotations;

namespace ClinicAPI.DTOs
{
    public class DoctorDTO
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required][EmailAddress]
        public string Email { get; set; }
    }
}
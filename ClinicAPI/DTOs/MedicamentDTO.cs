using System.ComponentModel.DataAnnotations;

namespace ClinicAPI.DTOs
{
    public class MedicamentDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Type { get; set; }
        public int? Dose { get; set; }
        [Required]
        public string Details { get; set; }
    }
}

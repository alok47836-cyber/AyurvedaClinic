using System.ComponentModel.DataAnnotations;

namespace AyurvedaClinic.Models
{
    public class Testimonial
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string PatientName { get; set; }

        [Required]
        public string Review { get; set; }

        [Range(1, 5)]
        public int Rating { get; set; } = 5;

        [StringLength(255)]
        public string? ImageUrl { get; set; }

        public bool IsActive { get; set; } = true;
    }
}

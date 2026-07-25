using System.ComponentModel.DataAnnotations;

namespace AyurvedaClinic.Models
{
    public class Appointment
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(20)]
        [Phone]
        public string Phone { get; set; }

        [EmailAddress]
        [StringLength(100)]
        public string? Email { get; set; }

        [Required]
        public string Treatment { get; set; }

        [Required]
        public DateTime AppointmentDate { get; set; }

        public string? Message { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}

using System.ComponentModel.DataAnnotations;

namespace AyurvedaClinic.Models
{
    public class Doctor
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        public string Specialization { get; set; }

        [StringLength(255)]
        public string? ImageUrl { get; set; }

        public string? Bio { get; set; }

        [StringLength(100)]
        public string? FacebookUrl { get; set; }

        [StringLength(100)]
        public string? TwitterUrl { get; set; }

        [StringLength(100)]
        public string? LinkedInUrl { get; set; }

        public bool IsActive { get; set; } = true;
    }
}

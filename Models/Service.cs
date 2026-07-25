using System.ComponentModel.DataAnnotations;

namespace AyurvedaClinic.Models
{
    public class Service
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [StringLength(255)]
        public string? ImageUrl { get; set; }

        [StringLength(50)]
        public string? IconClass { get; set; }

        public bool IsActive { get; set; } = true;
    }
}

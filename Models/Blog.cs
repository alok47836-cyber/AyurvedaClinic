using System.ComponentModel.DataAnnotations;

namespace AyurvedaClinic.Models
{
    public class Blog
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [StringLength(255)]
        public string? ImageUrl { get; set; }

        [StringLength(100)]
        public string Author { get; set; } = "Admin";

        public DateTime PublishedDate { get; set; } = DateTime.Now;

        public bool IsActive { get; set; } = true;
    }
}

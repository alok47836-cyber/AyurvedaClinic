using AyurvedaClinic.Models;
using Microsoft.EntityFrameworkCore;

namespace AyurvedaClinic.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<ContactInquiry> ContactInquiries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed HIIMS Panchakarma specific data
            modelBuilder.Entity<Service>().HasData(
                new Service { Id = 1, Title = "Vamana", Description = "A therapeutic process from Panchakarma that helps remove toxins from the internal upper body. It removes excess mucus and toxins accumulated in the stomach and chest.", IconClass = "fa-solid fa-lungs", IsActive = true },
                new Service { Id = 2, Title = "Virechana", Description = "A detoxification therapy focused on purifying the liver and intestines through controlled motions. Experience better digestion, enhanced energy, and clarity.", IconClass = "fa-solid fa-leaf", IsActive = true },
                new Service { Id = 3, Title = "Basti", Description = "An Ayurvedic therapy that uses herbal oil or decoction enemas to cleanse and nourish the colon. Supports gut health, immunity, and mental clarity.", IconClass = "fa-solid fa-spa", IsActive = true },
                new Service { Id = 4, Title = "Nasya", Description = "A traditional Ayurvedic therapy involving the pouring of herbal oils through the nose. Supports mental clarity and respiratory health.", IconClass = "fa-solid fa-head-side-mask", IsActive = true },
                new Service { Id = 5, Title = "Raktmokshana", Description = "A traditional Ayurvedic blood purification therapy that removes impure blood from the body. Cleans impurities that lead to skin disorders and inflammation.", IconClass = "fa-solid fa-droplet", IsActive = true }
            );

            modelBuilder.Entity<Doctor>().HasData(
                new Doctor { Id = 1, Name = "Acharya Manish Ji", Specialization = "Ayurveda Expert", Bio = "Founder of HIIMS, dedicated to addressing root causes of illness through Ayurvedic and Natural therapies.", IsActive = true }
            );
        }
    }
}

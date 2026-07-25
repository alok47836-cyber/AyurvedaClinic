using AyurvedaClinic.Models;
using AyurvedaClinic.Repository.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AyurvedaClinic.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly IRepository<Appointment> _appointmentRepo;

        public AdminController(IRepository<Appointment> appointmentRepo)
        {
            _appointmentRepo = appointmentRepo;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            // Hardcoded credentials as requested
            if (username == "admin" && password == "admin123")
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, username),
                    new Claim(ClaimTypes.Role, "Admin")
                };

                var identity = new ClaimsIdentity(claims, "Cookies");
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync("Cookies", principal);
                return RedirectToAction("Index");
            }

            ViewBag.Error = "Invalid username or password";
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync("Cookies");
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Index()
        {
            var appointments = await _appointmentRepo.GetAllAsync();
            ViewBag.TotalAppointments = appointments.Count();
            return View();
        }

        public async Task<IActionResult> Appointments()
        {
            var appointments = await _appointmentRepo.GetAllAsync(null, null);
            return View(appointments.OrderByDescending(a => a.CreatedAt));
        }

        [HttpPost]
        public async Task<IActionResult> DeleteAppointment(int id)
        {
            var appt = await _appointmentRepo.GetFirstOrDefaultAsync(a => a.Id == id);
            if (appt != null)
            {
                _appointmentRepo.Remove(appt);
                await _appointmentRepo.SaveAsync();
            }
            return RedirectToAction("Appointments");
        }
    }
}

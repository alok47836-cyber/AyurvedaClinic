using AyurvedaClinic.Models;
using AyurvedaClinic.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AyurvedaClinic.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository<Service> _serviceRepo;
        private readonly IRepository<Doctor> _doctorRepo;
        private readonly IRepository<Appointment> _appointmentRepo;

        public HomeController(IRepository<Service> serviceRepo, IRepository<Doctor> doctorRepo, IRepository<Appointment> appointmentRepo)
        {
            _serviceRepo = serviceRepo;
            _doctorRepo = doctorRepo;
            _appointmentRepo = appointmentRepo;
        }

        public async Task<IActionResult> Index()
        {
            var services = await _serviceRepo.GetAllAsync(s => s.IsActive);
            return View(services.Take(3));
        }

        public async Task<IActionResult> Treatments()
        {
            var services = await _serviceRepo.GetAllAsync(s => s.IsActive);
            return View(services);
        }

        public async Task<IActionResult> Doctors()
        {
            var doctors = await _doctorRepo.GetAllAsync(d => d.IsActive);
            return View(doctors);
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> BookAppointment()
        {
            var services = await _serviceRepo.GetAllAsync(s => s.IsActive);
            ViewBag.Services = services;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BookAppointment(Appointment obj)
        {
            if (ModelState.IsValid)
            {
                await _appointmentRepo.AddAsync(obj);
                await _appointmentRepo.SaveAsync();
                TempData["Success"] = "Your appointment has been booked successfully! We will confirm within 1-2 hours.";
                return RedirectToAction("Index");
            }

            var services = await _serviceRepo.GetAllAsync(s => s.IsActive);
            ViewBag.Services = services;
            return View(obj);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UniversityOfLiberia.Models.SchoolViewModels;
using System;
using System.Linq;
using System.Threading.Tasks;
using UniversityOfLiberia.Models;
using UniversityOfLiberia.Data;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace UniversityOfLiberia.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UniversityOfLiberiaContext _context;

        public HomeController(ILogger<HomeController> logger, UniversityOfLiberiaContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<ActionResult> About()
        {
            IQueryable<EnrollmentDateGroup> data =
                from student in _context.Students
                group student by student.EnrollmentDate into dateGroup
                select new EnrollmentDateGroup()
                {
                    EnrollmentDate = dateGroup.Key,
                    StudentCount = dateGroup.Count()
                };
            return View(await data.AsNoTracking().ToListAsync());
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

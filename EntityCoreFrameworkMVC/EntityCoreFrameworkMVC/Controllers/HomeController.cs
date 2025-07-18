using System.Diagnostics;
using EntityCoreFrameworkMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace EntityCoreFrameworkMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly StudentDBContext studentdbcon;

        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public HomeController(StudentDBContext studentdbcon)
        {
            this.studentdbcon = studentdbcon;
        }

        public IActionResult Index()
        {
            var std = studentdbcon.Students.ToList();
            return View(std);
        }

        public IActionResult Create()
        {
           
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Student Stu)
        {
            await studentdbcon.Students.AddAsync(Stu); 
            await studentdbcon.SaveChangesAsync();

            return RedirectToAction("Index","Home");
            
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

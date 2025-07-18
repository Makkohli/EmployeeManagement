using Microsoft.AspNetCore.Mvc;
using ViewImportConcept.Model;

namespace ViewImportConcept.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            List<StudentClass> student = new List<StudentClass> {
    new StudentClass {Id=1,Name="Manish",Gender="Male"},
         new StudentClass {Id=2,Name="kuamr",Gender="Male" }
          };

            return View(student);
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
    }
}

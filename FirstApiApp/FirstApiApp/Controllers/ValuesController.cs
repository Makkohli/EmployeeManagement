using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public List<string> Fruits = new List<string>()
        {
            "apple",
            "mango",
            "banana"
        };

        [HttpGet]
        public List<string> getAllFruits()
        {
            return Fruits;
        }

        [HttpGet("{id}")]
        public string getAllFruits(int id)
        {
            return Fruits.ElementAt(id);
        }
    }
}

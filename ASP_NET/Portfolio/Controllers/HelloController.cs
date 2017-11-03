using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Controllers
{
    public class HelloController : Controller
    {
        // =========== FOR VIEWS ========

        // ----------------- HOME PAGE ---------------
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            
            return View("Index");

        }

        // ----------------- PROJECT PAGE ---------------
        [HttpGet]
        [Route("projects")]
        public IActionResult Project()
        {

            return View("Project");
        }

        // ----------------- CONTACT PAGE ---------------
        [HttpGet]
        [Route("contact")]
        public IActionResult Contact()
        {
            ViewBag.Example = "Hello World!";
            return View("Contact");
        }


        // ------------ A POST method ---------------------
        [HttpPost]
        [Route("method")]
        public IActionResult Method(string TextField, int NumberField)
        {
            
            return View("Contact");
        }
        // 

    }
}

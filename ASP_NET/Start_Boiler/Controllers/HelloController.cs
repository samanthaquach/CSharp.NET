using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Start.Controllers
{
    public class HelloController : Controller
    {
        // A GET method
        // [HttpGet]
        // [Route("index")]
        // public string Index()
        // {
        //     return "Hello World!";
        // }
        // =========== FOR VIEWS ========
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            // return View();
            //OR
            return View("Index");
            //Both of these returns will render the same view (You only need one!)
        }

        // [HttpGet]
        // [Route("displayint")]
        // public JsonResult DisplayInt()
        // {
        //     return Json(34);
        // }

        // [HttpGet]
        // [Route("displayhuman")]
        // public JsonResult DisplayHuman()
        // {
        //     return Json(new Human());
        // }

        // [HttpGet]
        // [Route("displayint")]
        // public JsonResult DisplayInt()
        // {
        //     var AnonObject = new
        //     {
        //         FirstName = "Raz",
        //         LastName = "Aquato",
        //         Age = 10
        //     };
        //     return Json(AnonObject);
        // }

        // Other code
        // [HttpGet]
        // [Route("template/{Name}")]
        // public IActionResult Method(string Name)
        // {
        //     // Method body
        // }


        // A POST method
        // [HttpPost]
        // [Route("")]
        // public IActionResult Other()
        // {
        //     // Return a view (We'll learn how soon!)
        // }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


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
                // // To store a string in session we use ".SetString"
                // // The first string passed is the key and the second is the value we want to retrieve later
                // HttpContext.Session.SetString("UserName", "Samantha");
                // // To retrieve a string from session we use ".GetString"
                // string LocalVariable = HttpContext.Session.GetString("UserName");

                // // To store an int in session we use ".SetInt32"
                // HttpContext.Session.SetInt32("UserAge", 28);

                // // To retrieve an int from session we use ".GetInt32"
                // int? IntVariable = HttpContext.Session.GetInt32("UserAge");

                
            
                return View("Index");
            //Both of these returns will render the same view (You only need one!)
        }

        // public IActionResult Method()
        // {
        //     TempData["Variable"] = "Hello World";
        //     return RedirectToAction("OtherMethod");
        // }
        // public IActionResult OtherMethod()
        // {
        //     Console.WriteLine(TempData["Variable"]);
        //     // writes "Hello World" if redirected to from Method()
        // }




    // }

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


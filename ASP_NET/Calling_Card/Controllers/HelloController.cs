using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Calling_Card.Controllers
{
    public class HelloController : Controller
    {

//  ===================== MAIN PAGE ====================
        // A GET method
        [HttpGet]
        [Route("")]
        public string Front()
        {
            return "Hello Sam! That's my name! Figure out my info";
        }
//  ===================== ASSIGNMENT ====================
        [HttpGet]
        [Route("sam/sam")]
        public JsonResult Sam()
        {
            var AnonObject = new
            {
                FirstName = "Sam",
                LastName = "Quach",
                Age = "24",
                FavoriteColor = "Pink",
            };
            return Json(AnonObject);
        }

// OTHER WAY OF DOING IT... 

        [HttpGet]
        [Route("/{FirstName}/{LastName}/{Age}/{FavColor}")]
        public JsonResult DisplayInt(string FirstName, string LastName, int Age, string FavColor)
        {
            return Json(new { FirstName = FirstName, LastName = LastName, Age = Age, FavoriteColor = FavColor });
        }

//  ===================== END OF ASSIGNMENT ====================


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

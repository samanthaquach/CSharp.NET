using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace RandomPasscode.Controllers
{
    public class HelloController : Controller
    {

        // =========== FOR VIEWS ========
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("Count") == null)  // ---- CHECKING COUNT ----
            {
                HttpContext.Session.SetInt32("Count", 1);
            }
            else
            {
                HttpContext.Session.SetInt32("Count", ((int)HttpContext.Session.GetInt32("Count") + 1)); //--- COUNT EVERY TIME GENERATES ----
            }
            ViewBag.Count = (int)HttpContext.Session.GetInt32("Count"); // --- VARIABLE COUNT -----
            ViewBag.Rando = Generate.MakingString(); // ---- FROM GENERATING CODE: SETTING VARIABLE ---

            return View("Index");
        }

        [HttpGet]
        [Route("clear")]
        public IActionResult Clear()
        {
            HttpContext.Session.Clear();
            return Redirect("/");
            //return View("Index");
        }

    // ==== OUT OF CONTROLLER ===

    }

    // ============ GENERATING THE CODE ===========
    public class Generate
    {
        public static Random rnd = new Random();
        public static string MakingString() // ---- GENERATING LETTERS ----
        {
            string Str = ""; // ---- SETTING VARIABLE ---
            int makeChar;
            while (Str.Length < 14)
            {
                int num = rnd.Next(1, 3); // --- CHOOSE RANDOM INT 1-2 ---
                if (num == 1)
                {
                    makeChar = rnd.Next(48, 58); // --- RANDOM NUMBER BETWEEN 48 - 57 
                }
                else // ELSE IF 2
                {
                    makeChar = rnd.Next(65, 91); // --- TO CHOOSE FROM ASCII CHARACTER CODE -- RANDOM GENERATED 65-91 ---
                }
                char letter = (char)makeChar; // --- (char) is makeChar: CREATING THE ASCII CHARACTER CODE --
                Str += letter.ToString(); // --- CONVERTING THE CHAR TO STRING AND CONCATENATE INTO STR ---
            }
            return Str;
        }
    }


    

}


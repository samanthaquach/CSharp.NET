using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
// using Quoting_Dojo;


namespace Quoting_Dojo.Controllers
{
    public class HomeController : Controller
    {
        // private DbConnector dbConnector;
        // public HomeController()
        // {
        //     dbConnector = new DbConnector();
        // }
        private readonly DbConnector _dbConnector;

        public HomeController(DbConnector connect)
        {
            _dbConnector = connect;
        }
    

        // // GET: /Home/

        // === MAIN PAGE ==
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
  
            return View();
        }

        //=== ADDING QUOTES ===
        [HttpPost]
        [Route("quotes")]
        public IActionResult Submit(string name, string quote)
        {
            Console.WriteLine(name);
            Console.WriteLine(quote);
            string query = $"INSERT INTO Users (name, quote) VALUES ('{name}', '{quote}')";
            Console.WriteLine("==================== this is the text =============");
            _dbConnector.Execute(query);
            ViewBag.Name = name;
            ViewBag.Quote = quote;
            return Redirect("/quotes");

        }

        // === GET PAGE FOR QUOTES ===
        [HttpGet]
        [Route("quotes")]
        public IActionResult Show()
        {
            string query = "SELECT * FROM Users";
            Console.WriteLine(query);
            // List<Dictionary<string, object>>
            var allUsers = _dbConnector.Query(query);
            ViewBag.allUsers = allUsers;
            Console.WriteLine(ViewBag.allUsers);
            return View("Show");

        }

    }
    
}

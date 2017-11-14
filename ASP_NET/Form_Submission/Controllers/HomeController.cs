using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Form_Submission.Models;

namespace Form_Submission.Controllers
{
    public class HomeController : Controller
    {
        private static List<string> errors = new List<string>();
        private readonly DbConnector _dbConnector;

        public HomeController(DbConnector connect)
        {
            _dbConnector = connect;
        }

        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            
            
            return View();
        }

        [HttpPost]
        [Route("register")]
        public IActionResult Register(string firstname, string lastname, int age, string email, string password)
        {
            string query = $"INSERT INTO Users (firstname, lastname, age, email, password) VALUES ('{firstname}', '{lastname}', '{age}', '{email}', '{password}')";
            Console.WriteLine("==================== INSERTING NOW ===============");
            _dbConnector.Execute(query);
            ViewBag.Name = firstname;

            // var User = query;

            User NewUser = new User
            {
                firstname = firstname,
                lastname = lastname,
                email = email,
                age = age,
                password = password
            };

            if (TryValidateModel(NewUser) == false)
            {
                ViewBag.ModelFields = ModelState.Values;
                return View();
            }
            // otherwise validation passes, redirect to success
            else
            {
                return View("Success");
            }
            
        }
    }
}

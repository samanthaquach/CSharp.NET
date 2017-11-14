using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Form_Submission.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Form_Submission.Controllers
{
    public class HomeController : Controller
    {
        private static List<string> errors = new List<string>();
        private static string whichErr = null;
        private readonly DbConnector _dbConnector;

        private FormContext _context;
        public HomeController(DbConnector connect)
        {
            _dbConnector = connect;
        }

        public HomeController(FormContext context)
        {
            _context = context;
        }

        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            List<User> Everyone = _context.allUsers.ToList(); // Everyone is the variable. allUsers/User is coming from the models in Dbset.

            ViewBag.showReg = false; //hide the registration notification box
            ViewBag.errors = errors; //set ViewBag.errors equal to the errors list
            if (whichErr == "reg") //if registration errors were set...
            {
                ViewBag.showReg = true; //unhide the registration notification box
            }

            return View();
        }

// LOGIN PAGE

        [HttpGet]
        [Route("login")]
        public IActionResult Login()
        {
            ViewBag.showLog = false; //hide the login notification box
            ViewBag.errors = errors; //set ViewBag.errors equal to the errors list
            if (whichErr == "log") //if log in errors were set...
            {
                ViewBag.showLog = true; //unhide the login notification box
            }

            return View("Login");
        }

// LOGGING IN USER LOGGING IN USER LOGGING IN USER LOGGING IN USER 

        [HttpPost]
        [Route("login")]
        public IActionResult Login_User(string email, string password)
        {
            LogUser NewUser = new LogUser
            {
                email = email,
                password = password,
            };

            string query = $"SELECT * FROM users WHERE email = '{email}' ";
            var result = _dbConnector.Query(query);
            if (result.Count == 0)
            {
                // TempData["fail"] = "No user";
                errors.Add("Username or password incorrect.");
                whichErr = "log";
                return RedirectToAction("login");
            }

            if (TryValidateModel(NewUser) == false)
            {
                ViewBag.ModelFields = ModelState.Values;
                foreach (var error in ModelState.Values)
                {
                    if (error.Errors.Count > 0) //assuming the Error count is greater than 0
                    {
                        string errorMess = (string)error.Errors[0].ErrorMessage; //create a string to store each error message
                        errors.Add(errorMess); //add that message to the errors list
                        whichErr = "log"; //set whichErr to a login error
                    }
                }
                return RedirectToAction("login");
            }
            // otherwise validation passes, redirect to success
            else
            {
                HttpContext.Session.SetString("LOGGED_IN_USER", email);
                string currUser = HttpContext.Session.GetString("LOGGED_IN_USER");
                ViewBag.Name = email;
                Console.WriteLine("==================== EMAIL EMAIL EMAIL ===============");
                return View("Welcome");
            }

        }

// REGISTERING USER REGISTERING USER REGISTERING USER 
        [HttpPost]
        [Route("register")]
        public IActionResult Register(string firstname, string lastname, int age, string email, string password, string confirm)
        {
            errors.Clear(); //clear out all errors to begin
            whichErr = null; //reset whichErr
            string first = $"SELECT email FROM users WHERE email = '{email}'";
            var checkUser = _dbConnector.Query(first);

            User NewUser = new User
            {
                firstname = firstname,
                lastname = lastname,
                email = email,
                age = age,
                password = password,
                confirm = confirm
            };


            if (TryValidateModel(NewUser) == false)
            {
                
                if (NewUser.password == NewUser.confirm)
                {
                    PasswordHasher<User> Hasher = new PasswordHasher<User>();
                    NewUser.password = Hasher.HashPassword(NewUser, NewUser.password);
                }
                ViewBag.ModelFields = ModelState.Values;
                
                return View();
            }
        
            if (checkUser.Count > 0) //if a user is retrieved based on the entered email address..
            {
                errors.Add("User already exists, please log in."); //add this error to the errors list
                whichErr = "reg"; //set whichErr to a registration error
                return RedirectToAction("Index");
            }
            // otherwise validation passes, redirect to success
            
            else
            {
                string query = $"INSERT INTO Users (firstname, lastname, age, email, password) VALUES ('{firstname}', '{lastname}', '{age}', '{email}', '{NewUser.password}')";
                _dbConnector.Execute(query);
                ViewBag.Name = firstname;
                return View("Success");
            }
            
        }

// SUCCESS PAGE SUCCESS PAGE SUCCESS PAGE SUCCESS PAGE

        [HttpGet]
        [Route("")]
        public IActionResult Success(string email)
        {
            // List<User> Everyone = _context.allUsers.Where(thisUser => User.firstname = "Sam").ToList(); // Everyone is the variable. allUsers/User is coming from the models in Dbset.
            User ReturnedValue = _context.allUsers.SingleOrDefault(user => user.email == email);
            return View("Success");
        }

// LOG OUT 

        [HttpGet]
        [Route("/logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    
    }
}



// adding or updating a person 


// public IActionResult Create()
// {
//     Person NewPerson = new Person
//     {
//         Name = "Name",
//         Email = "email@example.com",
//         Password = "HashThisFirst",
//         Age = 24
//     };

//     _context.Add(NewPerson);
//     // OR _context.Users.Add(NewPerson);
//     _context.SaveChanges();
// }

// Person RetrievedUser = _context.Users.SingleOrDefault(user => user.ID == SomeNumber);
// RetrievedUser.Name = "New name";
// _context.SaveChanges();

// Person RetrievedUser = _context.Users.SingleOrDefault(user => user.ID == SomeNumber);
// _context.Users.Remove(RetrievedUser);
// _context.SaveChanges();

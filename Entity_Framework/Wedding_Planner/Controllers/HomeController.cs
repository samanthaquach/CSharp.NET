using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Wedding_Planner.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Wedding_Planner.Controllers
{
    public class HomeController : Controller
    {

        private static List<string> errors = new List<string>();
        private static string whichErr = null;

        private WeddingContext _context;
        public HomeController(WeddingContext context)
        {
            _context = context;
        }


        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.showReg = false; //hide the registration notification box
            ViewBag.errors = errors; //set ViewBag.errors equal to the errors list
            if (whichErr == "reg") //if registration errors were set...
            {
                ViewBag.showReg = true; //unhide the registration notification box
            }

            return View();
        }

        // REGISTERING USER 

        [HttpPost]
        [Route("register")]
        public IActionResult Register(string firstname, string lastname, string email, string password, string confirm)
        {
            errors.Clear(); //clear out all errors to begin
            whichErr = null; //reset whichErr
            var checkUser = _context.Users.SingleOrDefault(user => user.email == email);

            User NewUser = new User
            {
                firstname = firstname,
                lastname = lastname,
                email = email,
                password = password,
                confirm = confirm
            };


            if (TryValidateModel(NewUser) == false)
            {

                ViewBag.ModelFields = ModelState.Values;
                foreach (var error in ModelState.Values)
                {
                    if (error.Errors.Count > 0) //assuming the Error count is greater than 0
                    {
                        string errorMess = (string)error.Errors[0].ErrorMessage; //create a string to store each error message
                        errors.Add(errorMess); //add that message to the errors list
                        whichErr = "reg"; //set whichErr to a login error
                    }
                }

                return View();
            }

            if (checkUser != null) //if a user is retrieved based on the entered email address..
            {
                errors.Add("User already exists, please log in."); //add this error to the errors list
                whichErr = "reg"; //set whichErr to a registration error
                return RedirectToAction("Index");
            }
            // otherwise validation passes, redirect to success

            else
            {
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                string hashed = Hasher.HashPassword(NewUser, NewUser.password);

                User NewPerson = new User
                {
                    firstname = firstname,
                    lastname = lastname,
                    email = email,
                    password = hashed,
                    confirm = hashed

                };
                _context.Add(NewPerson);
                _context.SaveChanges();

                HttpContext.Session.SetString("LOGGED_IN_USER", email);
                string currUser = HttpContext.Session.GetString("LOGGED_IN_USER");

                return Redirect("wedding");
            }

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

        // LOGGING IN A USER

        [HttpPost]
        [Route("login")]
        public IActionResult Login_User(LogUser NewLogUser)
        {
            LogUser NewUser = new LogUser
            {
                email = NewLogUser.email,
                password = NewLogUser.password,
            };

            var checkUser = _context.Users.SingleOrDefault(user => user.email == NewLogUser.email);
            // var Hasher = new PasswordHasher<User>();

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

                if (checkUser is null)
                {
                    errors.Add("Username or password incorrect.");
                    whichErr = "log";
                    return RedirectToAction("login");
                }

                return RedirectToAction("login");
            }


            // otherwise validation passes, redirect to success
            else
            {

                if (checkUser != null)
                {
                    PasswordHasher<User> Hasher = new PasswordHasher<User>();
                    if (0 != Hasher.VerifyHashedPassword(checkUser, checkUser.password, NewLogUser.password))
                    {
                        HttpContext.Session.SetString("LOGGED_IN_USER", NewLogUser.email);
                        string currUser = HttpContext.Session.GetString("LOGGED_IN_USER");
                        // ViewBag.Name = NewLogUser.email;

                    }
                }

                return Redirect("wedding");
            }

        }


        // LOG OUT 

        [HttpGet]
        [Route("clear")]
        public IActionResult Clear()
        {
            HttpContext.Session.Clear();
            return Redirect("/");
        }



        // end of public class <==
    }
}

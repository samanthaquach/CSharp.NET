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
        // private static User currUser = null;
        private const string LOGGED_IN_USER = "lxs112";
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
            if (HttpContext.Session.GetString("LOGGED_IN_USER") == null)
            {
                return Redirect("login");
            }
            
            return Redirect("welcome");
        }

        [HttpGet]
        [Route("login")]
        public IActionResult Login()
        {

            return View("Login");
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login_User(string email, string password)
        {
            LogUser NewUser = new LogUser
            {
                email = email,
                password = password,
            };
            
            // string query = $"SELECT * FROM users WHERE email = '{email}' ";
            // var result = _dbConnector.Query(query);
            // if (result.Count == 0)
            // {
            //     TempData["fail"] = "No user";
            //     return View("loginagain");
            // }
            // else{
            //     HttpContext.Session.SetString("LOGGED_IN_USER", email);
            //     string currUser = HttpContext.Session.GetString("LOGGED_IN_USER");
            // }
            // var user = result[0]["email"];

            
            if (TryValidateModel(NewUser) == false)
            {
                ViewBag.ModelFields = ModelState.Values;
                // TempData["fail"] = "No User Found!";
                return View("loginagain");
            }
            // otherwise validation passes, redirect to success
            else
            {
                
                Console.WriteLine(email);
                ViewBag.Name = email;
                HttpContext.Session.SetString("LOGGED_IN_USER", email);
                string currUser = HttpContext.Session.GetString("LOGGED_IN_USER");
                // Console.WriteLine(currUser);

                Console.WriteLine("==================== EMAIL EMAIL EMAIL ===============");
                // string query = $"SELECT * FROM Users WHERE email = '{email}'";
                // var User = _dbConnector.Query(query);
                // ViewBag.User = User;
                // ViewBag.Name = email;
                return Redirect("welcome");
            }

        }

        [HttpGet]
        [Route("welcome")]
        public IActionResult UserPage(string email)
        {
            string currentuser = HttpContext.Session.GetString("LOGGED_IN_USER");
            Console.WriteLine(currentuser);
            string user = $"SELECT * FROM Users WHERE email = '{currentuser}'";
            var thisUser = _dbConnector.Query(user);
            ViewBag.User = thisUser;
            string query = "SELECT * FROM Messages";
            var allMessages = _dbConnector.Query(query);
            Console.WriteLine(user);
            ViewBag.allMessages = allMessages;
            string allComments = $"SELECT users.firstname, Messages.id AS Message_id, Messages.message, comment.id, comment.comment AS comment, comment.Users_id FROM Messages JOIN comment ON Messages.id JOIN users ON Comment.users_id=users.id";
            ViewBag.comment = allComments;
            ViewBag.Name = HttpContext.Session.GetString("LOGGED_IN_USER");
            Console.WriteLine("==================== USER PAGE USER PAGE ===============");

            return View("Welcome");
        }
        //=== ADDING COMMENT ADDING COMMENT ADDING COMMENT ADDING COMMENT ===
        [HttpPost]
        [Route("comment")]
        public IActionResult Add_Comment(int id, string comment)
        {
            var Messages_id = id;
            string currentuser = HttpContext.Session.GetString("LOGGED_IN_USER");
            Console.WriteLine(currentuser);
            string user = $"SELECT * FROM Users WHERE email = '{currentuser}'";
            Console.WriteLine(user);
            var thisUser = _dbConnector.Query(user);
            var Users_id = thisUser[0]["id"];
            var update_at = DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss");
            var created_at = DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss");
            Console.WriteLine(thisUser);
            string query = $"INSERT INTO Comment (comment, created_at, update_at, Messages_id, Users_id) VALUES ('{comment}', '{created_at}', '{update_at}', '{Messages_id}', '{Users_id}') ";
            Console.WriteLine("==================== ADDING COMMENT ADDING COMMENT ADDING COMMENT ===============");
            _dbConnector.Execute(query);
            return Redirect("welcome");
        }

        //=== ADDING MESSAGES ===

        [HttpPost]
        [Route("addmessages")]
        public IActionResult Submit(string message, string email)
        {
            string currentuser = HttpContext.Session.GetString("LOGGED_IN_USER");
            Console.WriteLine(currentuser);
            string user = $"SELECT * FROM Users WHERE email = '{currentuser}'";
            Console.WriteLine(user);
            var thisUser = _dbConnector.Query(user);
            var Users_id = thisUser[0]["id"];
            var updated_at = DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss");
            var created_at = DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss");
            Console.WriteLine(thisUser);
            // Console.WriteLine(message);
            // var Users_id = id;
            string query = $"INSERT INTO Messages (message, Users_id, created_at, updated_at) VALUES ('{message}', '{Users_id}', '{created_at}', '{updated_at}') ";
            Console.WriteLine("==================== ADDING MESSAGE===============");
            _dbConnector.Execute(query);
            return Redirect("welcome");

        }


        [HttpPost]
        [Route("register")]
        public IActionResult Register(string firstname, string lastname, int age, string email, string password, string confirm)
        {

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
                ViewBag.ModelFields = ModelState.Values;
                return View();
            }
            // otherwise validation passes, redirect to success
            else
            {
                var updated_at = DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss");
                var created_at = DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss");
                string query = $"INSERT INTO Users (firstname, lastname, age, email, password, created_at, updated_at) VALUES ('{firstname}', '{lastname}', '{age}', '{email}', '{password}', '{created_at}', '{updated_at}')";
                Console.WriteLine("==================== INSERTING NOW ===============");
                _dbConnector.Execute(query);
                ViewBag.Name = firstname;
                HttpContext.Session.SetString("LOGGED_IN_USER", email);
                string currUser = HttpContext.Session.GetString("LOGGED_IN_USER");
                return Redirect("welcome");
            }
            
        }
    }
}

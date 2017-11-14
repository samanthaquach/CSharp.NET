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

        // public HomeController(DbConnector connect)
        // {
        //     _dbConnector = connect;
        // }

        private FormContext _context;
        public HomeController(FormContext context)
        {
            _context = context;
        }

        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            // List<User> Everyone = _context.allUsers.ToList(); // Everyone is the variable. allUsers/User is coming from the models in Dbset.
            
            ViewBag.showReg = false; //hide the registration notification box
            ViewBag.errors = errors; //set ViewBag.errors equal to the errors list
            if (whichErr == "reg") //if registration errors were set...
            {
                ViewBag.showReg = true; //unhide the registration notification box
            }

            return View();
        }


// REGISTERING REVIEW 

        [HttpPost]
        [Route("register")]
        public IActionResult Register(string firstname, string lastname, string restaurant, string review, string datevisit, int rating)
        {
            errors.Clear(); //clear out all errors to begin
            whichErr = null; //reset whichErr

            User NewUser = new User
            {
                firstname = firstname,
                lastname = lastname,
                restaurant = restaurant,
                review = review,
                datevisit = datevisit,
                rating = rating
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
                        whichErr = "reg"; //set whichErr to a register error
                    }
                }
                
                return Redirect("/");
            }

            // otherwise validation passes, redirect to success
            
            else
            {
                // var date = datevisit.ToString("yyyy/MM/dd");
                User NewReview = new User
                {
                    firstname = firstname,
                    lastname = lastname,
                    restaurant = restaurant,
                    review = review,
                    datevisit = datevisit,
                    rating = rating

                };
                _context.Add(NewReview);
                _context.SaveChanges();
                // string query = $"INSERT INTO Users (firstname, lastname, restaurant, review, datevisit, rating) VALUES ('{firstname}', '{lastname}', '{restaurant}', '{review}', '{datevisit}', '{rating}')";
                // _dbConnector.Execute(query);
                return Redirect("reviews");
            }
            
        }

// SUCCESS PAGE SUCCESS PAGE SUCCESS PAGE SUCCESS PAGE

        [HttpGet]
        [Route("reviews")]
        public IActionResult Success(string review)
        {
            // List<User> Everyone = _context.Users.Where(thisUser => User.firstname = "Sam").ToList(); // Everyone is the variable. allUsers/User is coming from the models in Dbset.
            List<User> Everyone = _context.Users.OrderByDescending(thisUser => thisUser.datevisit).ToList();
            // User ReturnedValue = _context.allUsers.SingleOrDefault(user => user.review == review);
            return View(Everyone);
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

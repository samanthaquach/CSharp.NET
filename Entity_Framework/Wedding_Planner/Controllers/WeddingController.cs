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
    public class WeddingController : Controller
    {

        private static List<string> errors = new List<string>();
        private static string whichErr = null;

        private WeddingContext _context;
        public WeddingController(WeddingContext context)
        {
            _context = context;
        }


        // GET: /Home/
        [HttpGet]
        [Route("planner")]
        public IActionResult Planner()
        {
            if (HttpContext.Session.GetString("LOGGED_IN_USER") == null)
            {
                return Redirect("/");
            }

            List<Planning> Planning = _context.planning.ToList();
            List<User> Users = _context.Users.ToList();
            List<RSVP> RSVP = _context.RSVP.ToList();
            Wrapper model = new Wrapper(Users, Planning, RSVP);

            List<Planning> Guests = _context.planning.Include(guest => guest.User).Include(guest => guest.RSVP).ToList();
            ViewBag.AllGuests = Guests;
            ViewBag.SeeWho = RSVP;

            string currUser = HttpContext.Session.GetString("LOGGED_IN_USER");
            var person = _context.Users.SingleOrDefault(user => user.email == currUser);
            ViewBag.id = person.UserId;


            return View("Planner", model);
        }

// wedding index page

        [HttpGet]
        [Route("wedding")]
        public IActionResult Wedding()
        {
            if (HttpContext.Session.GetString("LOGGED_IN_USER") == null)
            {
                return Redirect("login");
            }
            ViewBag.showWedding = false; //hide the wedding notification box
            ViewBag.errors = errors; //set ViewBag.errors equal to the errors list
            if (whichErr == "wedding") //if wedding errors were set...
            {
                ViewBag.showReg = true; //unhide the wedding notification box
            }

            return View("Wedding");
        }

// show wedding event page

        [HttpGet]
        [Route("show/{id}")]
        public IActionResult show(int id)
        {
            if (HttpContext.Session.GetString("LOGGED_IN_USER") == null)
            {
                return Redirect("/");
            }
            
            List<Planning> Planning = _context.planning.Where(plan => plan.id == id).ToList();
            List<RSVP> RSVP = _context.RSVP.ToList();
            var weddingevent = _context.planning.SingleOrDefault(use => use.id == id);
            string currUser = HttpContext.Session.GetString("LOGGED_IN_USER");
            var person = _context.Users.SingleOrDefault(user => user.email == currUser);
            List<Planning> allGoers = _context.planning.Include(post => post.User).Include(x => x.RSVP).Where(plan => plan.id == id).ToList();
            ViewBag.allGoers = allGoers;
            ViewBag.id = person.UserId;
            ViewBag.planid = id;
            ViewBag.RSVP = RSVP;
            ViewBag.User = person.firstname;
            var eventdate = weddingevent.date; //trying to have date only for wedding date
            DateTime dateOnly = eventdate.Date; 
            ViewBag.EventDate = dateOnly.ToString("MM/dd/yyyy"); //date only viewed
            List<User> Users = _context.Users.ToList();
            Wrapper model = new Wrapper(Users, Planning, RSVP);
            return View("Show", model);
        }

// create a wedding

        [HttpPost]
        [Route("process")]
        public IActionResult Process(string wedderone, string weddertwo, DateTime date, string address)
        {
            string currUser = HttpContext.Session.GetString("LOGGED_IN_USER");
            var person = _context.Users.SingleOrDefault(user => user.email == currUser);
            List<Planning> ActiveUser = _context.planning.Include(post => post.User).ToList();

            Planning NewPlans = new Planning
            {
                wedderone = wedderone,
                weddertwo = weddertwo,
                date = date,
                address = address
            };

            if (TryValidateModel(NewPlans) == false)
            {
                ViewBag.ModelFields = ModelState.Values;
                foreach (var error in ModelState.Values)
                {
                    if (error.Errors.Count > 0) //assuming the Error count is greater than 0
                    {
                        string errorMess = (string)error.Errors[0].ErrorMessage; //create a string to store each error message
                        errors.Add(errorMess); //add that message to the errors list
                        whichErr = "wedding"; //set whichErr to a login error
                    }
                }
                
            }

            Planning NewWedding = new Planning
            {
                wedderone = wedderone,
                weddertwo = weddertwo,
                date = date,
                address = address,
                Userid = person.UserId

            };
            _context.Add(NewWedding);
            _context.SaveChanges();


            return Redirect("planner");
        }

// rsvp user's attendance

        [HttpPost]
        [Route("show/{id}")]
        public IActionResult RSVP(int id, int Userid, int Planningid)
        {
            var planid = id;
            string currUser = HttpContext.Session.GetString("LOGGED_IN_USER");
            var person = _context.Users.SingleOrDefault(user => user.email == currUser);
            List<RSVP> Guests = _context.RSVP.Include(guest => guest.Guest).Include(guest => guest.Planning).ToList();
            ViewBag.Check = Guests;


            RSVP NewGuest = new RSVP
            {
                Userid = Userid,
                Planningid = id

            };
            _context.Add(NewGuest);
            _context.SaveChanges();

            return RedirectToAction("planner");
        }

// return (delete) the user invitation

        [HttpGet]
        [Route("unrsvp/{id}")]
        public IActionResult delete(int id, int Userid, int Planningid)
        {
            var planid = id;
            string currUser = HttpContext.Session.GetString("LOGGED_IN_USER");
            var person = _context.Users.SingleOrDefault(user => user.email == currUser);
            List<RSVP> AllGuests = _context.RSVP.Where(guest => guest.Planningid == id).ToList();
            RSVP Del = AllGuests.SingleOrDefault(user => user.Userid == person.UserId);
            _context.RSVP.Remove(Del);
            _context.SaveChanges();

            return RedirectToAction("planner");
        }

    }
}

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

        // private static List<string> errors = new List<string>();
        // private static string whichErr = null;

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

            List<RSVP> Guests = _context.RSVP.Include(guest => guest.Guest).Include(guest => guest.Planning).ToList();
            

            string currUser = HttpContext.Session.GetString("LOGGED_IN_USER");
            var person = _context.Users.SingleOrDefault(user => user.email == currUser);
            ViewBag.id = person.id;


            return View("Planner", model);
        }

        [HttpGet]
        [Route("wedding")]
        public IActionResult Wedding()
        {
            if (HttpContext.Session.GetString("LOGGED_IN_USER") == null)
            {
                return Redirect("login");
            }

            return View("Wedding");
        }

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
            ViewBag.id = person.id;
            ViewBag.planid = id;
            ViewBag.User = person.firstname;
            var eventdate = weddingevent.date; //trying to have date only for wedding date
            DateTime dateOnly = eventdate.Date; 
            ViewBag.EventDate = dateOnly.ToString("MM/dd/yyyy"); //date only viewed
            List<User> Users = _context.Users.ToList();
            Wrapper model = new Wrapper(Users, Planning, RSVP);
            return View("Show", model);
        }
        [HttpPost]
        [Route("process")]
        public IActionResult Process(string wedderone, string weddertwo, DateTime date, string address)
        {
            string currUser = HttpContext.Session.GetString("LOGGED_IN_USER");
            var person = _context.Users.SingleOrDefault(user => user.email == currUser);
            List<Planning> ActiveUser = _context.planning.Include(post => post.User).ToList();

            Planning NewWedding = new Planning
            {
                wedderone = wedderone,
                weddertwo = weddertwo,
                date = date,
                address = address,
                Userid = person.id

            };
            _context.Add(NewWedding);
            _context.SaveChanges();


            return Redirect("planner");
        }

        [HttpPost]
        [Route("show/{id}")]
        public IActionResult RSVP(int id, int Userid, int Planningid)
        {
            var planid = id;
            string currUser = HttpContext.Session.GetString("LOGGED_IN_USER");
            var person = _context.Users.SingleOrDefault(user => user.email == currUser);

            RSVP NewGuest = new RSVP
            {
                Userid = Userid,
                Planningid = id

            };
            _context.Add(NewGuest);
            _context.SaveChanges();

            return RedirectToAction("planner");
        }

        [HttpGet]
        [Route("unrsvp/{id}")]
        public IActionResult delete(int id, int Userid, int Planningid)
        {
            var planid = id;
            string currUser = HttpContext.Session.GetString("LOGGED_IN_USER");
            var person = _context.Users.SingleOrDefault(user => user.email == currUser);

            RSVP Delete = _context.RSVP.SingleOrDefault(user => user.Userid == person.id && user.Planningid == planid);
            _context.RSVP.Remove(Delete);
            _context.SaveChanges();

            return RedirectToAction("planner");
        }

    }
}

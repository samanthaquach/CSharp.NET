using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace Ajax_Notes.Controllers
{
    public class HomeController : Controller
    {
        private readonly DbConnector _dbConnector;

        public HomeController(DbConnector connect)
        {
            _dbConnector = connect;
        }

        // === GET INDEX ===

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            string query = "SELECT id, title, note FROM users";
            Console.WriteLine(query);
            // === subsitute List<Dictionary<string, object>> ===
            var allNotes = _dbConnector.Query(query);
            ViewBag.allNotes = allNotes;
            Console.WriteLine(ViewBag.allNotes);
            return View();
        }

        //=== ADDING QUOTES ===

        [HttpPost]
        [Route("addnotes")]
        public IActionResult Submit(string note, string title)
        {
            Console.WriteLine(note);
            Console.WriteLine(title);
            string query = $"INSERT INTO users (note, title) VALUES ('{note}', '{title}')";
            Console.WriteLine("==================== INSERTING NOW ===============");
            _dbConnector.Execute(query);
            ViewBag.Note = note;
            ViewBag.Title = title;
            return Redirect("/");

        }

        //=== UPDATE PAGE ===
        

        [HttpGet]
        [Route("update/{id}")]
        public IActionResult Show(int id, string note, string title)
        {
            Console.WriteLine(id);
            string query = $"SELECT * FROM users WHERE id = {id}";
            // Console.WriteLine(query);
            var thisNote = _dbConnector.Query(query);
            ViewBag.thisNote = thisNote;
            ViewBag.Note = note;
            ViewBag.title = title;
            ViewBag.id = id;
            Console.WriteLine("========= SHOW NOTE ========");
            // Console.WriteLine(ViewBag.Note);
            return View("Update");
        }

        //=== UPDATE PAGE ===

        [HttpPost]
        [Route("update/{id}")]
        public IActionResult Update(string note, string title, int id)
        {
            Console.WriteLine(id);
            string query = $"UPDATE Users SET note = '{note}', title = '{title}' WHERE id = {id}";
            Console.WriteLine("======= UPDATING WOOHOO! ====");
            _dbConnector.Execute(query);
            ViewBag.Note = note;
            ViewBag.Title = title;
            Console.WriteLine(ViewBag.Note);
            return Redirect("/");
        }

        //=== DELETE NOTE ===

        [HttpGet]
        [Route("delete/{id}")]
        public IActionResult Delete(int id)
        {
            Console.WriteLine(id);
            string query = $"DELETE FROM users WHERE id = {id}";
            Console.WriteLine("============== DELETING DELETING ==============");
            _dbConnector.Execute(query);
            Console.WriteLine(query);
            return Redirect("/");
        }
    }
}

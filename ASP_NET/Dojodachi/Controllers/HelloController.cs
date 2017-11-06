using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace Dojodachi.Controllers
{
    public class HelloController : Controller
    {
        public static Dachi samagachi; // ------- CREATING A DACHI ------- MAKE HER NOW 
        public static Random rnd = new Random(); //  ------- CREATING RANDOM OBJECT --------
        // =========== FOR VIEWS ========
        // ======= ResultText: SHOWS THE STATUS OF YOUR DACHI =====
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            if (samagachi == null) // -- CHECKING FOR SAMAGACHI ---
            {
                samagachi = new Dachi(); 
                ViewBag.ResultText = "Hello, I'm your Samagachi!"; 
            }
            else // ------- IF SAMAGACHI ALREADY EXITS --------
            {
                ViewBag.ResultText = TempData["ResultText"]; // ------ SHOWING SAMAGACHI ACTIVITY -------
            }
            if (samagachi.Happy) 
            {
                ViewBag.ResultPic = "/images/gotchi_happy.gif"; // ---- SETTING MY SONIC DACHI HAPPY GIF -----
            }
            else 
            {
                ViewBag.ResultPic = "/images/gotchi_sad.gif"; // ---- SETTING MY SONIC DACHI SAD GIF -----
            }
            if (!samagachi.Alive && samagachi.Win) // ---- DISPLAY RESET IF SAMAGACHI ISN'T ALIVE ----
            {
                ViewBag.ResultText = "Congratulations, you won!"; 
            }
            else if (!samagachi.Alive && !samagachi.Win) // --- IF SAMAGACHI IS DEAD ---
            {
                ViewBag.ResultPic = "/images/gotchi_dead.gif"; 
                ViewBag.ResultText = "Oh no, your Samagachi has passed away..."; 
            }
            ViewBag.Fullness = samagachi.Fullness; // -- LISTING ALL SAMAGACHI VALUES --
            ViewBag.Happiness = samagachi.Happiness;
            ViewBag.Meals = samagachi.Meals;
            ViewBag.Energy = samagachi.Energy;
            ViewBag.Alive = samagachi.Alive;
            
            return View("Index");

        }

        [HttpGet]
        [Route("Feed")]
        public IActionResult Feed()
        {
            if (!samagachi.Alive) // --- IF DEAD --
            {
                return RedirectToAction("Index"); // --- RETURN TO INDEX --
            }
            if (samagachi.Meals == 0) // --- IF THERE ISN'T ENOUGH MEALS ---
            {
                TempData["ResultText"] = "Work for more meals! Not enough meals for Samagachi."; 
                return RedirectToAction("Index"); 
            }
            samagachi.HappyCheck(); // --- CHECK TO SEE SAMAGACHI IS HAPPY ---
            if (samagachi.Happy) 
            {
                int fill = rnd.Next(5, 11); // -- A NUMBER BETWEEN 5-11 --
                samagachi.Fullness += fill; // --- ADD THE RANDOM NUMBER FOR FULLNESS --
                TempData["ResultText"] = $"Your Samagachi is full! Fullness +{fill}, Meals -1."; // --- FULLNESS LEVEL/STATUS --
            }
            else 
            {
                TempData["ResultText"] = "You fed your Dachi but he didn't like it...Meals -1."; 
            }
            samagachi.Meals -= 1; // --- DECREASE MEAL BY 1 --
            samagachi.DeathCheck(); // -- DEATH CHECK --
            return RedirectToAction("Index"); 
        }

        [HttpGet]
        [Route("Play")]
        public IActionResult Play()
        {
            if (!samagachi.Alive) 
            {
                return RedirectToAction("Index");
            }
            if (samagachi.Energy == 0) 
            {
                TempData["ResultText"] = "Your Samagachi needs more sleep in order to play!"; 
                return RedirectToAction("Index"); 
            }
            samagachi.HappyCheck();
            if (samagachi.Happy) 
            {
                int fill = rnd.Next(5, 11); 
                samagachi.Happiness += fill; // -- ADD NUMBER TO HAPPINESS --
                TempData["ResultText"] = $"YAY! Your Samagachi is happy! Happiness +{fill}, Energy -5."; 
            }
            else 
            {
                TempData["ResultText"] = "Whoa! What happen?! Your Samagachi doesn't like this!"; // -- SAMAGACHI LIKES TO PLAY BUT NOT HAPPY --
            }
            samagachi.Energy -= 5; // --- DECREASE BY 5 ENERGY --
            samagachi.DeathCheck(); 
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("Work")]
        public IActionResult Work()
        {
            if (!samagachi.Alive)
            {
                return RedirectToAction("Index"); 
            }
            if (samagachi.Energy == 0)
            {
                TempData["ResultText"] = "Your Samagachi needs sleep in order to work!"; 
                return RedirectToAction("Index"); 
            }
            int fill = rnd.Next(1, 4);
            samagachi.Meals += fill; 
            TempData["ResultText"] = $"Your Dachi worked! Meals +{fill}, Energy -5."; 
            samagachi.Energy -= 5; 
            samagachi.Happy = true; // --- SETTING DACHI TO HAPPINESS --
            samagachi.DeathCheck();
            return RedirectToAction("Index"); 
        }

        [HttpGet]
        [Route("Sleep")]
        public IActionResult Sleep()
        {
            if (!samagachi.Alive) 
            {
                return RedirectToAction("Index"); 
            }
            samagachi.Energy += 15; // -- INCREASE ENERGY BY 15 --
            samagachi.Fullness -= 5; // -- DECREASE ENERGY BY 5 --
            samagachi.Happiness -= 5; //-- DECREASE ENERGY BY 5 --
            TempData["ResultText"] = "YAY! Your Samagachi slept! Energy +15, Happiness -5, Fullness -5."; 
            samagachi.DeathCheck(); 
            samagachi.Happy = true; 
            return RedirectToAction("Index"); 
        }

        [HttpGet]
        [Route("Reset")]
        public IActionResult Reset()
        {
            samagachi = null; // --- RESETTING SAMAGACHI: SETTING SAMAGACHI TO NULL (RUN THE FIRST INDEX TO CREATE NEW DACI) ---
            return RedirectToAction("Index"); 
        }
    // } 


        public class Dachi
        {
            public static Random rnd = new Random(); // --- CREATE RANDOM OBJECTS ---
            public int Fullness, // --- ALL SAMAGACHIS FEELINGS -- (ATTRIBUTES)
            Happiness,
            Meals,
            Energy;
            public bool Alive,
            Happy,
            Win;
            public Dachi()
            {
                Fullness = 20; // "Your Dojodachi should start with 20 happiness, 20 fullness, 50 energy, and 3 meals."
                Happiness = 20;
                Meals = 3;
                Energy = 50;
                Alive = true;
                Happy = true;
                Win = false;
            }
            public void DeathCheck()
            {
                if (Fullness <= 0 || Happiness <= 0) // HOW TO INDICATE WHETHER SAMAGACHI IS ALIVE: HAPPINESS OR FULLNESS LESS THAN 0
                {
                    Alive = false; // SET TO FALSE
                }
                else if (Energy >= 100 && Fullness >= 100 && Happiness >= 100) 
                {
                    Alive = false; //set alive to false (unhides restart button and hides other buttons)??
                    Win = true; 
                }
            }
            public void HappyCheck()
            {
                int num = rnd.Next(1, 5); 
                if (num == 2) 
                {
                    Happy = false; 
                }
                else 
                {
                    Happy = true; 
                }
            }
        }

    }
}


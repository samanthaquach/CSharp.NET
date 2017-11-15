using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using BankAccount.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace BankAccount.Controllers
{

    public class TransactionController : Controller
    {
        // private static List<string> errors = new List<string>();
        // private static string whichErr = null;

        private BankContext _context;
        public TransactionController(BankContext context)
        {
            _context = context;
        }


        // Main Route (Success Page)

        [HttpGet]
        [Route("account")]
        public IActionResult Account()
        {
            if (HttpContext.Session.GetString("LOGGED_IN_USER") == null)
            {
                return Redirect("login");
            }

            return View();
        }

        // Banking

        [HttpPost]
        [Route("/banking")]
        public IActionResult Transaction(int deposit, int withdraw, int balance)
        {

            string currUser = HttpContext.Session.GetString("LOGGED_IN_USER");
            var person = _context.Users.SingleOrDefault(user => user.email == currUser);
            // List<Account> Account = _context.Account.Include(account => account.User).ToList(); // Adding this field for the models for Account
            balance = 0;            
            // List<Account> userbal = _context.Account.Include(post => post.User).ToList();
            List<User> userbal = _context.Users.Include(x => x.Account).ToList();
                    
            // var bal = user_balance.Account.balance + balance

            var newbalance = deposit + balance - withdraw;

            // if (Amount < 0 && ((Amount * -1) > user.Balance))
            // {
            //     TempData["Error"] = "Insufficient Funds";
            // }
            // user.Balance += Amount; // still a withdrawal because Amount is negative
            // _context.Withdrawals.Add(wd);
            // _context.SaveChanges();

            Account NewAccount = new Account
            {

                deposit = deposit,
                withdraw = withdraw,
                balance = newbalance,
                Users_id = person.id

            };
            _context.Account.Add(NewAccount);
            _context.SaveChanges();


            return Redirect("account");
        }
    }
}
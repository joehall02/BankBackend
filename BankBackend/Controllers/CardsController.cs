using BankBackend.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Principal;

namespace BankBackend.Controllers
{
	public class CardsController : Controller
	{
		public IActionResult Index(Account account)
		{

            using (var db = new BankContext())
            {
                var card = db.Cards.Where(c => c.AccountId == account.Id).FirstOrDefault();
                account = db.Accounts.Where(c => c.Id == account.Id).FirstOrDefault();
                
                TempData["card"] = card;
            }

            TempData["account"] = account;


            return View();
		}

		public IActionResult PassAccount(Account account)
		{
			using (var db = new BankContext())
			{
                account = db.Accounts.Where(c => c.Id == account.Id).FirstOrDefault();
            }

            TempData["account"] = account;

            return View("Create");
        }

        public IActionResult Create(Card card)
        {
            using (var db = new BankContext())
            {
                // adds user to the database
                db.Add(card);
                // saves the changes
                db.SaveChanges();
            }

            return RedirectToAction("Index", "Accounts");
        }

        public IActionResult Edit(Account account)
        {
            using (var db = new BankContext())
            {
                var cards = db.Cards.Where(c => c.Id == account.Id).FirstOrDefault();
                account = db.Accounts.Where(a => a.Id == account.Id).FirstOrDefault();

                TempData["cards"] = cards;
                TempData["account"] = account;
            }

            return View();
        }

        public IActionResult UpdateDetails(Card card)
        {
            using (var db = new BankContext())
            {
                var cards = db.Cards.Where(c => c.Id == card.Id).FirstOrDefault();
                cards.CardNumber = card.CardNumber;
                card.CardPin = card.CardPin;
                

                db.SaveChanges();
            }

            return RedirectToAction("Index", "Accounts");
        }
    }
}

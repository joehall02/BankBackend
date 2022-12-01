using BankBackend.Models;
using Microsoft.AspNetCore.Mvc;

namespace BankBackend.Controllers
{
    public class TransactionsController : Controller
    {
        public IActionResult Index(Account account)
        {
            List<Transaction> transactions = new List<Transaction>();

            using (var db = new BankContext())
            {
                transactions = db.Transactions.Where(t => t.AccountId == account.Id).ToList();
                account = db.Accounts.Where(c => c.Id == account.Id).FirstOrDefault();
            }

            TempData["transactions"] = transactions;
            TempData["account"] = account;

            return View();
        }

        public IActionResult Create(Account account)
        {
            using (var db = new BankContext())
            {
                account = db.Accounts.Where(a => a.Id == account.Id).FirstOrDefault();
            }

            TempData["account"] = account;

            return View();
        }

        public IActionResult Add(Transaction transaction)
        {
            var account = TempData["account"] as Account;

            using (var db = new BankContext())
            {
                db.Add(transaction);
                db.SaveChanges();

                account = db.Accounts.Where(a => a.Id == transaction.AccountId).FirstOrDefault();
            }


            return RedirectToAction("Index", account);
        }
    }
}

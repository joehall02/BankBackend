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
                // gets all customers from database
                transactions = db.Transactions.Where(t => t.AccountId == account.Id).ToList();
                account = db.Accounts.Where(c => c.Id == account.Id).FirstOrDefault();
            }

            TempData["transactions"] = transactions;
            TempData["account"] = account;

            return View();
        }
    }
}

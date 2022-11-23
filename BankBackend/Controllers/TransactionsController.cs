using BankBackend.Models;
using Microsoft.AspNetCore.Mvc;

namespace BankBackend.Controllers
{
	public class TransactionsController : Controller
	{
		public IActionResult Index(Customer customer)
		{
            List<Transaction> transactions = new List<Transaction>();

            using (var db = new BankContext())
            {
                // gets all customers from database
                transactions = db.Transactions.Where(t => t.CustomerId == customer.Id).ToList();
                customer = db.Customers.Where(c => c.Id == customer.Id).FirstOrDefault();
            }

            TempData["transactions"] = transactions;
            TempData["customer"] = customer;

            return View();
		}
	}
}

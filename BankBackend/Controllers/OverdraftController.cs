using BankBackend.Models;
using Microsoft.AspNetCore.Mvc;

namespace BankBackend.Controllers
{
	public class OverdraftController : Controller
	{
		public IActionResult Index()
		{
            List<Customer> customers = new List<Customer>();

            using (var db = new BankContext())
            {
                // gets all customers from database
                customers = db.Customers.Where(c => c.Salary >= 30000).ToList();
            }

            TempData["customers"] = customers;

            return View();
		}
	}
}

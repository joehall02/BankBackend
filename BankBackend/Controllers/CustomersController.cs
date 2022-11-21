using BankBackend.Models;
using Microsoft.AspNetCore.Mvc;

namespace BankBackend.Controllers
{
    public class CustomersController : Controller
    {
        public IActionResult Index()
        {
            // creates list to hold customer objects
            List<Customer> customers = new List<Customer>();

            using (var db = new BankContext())
            {
                // gets all customers from database
                customers = db.Customers.ToList();
            }


            TempData["customers"] = customers;
            
            return View();
        }

        public IActionResult Create()
        {
       
            return View();

            
        }
        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            using (var db = new BankContext())
            {
                // adds user to the database
                db.Add(customer);
                // saves the changes
                db.SaveChanges();


            }

            return RedirectToAction("Index");
        }

        public IActionResult Search(string searchTerm)
        {
            {
                List<Customer> customers = new List<Customer>();

                using (var db = new BankContext())
                {
                    // gets all customers from database
                    customers = db.Customers.Where(c => c.FirstName.ToLower().Contains(searchTerm.ToLower())).ToList();
                }

                TempData["customers"] = customers;

                return View("Index");
            }
        }

        [HttpPost]
        public IActionResult Edit(Customer customer)
        {
            
            using (var db = new BankContext())
            {
                var customerTemp = db.Customers.Where(c => c.Id == customer.Id).FirstOrDefault();

                TempData["customerTemp"] = customerTemp;
            }

            return View();
            
        }

        public IActionResult UpdateDetails(Customer customer)
        {
            using (var db = new BankContext())
            {
                var customers = db.Customers.Where(c => c.Id == customer.Id).FirstOrDefault();
                customers.FirstName = customer.FirstName;
                customers.LastName = customer.LastName;
                customers.Address = customer.Address;
                customers.Age = customer.Age;
                customers.Salary = customer.Salary;
                db.SaveChanges();
            }
            
            return RedirectToAction("Index");
        }

        public IActionResult Details (Customer customer)
        {
            using (var db = new BankContext())
            {
                var customerTemp = db.Customers.Where(c => c.Id == customer.Id).FirstOrDefault();

                TempData["customerTemp"] = customerTemp;
            }

            return View();
        }
        
        
        public IActionResult Delete(Customer customer)
        {
            using (var db = new BankContext())
            {
                var userTemp = db.Customers.Where(c => c.Id == customer.Id).FirstOrDefault();

                db.Remove(userTemp);

                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}

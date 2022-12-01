using BankBackend.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Principal;

namespace BankBackend.Controllers
{
    public class AccountsController : Controller
    {
        public IActionResult Index()
        {
            // creates list to hold customer objects
            List<Account> accounts = new List<Account>();
            
            using (var db = new BankContext())
            {
                // gets all customers from database
                accounts = db.Accounts.ToList();
            }


            TempData["accounts"] = accounts;
            
            return View();
        }

        public IActionResult Create()
        {
       
            return View();

            
        }
        [HttpPost]
        public IActionResult Create(Account account)
        {
            
            using (var db = new BankContext())
            {
                // adds user to the database
                db.Add(account);
                // saves the changes
                db.SaveChanges();
                
               
            }


            return RedirectToAction("PassAccount", "Cards", account);
        }

        public IActionResult Search(int searchTerm)
        {
            {
                List<Account> accounts = new List<Account>();

                using (var db = new BankContext())
                {
                    // gets all customers from database
                    accounts = db.Accounts.Where(c => c.AccountNumber == searchTerm).ToList();
                }

                TempData["accounts"] = accounts;

                return View("Index");
            }
        }

        [HttpPost]
        public IActionResult Edit(Account account)
        {
            
            using (var db = new BankContext())
            {
                var accounts = db.Accounts.Where(c => c.Id == account.Id).FirstOrDefault();

                TempData["accounts"] = accounts;
            }

            return View();
            
        }

        public IActionResult UpdateDetails(Account account)
        {
            using (var db = new BankContext())
            {
                var accounts = db.Accounts.Where(a => a.Id == account.Id).FirstOrDefault();
                accounts.AccountNumber = account.AccountNumber;
                accounts.FirstName = account.FirstName;
                accounts.LastName = account.LastName;
                accounts.Address = account.Address;
                accounts.Age = account.Age;
                accounts.Salary = account.Salary;
                db.SaveChanges();
            }
            
            return RedirectToAction("Index");
        }

        public IActionResult Details (Account account)
        {
            using (var db = new BankContext())
            {
                var accounts = db.Accounts.Where(c => c.Id == account.Id).FirstOrDefault();

                TempData["accounts"] = accounts;
            }

            return View();
        }
        
        
        public IActionResult Delete(Account account)
        {
            using (var db = new BankContext())
            {
                var acc = db.Accounts.Where(c => c.Id == account.Id).FirstOrDefault();
                

                db.Remove(acc);
                

                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public IActionResult Overdraft()
        {
            List<Account> accounts = new List<Account>();

            using (var db = new BankContext())
            {
                // gets all customers from database
                accounts = db.Accounts.Where(c => c.Salary >= 30000 || c.Overdraft > 0).ToList();
                var defaultOverdrafts = db.Accounts.Where(c => c.Salary >= 30000 && c.Overdraft == 0);                 
                
                foreach (var account in defaultOverdrafts)
                {
                    account.Overdraft = account.Salary / 10;
                }

                db.SaveChanges();
            }

            TempData["accounts"] = accounts;

            return View();
        }
        
        public IActionResult EditOverdraft(Account account)
        {
            using (var db = new BankContext())
            {
                var accounts = db.Accounts.Where(c => c.Id == account.Id).FirstOrDefault();
                
                TempData["accounts"] = accounts;
            }

            return View();
        }

        public IActionResult UpdateOverdraft(Account account)
        {
            using (var db = new BankContext())
            {
                var accounts = db.Accounts.Where(c => c.Id == account.Id).FirstOrDefault();
                accounts.Overdraft = account.Overdraft;
                db.SaveChanges();
            }

            return RedirectToAction("Overdraft");
        }

        public IActionResult OverdraftSearch(string searchTerm)
        {
            {
                List<Account> accounts = new List<Account>();

                using (var db = new BankContext())
                {
                    // gets all customers from database
                    accounts = db.Accounts.Where(c => c.Salary >= 30000 && c.FirstName.ToLower().Contains(searchTerm.ToLower())).ToList();
                }

                TempData["accounts"] = accounts;

                return View("Overdraft");
            }
        }
    }
}

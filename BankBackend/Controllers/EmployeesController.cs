using BankBackend.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Principal;

namespace BankBackend.Controllers
{
    public class EmployeesController : Controller
    {
        public IActionResult Logon()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Logon(Employee employee)
        {
            List<Employee> employees = new List<Employee>();
            using (var db = new BankContext())
            {
                employees = db.Employees.ToList();
            }

            foreach (Employee e in employees)
            {
                if (employee.Email == e.Email && employee.Password == e.Password)
                {
                    return RedirectToAction("Index", "Accounts");
                }
            }
            return View();
        }

        public IActionResult Index()
        {
            List<Employee> employees = new List<Employee>();

            using (var db = new BankContext())
            {
                employees = db.Employees.ToList();
            }

            TempData["employees"] = employees;

            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Add(Employee employee)
        {
            using (var db = new BankContext())
            {
                // adds user to the database
                db.Add(employee);
                // saves the changes
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public IActionResult Details(Employee employee)
        {
            using (var db = new BankContext())
            {
                employee = db.Employees.Where(e => e.Id == employee.Id).FirstOrDefault();
            }

            TempData["employee"] = employee;

            return View();
        }

        public IActionResult Edit(Employee employee)
        {
            using (var db = new BankContext())
            {
                employee = db.Employees.Where(e => e.Id == employee.Id).FirstOrDefault();
            }

            TempData["employee"] = employee;

            return View();
        }

        public IActionResult UpdateDetails(Employee employee)
        {
            using (var db = new BankContext())
            {
                var employees = db.Employees.Where(e => e.Id == employee.Id).FirstOrDefault();
                employees.Email = employee.Email;
                employees.Password = employee.Password;
                employees.FirstName = employee.FirstName;
                employees.LastName = employee.LastName;
                employees.AccountType = employee.AccountType;
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    

        public IActionResult Delete(Employee employee)
        {

            using (var db = new BankContext())
            {
                var emp = db.Employees.Where(e => e.Id == employee.Id).FirstOrDefault();

                db.Remove(emp);

                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}

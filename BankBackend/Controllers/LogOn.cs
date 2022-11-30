using BankBackend.Models;
using Microsoft.AspNetCore.Mvc;

namespace BankBackend.Controllers
{
    public class LogOn : Controller
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
            
            foreach(Employee e in employees)
            {
                if(employee.Email == e.Email && employee.Password == e.Password)
                {
                    return RedirectToAction("Index", "Customers");
                }
            }
            return View();
        }
    }
}

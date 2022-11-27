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
        public IActionResult Logon(Employee model)
        {
            List<Employee> employees = new();
            var db = new BankContext();
            employees = db.Employees.ToList();
            Employee employee = model;
            foreach(Employee e in employees)
            {
                if(employee.Name == e.Name && employee.Password == e.Password)
                {
                    return RedirectToAction("Index", "Customers");
                }
            }
            return View();
        }
    }
}

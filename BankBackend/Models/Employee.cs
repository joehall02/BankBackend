using System.ComponentModel.DataAnnotations;

namespace BankBackend.Models
{
    public class Employee
    {
        [Key]
        public int id   { get; set; }
        public string Name { get; set; }    
        public string Password  { get; set; }   
        public string AccountType { get; set; } 

    }
}

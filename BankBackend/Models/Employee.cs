using System.ComponentModel.DataAnnotations;

namespace BankBackend.Models
{
    public class Employee
    {
        [Key]
        public int Id   { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }    
        public string Password  { get; set; }   
        public string AccountType { get; set; } 

    }
}

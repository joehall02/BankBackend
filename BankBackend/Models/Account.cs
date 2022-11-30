using System.ComponentModel.DataAnnotations;

namespace BankBackend.Models

{
    public class Account
    {
        [Key]
        public int Id { get; set; }
        public int AccountNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public int Salary { get; set; }
        public int Overdraft { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace BankBackend.Models

{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public int Salary { get; set; }

    }
}

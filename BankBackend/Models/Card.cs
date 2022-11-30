using System.ComponentModel.DataAnnotations;

namespace BankBackend.Models
{
    public class Card
    {
        [Key]
        public int Id { get; set; }

        public int AccountId { get; set; }
        public string CardNumber { get; set; }
        public int CardPin { get; set; }
    }
}

﻿namespace BankBackend.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public int Amount { get; set; }
        public string Type { get; set; }
    }
}

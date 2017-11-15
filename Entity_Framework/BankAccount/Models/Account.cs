using System;

namespace BankAccount.Models
{
    public class Account : BaseEntity
    {
        public int id { get; set; }
        public int deposit { get; set; }
        public int withdraw { get; set; }
        public int balance { get; set; }
        public int Users_id { get; set; }
        public User User { get; set; }
    }
}
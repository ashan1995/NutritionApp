using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessAppData.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public string CreditCardNo { get; set; }
        public string CardHolderName { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string PostalCode { get; set; }
        public string PromotionCode { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}

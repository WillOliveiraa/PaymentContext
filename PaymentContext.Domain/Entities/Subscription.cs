using System;
using System.Collections.Generic;
using System.Linq;

namespace PaymentContext.Domain.Entities
{
    public class Subscription
    {
        //public Subscription(DateTime? expireDate)
        //{
        //    CreateDate = DateTime.Now;
        //    LastUpdateDate = DateTime.Now;
        //    ExpireDate = expireDate;
        //    Active = true;
        //    _payments = new List<Payment>();
        //}

        public DateTime CreateDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public DateTime? ExpireDate { get; set; }
        public bool Active { get; set; }
        public List<Payment> Payments { get; set; }

        public void AddPayment(Payment payment)
        {
            
        }

    }
}
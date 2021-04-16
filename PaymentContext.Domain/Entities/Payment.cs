using System;

namespace PaymentContext.Domain.Entities
{
    public abstract class Payment
    {
        public Payment(DateTime paidDate, DateTime expireDate, decimal total, decimal totalPaid, string payer, Document document, Address address, Email email)
        {
            //Number = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10).ToUpper();
            PaidDate = paidDate;
            ExpireDate = expireDate;
            Total = total;
            TotalPaid = totalPaid;
            Payer = payer;
            //Document = document;
            //Address = address;
            //Email = email;

        }

        public string Number { get; set; }
        public DateTime PaidDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public decimal Total { get; set; }
        public decimal TotalPaid { get; set; }
        public string Address { get; set; }
        public string Payer { get; set; }
        public string Document { get; private set; }
        //public Document Document { get; private set; }
        //public Address Address { get; private set; }
        public string Email { get; private set; }
        //public Email Email { get; private set; }
    }
}
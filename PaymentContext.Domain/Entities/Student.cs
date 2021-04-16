using System.Collections.Generic;

namespace PaymentContext.Domain.Entities
{
    public class Student
    {
        public Student(string name, string document, string email)
        {
            FirstName = name;
            LastName = name;
            Document = document;
            Email = email;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public List<Subscription> Subscriptions { get; set; }
    }
}
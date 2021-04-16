using System.Collections.Generic;
using System.Linq;

namespace PaymentContext.Domain.Entities
{
    public class Student
    {
        public Student(string firstName, string lastName, string document, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Document = document;
            Email = email;
            _subscriptions = new List<Subscription>();
        }

        //public Student(string name, string document, string email)
        //{
        //    FirstName = name;
        //    LastName = name;
        //    Document = document;
        //    Email = email;
        //}
        private IList<Subscription> _subscriptions;
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Document { get; private set; }
        public string Email { get; private set; }
        public string Address { get; private set; }
        public IReadOnlyCollection<Subscription> Subscriptions { get { return _subscriptions.ToArray(); } }

        public void AddSubscription(Subscription subscription)
        {
            // Se já tiver uma assinatura ativa, cancela

            //Cancela todas as outras assinaturas, e coloca está como principal
            foreach (var sub in Subscriptions)
            {
                //sub.Active = false;
                sub.Inactivate();
            }

            //Subscriptions.Add(subscription);
            _subscriptions.Add(subscription);
        }
    }
}
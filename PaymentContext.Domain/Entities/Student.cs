using Flunt.Validations;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Entities;
using System.Collections.Generic;
using System.Linq;

namespace PaymentContext.Domain.Entities
{
    public class Student : Entity
    {
        public Student(Name name, Document document, Email email)
        {
            Name = name;
            Document = document;
            Email = email;
            _subscriptions = new List<Subscription>();

            AddNotifications(name, document, email);
        }

        private IList<Subscription> _subscriptions;
        public Name Name { get; private set; }
        public Document Document { get; private set; }
        public Email Email { get; private set; }
        public Address Address { get; private set; }
        public IReadOnlyCollection<Subscription> Subscriptions { get { return _subscriptions.ToArray(); } }

        public void AddSubscription(Subscription subscription)
        {
            // Se já tiver uma assinatura ativa, cancela
            //Cancela todas as outras assinaturas, e coloca está como principal
            //foreach (var sub in Subscriptions)
            //{
            //    //sub.Active = false;
            //    sub.Inactivate();
            //}
            ////Subscriptions.Add(subscription);
            //_subscriptions.Add(subscription);

            var hasSubscriptionActive = false;
            foreach(var sub in _subscriptions)
            {
                if (sub.Active) hasSubscriptionActive = true;
            }

            //AddNotifications(new Contract()
            //    .Requires()
            //    .IsFalse(hasSubscriptionActive, "Student.Subscriptions", "Você já tem uma assinatura ativa")
            //);

            //ALternativa
            if (hasSubscriptionActive)
                AddNotification("Student.Subscriptions", "Você já tem uma assinatura ativa");
        }
    }
}
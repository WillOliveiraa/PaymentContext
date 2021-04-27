using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;
using System;

namespace PaymentContext.Tests
{
    [TestClass]
    public class StudentTests
    {
        private readonly Name _name;
        private readonly Document _document;
        private readonly Address _address;
        private readonly Email _email;
        private readonly Student _student;
        private readonly Subscription _subscription;

        public StudentTests()
        {
            _name = new Name("Will", "Oliveira");
            _document = new Document("54139739347", EDocumentType.CPF);
            _email = new Email("will@teste.com");
            _address = new Address("Rua 0", "123", "Bairro Top", "New York", "New York", "USA", "12321312");
            _student = new Student(_name, _document, _email);
            _subscription = new Subscription(null);
        }

        //[TestMethod]
        //public void AdicionarAssinatura()
        //{
        //    //var subscription = new Subscription(null);
        //    //var student = new Student("Willian", "Oliveira", "123456789", "will.oliveira93@gmail.com");
        //    ////student.FirstName = "";
        //    ////student.Subscriptions.Add(subscription);
        //    //student.AddSubscription(subscription);
        //}

        [TestMethod]
        public void ShouldReturnErrorWhenHadActiveSubscription()
        {
            var payment = new PayPalPayment("12345678", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, "Will Corp", _document, _address, _email);

            _subscription.AddPayment(payment);
            _student.AddSubscription(_subscription);
            _student.AddSubscription(_subscription);

            Assert.IsTrue(_student.Invalid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenSubscriptionHasNoPayment()
        {
            _student.AddSubscription(_subscription);

            Assert.IsTrue(_student.Invalid);
        }

        [TestMethod]
        public void ShouldReturnSuccessWhenHadNoActiveSubscription()
        {
            var payment = new PayPalPayment("12345678", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, "Will Corp", _document, _address, _email);

            _subscription.AddPayment(payment);
            _student.AddSubscription(_subscription);

            Assert.IsTrue(_student.Valid);
        }
    }
}

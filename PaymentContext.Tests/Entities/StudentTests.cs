using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;

namespace PaymentContext.Tests
{
    [TestClass]
    public class StudentTests
    {
        [TestMethod]
        public void AdicionarAssinatura()
        {
            var subscription = new Subscription(null);
            var student = new Student("Willian", "Oliveira", "123456789", "will.oliveira93@gmail.com");
            //student.FirstName = "";
            //student.Subscriptions.Add(subscription);
            student.AddSubscription(subscription);
        }
    }
}

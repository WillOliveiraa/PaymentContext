using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Command;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Handlers;
using PaymentContext.Tests.Mocks;
using System;

namespace PaymentContext.Tests
{
    [TestClass]
    public class StudentQueriesTests
    {
        // Red, Green, Refactor
        [TestMethod]
        public void ShouldReturnErrorWhenDocumentExists()
        {
            var handler = new SubscriptionHandler(new FakeStudentRepository(), new FakeEmailService());
            var command = new CreateBoletoSubscriptionCommand();

            command.FirstName = "Will";
            command.LastName = "Oliveira";
            command.Document = "99999999999";
            command.Email = "willoliveira@teste.com";

            command.BarCode = "123456789";
            command.BoletoNumber = "12345679";

            command.PaymentNumber = "2312564";
            command.PaidDate = DateTime.Now;
            command.ExpireDate = DateTime.Now.AddMonths(1);
            command.Total = 60;
            command.TotalPaid = 60;
            command.Payer = "Will Corp";
            command.PayerDocument = "132456498789";
            command.PayerDocumentType = EDocumentType.CPF;
            command.EmailPayer = "will@tes.tecom";
            command.Street = "Rua da Moda";
            command.Number = "123";
            command.Neighborhood = "Centro";
            command.City = "Maringá";
            command.State = "PR";
            command.Country = "Brazil";
            command.ZipCode = "213156465";

            handler.Handle(command);
            Assert.AreEqual(false, handler.Valid);
        }
    }
}

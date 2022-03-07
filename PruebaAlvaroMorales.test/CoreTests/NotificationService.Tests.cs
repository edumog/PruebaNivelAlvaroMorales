using Microsoft.VisualStudio.TestTools.UnitTesting;
using PruebaAlvaroMorales.Core.Entities;
using PruebaAlvaroMorales.Core.Interfaces;
using PruebaAlvaroMorales.Core.Interfaces.Repositories;
using PruebaAlvaroMorales.Core.Services;
using PruebaAlvaroMorales.test.Mocks;
using System.Collections.Generic;

namespace PruebaAlvaroMorales.test.CoreTests
{
    [TestClass]
    public class NotificationServiceTests
    {
        [TestMethod]
        public void ChangeBillStatusSuccessful()
        {
            IBillsRepository a = new BillsRepositoryMock(bills);
            IClientsRepository b = new ClientsRepositoryMock(clients);
            INotificationService c = new NotificationService(a, b);
            INotificationService service = GetService();
            c.ChangeBillStatus(clients[0].Id, bills[0].Id);
            //var a = this.bills;
            Assert.IsTrue(true);
        }

        private INotificationService GetService()
        {
            IBillsRepository billsRepository = GetBillsRepository();
            IClientsRepository clientsRepository = GetClientsRepository();
            return new NotificationService(billsRepository, clientsRepository);
        }
        private IBillsRepository GetBillsRepository()
        {
            return new BillsRepositoryMock(bills);
        }
        private IClientsRepository GetClientsRepository()
        {
            return new ClientsRepositoryMock(clients);
        }

        private IList<Bill> bills = new List<Bill>()
        {
            new Bill()
            {
                Id = "76543f2",
                Code = "123",
                Clientid = "idTest1",
                Total = "0",
                Subtotal = "0",
                Iva = "0",
                CreationDate = "01/02/2020 12:00",
                State = "primerrecordatorio",
                Paid = false,
                PaymentDate = ""
            },
        };
        private IList<Client> clients = new List<Client>()
        {
            new Client()
            {
                Id = "idTest1",
                Nit = "1234",
                Name = "Cliente 1",
                City = "Bogota",
                Email = "cliente1@correo.com"
            },
        };

    }
}

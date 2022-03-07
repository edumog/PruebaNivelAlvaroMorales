using Microsoft.VisualStudio.TestTools.UnitTesting;
using PruebaAlvaroMorales.Core.Entities;
using PruebaAlvaroMorales.Core.Interfaces;
using PruebaAlvaroMorales.Core.Interfaces.Repositories;
using PruebaAlvaroMorales.Core.Services;
using PruebaAlvaroMorales.test.Mocks;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebaAlvaroMorales.test.CoreTests
{
    [TestClass]
    public class ClientsServiceTests
    {
        [TestMethod]
        public async Task GetClientsSuccessfulTest()
        {
            IClientsService service = GetService();
            IList<Client> result = await service.Get();
            Assert.AreEqual(clients, result);
        }

        [TestMethod]
        public async Task SearchClientSuccessfulTest()
        {
            IClientsService service = GetService();
            Client searchByNitResult = await service.SearchClient(clients[0].Nit);
            Client searchByEmailResult = await service.SearchClient(clients[0].Email);
            Assert.AreEqual(clients[0], searchByNitResult);
            Assert.AreEqual(clients[0], searchByEmailResult);
        }

        [TestMethod]
        public async Task SearchClientReturnNullTest()
        {
            IClientsService service = GetService();
            Client searchInvalidResult = await service.SearchClient("NotExist");
            Assert.IsNull(searchInvalidResult);
        }


        [TestMethod]
        public async Task GetByNitSuccessfulTest()
        {
            IClientsService service = GetService();
            Client getByNitResult = await service.GetByNit(clients[1].Nit);
            Assert.AreEqual(clients[1], getByNitResult);
        }

        [TestMethod]
        public async Task GetByNitReturnNullTest()
        {
            IClientsService service = GetService();
            Client getByNitResult = await service.GetByNit("NotExist");
            Assert.IsNull (getByNitResult);
        }

        [TestMethod]
        public async Task GetByEmailSuccessfulTest()
        {
            IClientsService service = GetService();
            Client getByEmailResult = await service.GetByEmail(clients[0].Email);
            Assert.AreEqual(clients[0], getByEmailResult);
        }

        [TestMethod]
        public async Task GetByEmailReturnNullTest()
        {
            IClientsService service = GetService();
            Client getByEmailResult = await service.GetByEmail("NotExist");
            Assert.IsNull(getByEmailResult);
        }

        private IClientsService GetService()
        {
            return new ClientsService(GetRepositoryMock());
        }

        private IClientsRepository GetRepositoryMock()
        {
            return new ClientsRepositoryMock(clients);
        }

        private IList<Client> clients = new List<Client>()
        {
            new Client()
            {
                Id = "12343",
                Nit = "1234",
                Name = "Cliente 1",
                City = "Bogota",
                Email = "cliente1@correo.com"
            },
            new Client()
            {
                Id = "12342",
                Nit = "12345",
                Name = "Cliente 2",
                City = "Bogota",
                Email = "cliente2@correo.com"
            },
            new Client()
            {
                Id = "12341",
                Nit = "12346",
                Name = "Cliente 3",
                City = "Bogota",
                Email = "client3@correo.com"
            },
        };
    }
}

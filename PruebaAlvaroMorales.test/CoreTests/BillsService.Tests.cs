using Microsoft.VisualStudio.TestTools.UnitTesting;
using PruebaAlvaroMorales.Core.Entities;
using PruebaAlvaroMorales.Core.Interfaces;
using PruebaAlvaroMorales.Core.Interfaces.Repositories;
using PruebaAlvaroMorales.Core.Services;
using PruebaAlvaroMorales.test.Mocks;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaAlvaroMorales.test.CoreTests
{
    [TestClass]
    public class BillsServiceTests
    {
        [TestMethod]
        public async Task GetBillsByUserSuccessful()
        {
            IBillsService service = GetService();
            IList<Bill> response = await service.GetByClient(bills[0].Clientid);
            Assert.IsNotNull(response);
            IList<Bill> billsByUser = bills.Where(x => x.Clientid == bills[0].Clientid).ToList();
            Assert.AreEqual(billsByUser.Count, response.Count);
        }

        [TestMethod]
        public async Task GetBillsByUserReturnNull()
        {
            IBillsService service = GetService();
            IList<Bill> response = await service.GetByClient("no bills");
            Assert.AreEqual(response.Count, 0);
        }
        
        private IBillsService GetService()
        {
            return new BillsService(GetRepository());
        }
        private IBillsRepository GetRepository()
        {
            return new BillsRepositoryMock(bills);
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
            new Bill()
            {
                Id = "76543c2",
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
            new Bill()
            {
                Id = "7654321",
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
            new Bill()
            {
                Id = "76543217",
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
            new Bill()
            {
                Id = "765432176",
                Code = "123",
                Clientid = "idTest2",
                Total = "0",
                Subtotal = "0",
                Iva = "0",
                CreationDate = "01/02/2020 12:00",
                State = "primerrecordatorio",
                Paid = false,
                PaymentDate = ""
            },
             new Bill()
            {
                Id = "1234",
                Code = "123",
                Clientid = "idTest2",
                Total = "0",
                Subtotal = "0",
                Iva = "0",
                CreationDate = "01/02/2020 12:00",
                State = "primerrecordatorio",
                Paid = false,
                PaymentDate = ""
            },
        };

    }
}

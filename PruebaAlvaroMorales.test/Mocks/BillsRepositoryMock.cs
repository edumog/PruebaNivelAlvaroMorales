using PruebaAlvaroMorales.Core.Entities;
using PruebaAlvaroMorales.Core.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaAlvaroMorales.test.Mocks
{
    public class BillsRepositoryMock : IBillsRepository
    {
        private IList<Bill> bills;

        public BillsRepositoryMock(IList<Bill> bills)
        {
            this.bills = bills;
        }

        public async Task<IList<Bill>> GetByClient(string clientId)
        {
            await Task.Delay(1);
            return bills.Where(x => x.Clientid == clientId).ToList();
        }

        public async Task<Bill> GetById(string id)
        {
            await Task.Delay(1);
            return bills.FirstOrDefault(x => x.Id == id);
        }

        public async Task Update(Bill bill)
        {
            await Task.Delay(1);
            var oldBill = bills.FirstOrDefault(x => x.Id == bill.Id);
            bills.Remove(oldBill);
            bills.Add(bill);
        }
    }
}

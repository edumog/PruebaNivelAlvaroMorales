using PruebaAlvaroMorales.Core.Entities;
using PruebaAlvaroMorales.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaAlvaroMorales.test.Mocks
{
    public class ClientsServiceMock : IClientsService
    {
        private IList<Client> clients;
        public ClientsServiceMock(IList<Client> clients)
        { 
            this.clients = clients;
        }
       
        
        public async Task<IList<Client>> Get()
        {
            await Task.Delay(1);
            return clients;
        }

        public async Task<Client> GetByEmail(string email)
        {
            await Task.Delay(1);
            return clients.FirstOrDefault(x => x.Email == email);
        }

        public async Task<Client> GetByNit(string nit)
        {
            await Task.Delay(1);
            return clients.FirstOrDefault(x => x.Nit == nit);
        }

        public async Task<Client> SearchClient(string searchTerm)
        {
            Client client = await GetByEmail(searchTerm);
            return client != null ? client : await GetByNit(searchTerm);
;        }
    }
}

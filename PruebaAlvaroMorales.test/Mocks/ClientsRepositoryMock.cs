using PruebaAlvaroMorales.Core.Entities;
using PruebaAlvaroMorales.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaAlvaroMorales.test.Mocks
{
    public class ClientsRepositoryMock : IClientsRepository
    {
        private IList<Client> clients;
        
        public ClientsRepositoryMock(IList<Client> clients)
        {
            this.clients = clients;
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

        public async Task<Client> GetClientById(string id)
        {
            await Task.Delay(1);
            return clients.FirstOrDefault(x => x.Id == id);
        }

        public async Task<IList<Client>> GetClients()
        {
            await Task.Delay(1);
            return clients; 
        }
    }
}

using PruebaAlvaroMorales.Core.Entities;
using PruebaAlvaroMorales.Core.Interfaces;
using PruebaAlvaroMorales.Core.Interfaces.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebaAlvaroMorales.Core.Services
{
    public class ClientsService : IClientsService
    {
        IClientsRepository repository;
        public ClientsService(IClientsRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IList<Client>> Get() => await repository.GetClients();

        public async Task<Client> SearchClient(string searchTerm)
        {
            Client client = await GetByEmail(searchTerm);
            return client != null ? client : await GetByNit(searchTerm);
        }

        public async Task<Client> GetByNit(string nit) => await repository.GetByNit(nit);

        public async Task<Client> GetByEmail(string email) => await repository.GetByEmail(email);

    }
}

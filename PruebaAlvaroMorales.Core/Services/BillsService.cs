using PruebaAlvaroMorales.Core.Entities;
using PruebaAlvaroMorales.Core.Interfaces;
using PruebaAlvaroMorales.Core.Interfaces.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebaAlvaroMorales.Core.Services
{
    public class BillsService : IBillsService
    {
        IBillsRepository repository;

        public BillsService(IBillsRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IList<Bill>> GetByClient(string clientId) => await repository.GetByClient(clientId);
    }
}

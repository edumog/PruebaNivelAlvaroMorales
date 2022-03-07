using AutoMapper;
using MongoDB.Driver;
using PruebaAlvaroMorales.Core.Entities;
using PruebaAlvaroMorales.Core.Interfaces.Repositories;
using PruebaAlvaroMorales.Models;
using PruebaAlvaroMorales.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebaAlvaroMorales.Repositories
{
    public class ClientsRepository : IClientsRepository
    {
        private readonly IMongoDbContext dbContext;
        private readonly IMapper mapper;

        public ClientsRepository(IMongoDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<IList<Client>> GetClients()
        {
            IList<ClientDb> clients = await dbContext.Clients.Find(x => true).ToListAsync();
            return mapper.Map<IList<Client>>(clients);
        }

        public async Task<Client> GetClientById(string id)
        {
            ClientDb client = await dbContext.Clients.Find(x => x.Id == id).FirstOrDefaultAsync();
            return mapper.Map<Client>(client);
        }

        public async Task<Client> GetByNit(string nit)
        {
            ClientDb client = await dbContext.Clients.Find(x => x.Nit == nit).FirstOrDefaultAsync();
            return mapper.Map<Client>(client); 
        }

        public async Task<Client> GetByEmail(string email)
        {
            ClientDb client = await dbContext.Clients.Find(x => x.Email == email).FirstOrDefaultAsync();
            return mapper.Map<Client>(client); 
        }

    }
}

using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace PruebaAlvaroMorales.Models
{
    public class MongoDbContext : IMongoDbContext
    {
        public readonly IMongoDatabase mongoDb;

        public MongoDbContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetConnectionString("mongo-connection"));
            mongoDb = client.GetDatabase("PruebaNivelDb");
        }

        public IMongoCollection<ClientDb> Clients => mongoDb.GetCollection<ClientDb>("Clients");
        public IMongoCollection<BillDb> Bills => mongoDb.GetCollection<BillDb>("Bills");
    }
}

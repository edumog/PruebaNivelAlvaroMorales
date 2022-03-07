using MongoDB.Driver;

namespace PruebaAlvaroMorales.Models
{
    public interface IMongoDbContext
    {
        IMongoCollection<ClientDb> Clients { get; }
        IMongoCollection<BillDb> Bills { get; }
    }
}

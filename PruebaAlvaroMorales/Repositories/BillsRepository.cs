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
    public class BillsRepository : IBillsRepository
    {
        private readonly IMongoDbContext dbContext;
        private readonly IMapper mapper;

        public BillsRepository(IMongoDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<Bill> GetById(string id)
        {
            BillDb bill = await dbContext.Bills.Find(x => x.Id == id).FirstOrDefaultAsync();
            return mapper.Map<Bill>(bill);
        }

        public async Task<IList<Bill>> GetByClient(string clientId)
        {
            IList<BillDb> billsDb = await dbContext.Bills.Find(x => x.Clientid == clientId).ToListAsync();
            return mapper.Map<IList<Bill>>(billsDb);
        }

        public async Task Update(Bill bill)
        {
            BillDb billDb = mapper.Map<BillDb>(bill);
            await dbContext.Bills.ReplaceOneAsync(filter: x => x.Id == billDb.Id, replacement: billDb); 
        }
    }
}

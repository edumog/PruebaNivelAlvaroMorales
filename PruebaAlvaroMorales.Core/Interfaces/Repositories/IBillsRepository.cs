using PruebaAlvaroMorales.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaAlvaroMorales.Core.Interfaces.Repositories
{
    public interface IBillsRepository
    {
        Task<Bill> GetById(string id);
        Task<IList<Bill>> GetByClient(string clientId);
        Task Update(Bill bill);
    }
}

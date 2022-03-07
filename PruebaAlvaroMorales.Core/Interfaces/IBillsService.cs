using PruebaAlvaroMorales.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebaAlvaroMorales.Core.Interfaces
{
    public interface IBillsService
    {
        Task<IList<Bill>> GetByClient(string clientId);
    }
}

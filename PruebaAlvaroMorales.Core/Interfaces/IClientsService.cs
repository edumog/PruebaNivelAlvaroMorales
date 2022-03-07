using PruebaAlvaroMorales.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaAlvaroMorales.Core.Interfaces
{
    public interface IClientsService
    {
        Task<IList<Client>> Get();
        Task<Client> SearchClient(string searchTerm);
        Task<Client> GetByNit(string nit);
        Task<Client> GetByEmail(string email);
    }
}

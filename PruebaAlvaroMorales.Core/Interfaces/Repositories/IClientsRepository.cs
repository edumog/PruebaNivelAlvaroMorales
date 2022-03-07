using PruebaAlvaroMorales.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaAlvaroMorales.Core.Interfaces.Repositories
{
    public interface IClientsRepository
    {
        Task<IList<Client>> GetClients();
        Task<Client> GetClientById(string id);
        Task<Client> GetByNit(string nit);
        Task<Client> GetByEmail(string email);
    }
}

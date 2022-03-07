using PruebaAlvaroMorales.Core.Entities;
using System.Threading.Tasks;

namespace PruebaAlvaroMorales.Core.Interfaces
{
    public interface INotificationService
    {
        Task ChangeBillStatus(string clientId, string billId);
    }
}

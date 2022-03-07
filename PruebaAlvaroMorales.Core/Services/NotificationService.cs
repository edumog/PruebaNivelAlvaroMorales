using PruebaAlvaroMorales.Core.Entities;
using PruebaAlvaroMorales.Core.Interfaces;
using PruebaAlvaroMorales.Core.Interfaces.Repositories;
using PruebaAlvaroMorales.Core.Utilities;
using System;
using System.Threading.Tasks;

namespace PruebaAlvaroMorales.Core.Services
{
    public class NotificationService : INotificationService
    {
        IClientsRepository clientsRepository;
        IBillsRepository billsRepository;
        private const string firstReminder = "primerrecordatorio";
        private const string secondReminder = "segundorecordatorio";
        private const string disabled = "desactivado";

        public NotificationService(IBillsRepository billsRepository, IClientsRepository clientsRepository)
        {
            this.billsRepository = billsRepository;
            this.clientsRepository = clientsRepository;
        }

        public async Task ChangeBillStatus(string clientId, string billId)
        {
            Client client = await clientsRepository.GetClientById(clientId);
            Bill bill = await billsRepository.GetById(billId);
            Validate(client, bill);
            if(!bill.Paid) await ChangeBillStatus(bill, client);
        }
        private void Validate(Client client, Bill bill)
        {
            if (client == null || bill == null) throw new NullReferenceException();
        }
        private async Task ChangeBillStatus(Bill bill, Client client)
        {
            if (bill.State == secondReminder)
            {
                bill.State = disabled;
                await SendNotificationMail(client, secondReminder, bill);
            }
            if (bill.State == firstReminder)
            {
                bill.State = secondReminder;
                await SendNotificationMail(client, firstReminder, bill);
            }
            await UpdateState(bill);
        }
        private async Task SendNotificationMail(Client client, string previousState, Bill bill)
        {
            await EmailService.SendEmailBillStatusChangeNotification(client, previousState, bill);
        }
        private async Task UpdateState(Bill bill)
        {
           await billsRepository.Update(bill);
        }

    }
}

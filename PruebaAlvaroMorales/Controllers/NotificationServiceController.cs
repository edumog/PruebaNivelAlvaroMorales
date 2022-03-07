using Microsoft.AspNetCore.Mvc;
using PruebaAlvaroMorales.Core.Interfaces;
using PruebaAlvaroMorales.Dtos;
using System.Threading.Tasks;

namespace PruebaAlvaroMorales.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationServiceController : ControllerBase
    {
        private readonly INotificationService notificationService;

        public NotificationServiceController(INotificationService notificationService)
        {
            this.notificationService = notificationService;
        }

        [HttpPost, Route("BillStatusChange")]
        public async Task<IActionResult> NotifyBillStatusChange([FromBody] NotificationParametersDto parameters)
        {
            try
            {
                await notificationService.ChangeBillStatus(parameters.ClientId, parameters.BillId);
                return new NoContentResult();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}

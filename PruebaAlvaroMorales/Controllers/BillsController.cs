using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaAlvaroMorales.Core.Interfaces;
using System.Threading.Tasks;

namespace PruebaAlvaroMorales.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillsController : ControllerBase
    {
        private IBillsService billsService;

        public BillsController(IBillsService billsService)
        {
            this.billsService = billsService;
        }

        [HttpGet, Route("GetByClient/{clientId}")]
        public async Task<IActionResult> GetByClient(string clientId)
        {
            try
            {
                var result = await billsService.GetByClient(clientId);
                return Ok(result);
            } catch
            {
                return BadRequest();
            }
        }
    }
}

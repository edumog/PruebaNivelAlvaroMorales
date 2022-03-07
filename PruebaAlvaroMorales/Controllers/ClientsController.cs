using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaAlvaroMorales.Core.Interfaces;
using System.Threading.Tasks;

namespace PruebaAlvaroMorales.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private IClientsService clientsService;

        public ClientsController(IClientsService clientsService)
        {
            this.clientsService = clientsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetClients()
        {
            try
            {
                return Ok(await clientsService.Get());
            }catch
            {
                return BadRequest();
            }
        }

        [HttpGet, Route("Search/{searchTerm}")]
        public async Task<IActionResult> SearchClient(string searchTerm)
        {
            try
            {
                return Ok(await clientsService.SearchClient(searchTerm));
            }catch {
                return BadRequest();
            }
        }
    }
}

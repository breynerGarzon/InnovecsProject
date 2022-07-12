using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace InnovecsProject.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DealThreeController : ControllerBase
    {
        public DealThreeController()
        {

        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> BestDeal()
        {
            return Ok();
        }
    }
}
using System.Threading.Tasks;
using InnovecsProject.Business.Interface;
using Microsoft.AspNetCore.Mvc;

namespace InnovecsProject.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DealThreeController : ControllerBase
    {
        private readonly IDealServicesThree dealServicesThree;

        public DealThreeController(IDealServicesThree dealServicesThree)
        {
            this.dealServicesThree = dealServicesThree;
        }

        [HttpGet]
        [Route("ApiThree")]
        public async Task<IActionResult> BestDeal(string filterRequest)
        {
            return Ok(await this.dealServicesThree.GettDeal(filterRequest));
        }
    }
}
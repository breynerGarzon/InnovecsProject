using System.Threading.Tasks;
using InnovecsProject.Business.Interface;
using InnovecsProject.Model.Dto.BestDeal;
using Microsoft.AspNetCore.Mvc;

namespace InnovecsProject.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BestDealOneController : ControllerBase
    {
        private readonly IBestDealServices bestServicesDeal;

        public BestDealOneController(IBestDealServices bestServicesDeal)
        {
            this.bestServicesDeal = bestServicesDeal;
        }

        [HttpPost]
        [Route("best-deal")]
        public async Task<IActionResult> BestDeal([FromBody] FilterBestDealDto filterRequest)
        {
            return Ok(await this.bestServicesDeal.GetBestDeal(filterRequest));
        }
    }
}
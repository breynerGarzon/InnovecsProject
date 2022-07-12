using System.Threading.Tasks;
using InnovecsProject.Business.Interface;
using InnovecsProject.Model.Dto.ApiTwo;
using Microsoft.AspNetCore.Mvc;

namespace InnovecsProject.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DealTwoController : ControllerBase
    {
        private readonly IDealServicesTwo servicesDeal;

        public DealTwoController(IDealServicesTwo servicesDeal)
        {
            this.servicesDeal = servicesDeal;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> BestDeal([FromQuery] FilterApiTwoDto filterRequest)
        {
            return Ok(await this.servicesDeal.GettDeal(filterRequest));
        }
    }
}
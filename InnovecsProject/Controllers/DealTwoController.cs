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

        [HttpPost]
        [Route("ApiTwo")]
        public async Task<IActionResult> BestDeal([FromBody] FilterApiTwoDto filterRequest)
        {
            return Ok(await this.servicesDeal.GettDeal(filterRequest));
        }
    }
}
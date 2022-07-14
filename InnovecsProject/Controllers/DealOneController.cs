using System.Threading.Tasks;
using InnovecsProject.Business.Interface;
using InnovecsProject.Model.Dto.ApiOne;
using Microsoft.AspNetCore.Mvc;

namespace InnovecsProject.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DealOneController : ControllerBase
    {
        private readonly IDealServicesOne servicesDeal;

        public DealOneController(IDealServicesOne servicesDeal)
        {
            this.servicesDeal = servicesDeal;

        }

        [HttpPost]
        [Route("ApiOne")]
        public async Task<IActionResult> BestDeal([FromBody] FilterApiOneDto filterRequest)
        {
            return Ok(await this.servicesDeal.CalculatePrice(filterRequest));
        }
    }
}
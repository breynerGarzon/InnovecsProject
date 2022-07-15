using System.Collections.Generic;
using System.Threading.Tasks;
using InnovecsProject.Business.Interface;
using InnovecsProject.Model.Dto.ApiThree;
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

        [HttpPost]
        [Route("ApiThree")]
        public async Task<IActionResult> BestDeal(FilterApiThreeDto filterRequest)
        {
            return Ok(await this.dealServicesThree.GettDeal(filterRequest));
        }

        [HttpGet]
        [Route("ApiThreeDataExampleXMl")]
        public IActionResult GetDataFormatExample()
        {
            return Ok(new FilterApiThreeDto()
            {
                Destination = "My House example",
                Source = "From supermarket",
                Packages = new List<Package>() { new Package() { High = 1, Length = 1, Width = 1 }, new Package() { High = 2, Length = 2, Width = 2 } }
            });
        }
    }
}
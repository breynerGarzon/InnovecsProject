using System.Collections.Generic;
using InnovecsProject.Model.Dto.BestDeal;

namespace InnovecsProject.Model.Dto.ApiOne
{
    public class FilterApiOneDto
    {
        public string ContactAdrress { get; set; }
        public string WarehouseAddress { get; set; }
        public IEnumerable<DimensionDto> PackageDimensions { get; set; }

        public FilterApiOneDto()
        {

        }

        public FilterApiOneDto(FilterBestDealDto filterRequest)
        {

        }
    }
}
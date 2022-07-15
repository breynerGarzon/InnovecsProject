using System.Collections.Generic;
using System.Linq;
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
            this.WarehouseAddress = filterRequest.Destination;
            this.ContactAdrress = filterRequest.Source;
            this.PackageDimensions = filterRequest.Boxs.Select(item => new DimensionDto() { High = item.High, Length = item.Length, Width = item.Width });
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using InnovecsProject.Model.Dto.BestDeal;

namespace InnovecsProject.Model.Dto.ApiTwo
{
    public class FilterApiTwoDto
    {
        public string Consignee { get; set; }
        public string Consignor { get; set; }
        public IEnumerable<CartonDto> Cartons { get; set; }

        public FilterApiTwoDto()
        {

        }

        public FilterApiTwoDto(FilterBestDealDto filterRequest)
        {
            this.Consignee = filterRequest.Destination;
            this.Consignor = filterRequest.Source;
            this.Cartons = filterRequest.Boxs.Select(item => new CartonDto() { High = item.High, Length = item.Length, Width = item.Width });
        }
    }
}
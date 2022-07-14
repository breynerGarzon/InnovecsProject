using System.Collections.Generic;
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

        }
    }
}
using System.Collections.Generic;

namespace InnovecsProject.Model.Dto.BestDeal
{
    public class FilterBestDealDto
    {
        public string Source { get; set; }
        public string Destination { get; set; }
        public IEnumerable<BoxDto> Boxs { get; set; }
    }
}
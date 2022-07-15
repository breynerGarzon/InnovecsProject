using InnovecsProject.Model.Dto.BestDeal;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace InnovecsProject.Model.Dto.ApiThree
{
    public class FilterApiThreeDto
    {
        [XmlAttribute("source")]
        public string Source { get; set; }
        [XmlAttribute("destination")]
        public string Destination { get; set; }
        [XmlAttribute("Packages")]
        public IEnumerable<Package> Packages { get; set; }

        public FilterApiThreeDto()
        {
        }

        public FilterApiThreeDto(FilterBestDealDto filterRequest)
        {
            this.Destination = filterRequest.Destination;
            this.Source = filterRequest.Source;
            this.Packages = filterRequest.Boxs.Select(item => new Package() { High = item.High, Length = item.Length, Width = item.Width });
        }
    }
}
using System.Collections.Generic;
using System.Xml.Serialization;

namespace InnovecsProject.Model.Dto.ApiThree
{
    public class FilterApiThreeDto
    {
        [XmlAttribute("Source")]
        public string Source { get; set; }
        [XmlAttribute("Destination")]
        public string Destination { get; set; }
        [XmlAttribute("Packages")]
        public IEnumerable<Package> Packages { get; set; }
    }
}
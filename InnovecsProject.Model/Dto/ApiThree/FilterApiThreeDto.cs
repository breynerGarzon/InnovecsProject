using System.Collections.Generic;
using System.Xml.Serialization;

namespace InnovecsProject.Model.Dto.ApiThree
{
    public class FilterApiThreeDto
    {
        [XmlAttribute("source")]
        public string Source { get; set; }
        [XmlAttribute("destination")]
        public string Destination { get; set; }
        //[XmlAttribute("Packages")]
        //public IEnumerable<Package> Packages { get; set; }
    }
}
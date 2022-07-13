using System.Xml.Serialization;

namespace InnovecsProject.Model.Dto.ApiThree
{
    public class Package
    {
        [XmlAttribute("High")]
        public int High { get; set; }
        [XmlAttribute("Width")]
        public int Width { get; set; }
        [XmlAttribute("Length")]
        public int Length { get; set; }
        public int Volumen { get { return High * Width * Length; } }
    }
}
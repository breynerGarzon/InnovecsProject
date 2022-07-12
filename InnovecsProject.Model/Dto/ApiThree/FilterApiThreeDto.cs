using System.Collections.Generic;

namespace InnovecsProject.Model.Dto.ApiThree
{
    public class FilterApiThreeDto
    {
        public string Source { get; set; }
        public string Destination { get; set; }
        public IEnumerable<Package> Packages { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using InnovecsProject.Business.BusinessLogic.ApiThree.Interface;
using InnovecsProject.Business.Util.Validation;
using InnovecsProject.Model.Dto.ApiOne;
using InnovecsProject.Model.Dto.ApiThree;

namespace InnovecsProject.Business.BusinessLogic.ApiThree.Implements
{
    public class ApiThreeBusinessLogic : IApiThreeBusinessLogic
    {
        public int CalculateDistanceInKm(FilterApiThreeDto filterRequest)
        {
            Random distance = new Random();
            return distance.Next(1, 20);
        }

        public int CalculateTotalPrice(FilterApiOneDto filterRequest, IEnumerable<DimensionPriceDto> prices)
        {
            int total = 0;
            filterRequest.PackageDimensions.ToList().ForEach(package =>
            {
                var price = prices.FirstOrDefault(price => price.Volumen == package.Volumen);
                if (Validation.IsNotNull(price))
                    total += price.Price;
            });
            return total;
        }

        public int CalculateTotalPrice(FilterApiThreeDto filterRequest, IEnumerable<DimensionPriceDto> prices)
        {
            throw new NotImplementedException();
        }

        public FilterApiThreeDto DeserializeXml(string xmlStruct)
        {
            return new FilterApiThreeDto();
        }
    }
}
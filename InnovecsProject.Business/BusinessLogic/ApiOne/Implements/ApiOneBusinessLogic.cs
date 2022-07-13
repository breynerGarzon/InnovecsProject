using System;
using System.Collections.Generic;
using System.Linq;
using InnovecsProject.Business.BusinessLogic.ApiOne.Interface;
using InnovecsProject.Business.Util.Validation;
using InnovecsProject.Model.Dto.ApiOne;

namespace InnovecsProject.Business.BusinessLogic.ApiOne.Implements
{
    public class ApiOneBusinessLogic : IApiOneBusinessLogic
    {
        public int CalculateDistanceInKm(FilterApiOneDto filterRequest)
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
    }
}
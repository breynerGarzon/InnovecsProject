using System;
using System.Collections.Generic;
using System.Linq;
using InnovecsProject.Business.BusinessLogic.ApiTwo.Interface;
using InnovecsProject.Business.Util.Validation;
using InnovecsProject.Model.Dto.ApiOne;
using InnovecsProject.Model.Dto.ApiTwo;

namespace InnovecsProject.Business.BusinessLogic.ApiTwo.Implements
{
    public class ApiTwoBusinessLogic : IApiTwoBusinessLogic
    {
        public int CalculateDistanceInKm(FilterApiTwoDto filterRequest)
        {
            Random distance = new Random();
            return distance.Next(1, 20);
        }

        public int CalculateTotalPrice(FilterApiTwoDto filterRequest, IEnumerable<DimensionPriceDto> prices)
        {
            int total = 0;
            filterRequest.Cartons.ToList().ForEach(package =>
            {
                var price = prices.FirstOrDefault(price => price.Volumen == package.Volumen);
                if (Validation.IsNotNull(price))
                    total += price.Price;
            });
            return total;
        }
    }
}
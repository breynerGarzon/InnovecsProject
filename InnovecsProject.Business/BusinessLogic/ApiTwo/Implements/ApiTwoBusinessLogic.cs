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
            int totalVolumen = filterRequest.Cartons.Sum(package => package.Volumen);
            DimensionPriceDto lastVolumen;

            prices.ToList().ForEach(price =>
            {
                bool isSameVolumnen = price.Volumen == totalVolumen;
                if (isSameVolumnen)
                    total += price.Price;
            });

            if (!Validation.IsNotZero(total) && Validation.IsNotZero(totalVolumen))
            {
                lastVolumen = prices.OrderByDescending(price => price.Volumen).FirstOrDefault(price => price.Volumen <= totalVolumen);
                decimal differents = (decimal)(1 - ((decimal)lastVolumen.Volumen / (decimal)totalVolumen));
                total = differents < 0.1m ? lastVolumen.Price : 0; 
            }

            return total;
        }
    }
}
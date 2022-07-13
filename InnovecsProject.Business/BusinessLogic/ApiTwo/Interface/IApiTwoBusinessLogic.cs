using System.Collections.Generic;
using InnovecsProject.Model.Dto.ApiOne;
using InnovecsProject.Model.Dto.ApiTwo;

namespace InnovecsProject.Business.BusinessLogic.ApiTwo.Interface
{
    public interface IApiTwoBusinessLogic
    {
        int CalculateDistanceInKm(FilterApiTwoDto filterRequest);
        int CalculateTotalPrice(FilterApiTwoDto filterRequest, IEnumerable<DimensionPriceDto> prices);
    }
}
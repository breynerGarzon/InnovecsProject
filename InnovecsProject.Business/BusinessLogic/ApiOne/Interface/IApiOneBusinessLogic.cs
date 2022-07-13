using System.Collections.Generic;
using InnovecsProject.Model.Dto.ApiOne;

namespace InnovecsProject.Business.BusinessLogic.ApiOne.Interface
{
    public interface IApiOneBusinessLogic
    {
        int CalculateDistanceInKm(FilterApiOneDto filterRequest);
        int CalculateTotalPrice(FilterApiOneDto filterRequest, IEnumerable<DimensionPriceDto> prices);
    }
}
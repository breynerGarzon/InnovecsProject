using System.Collections.Generic;
using InnovecsProject.Model.Dto.ApiOne;
using InnovecsProject.Model.Dto.ApiThree;

namespace InnovecsProject.Business.BusinessLogic.ApiThree.Interface
{
    public interface IApiThreeBusinessLogic
    {
        FilterApiThreeDto DeserializeXml(string xmlStruct);
        int CalculateDistanceInKm(FilterApiThreeDto filterRequest);
        int CalculateTotalPrice(FilterApiThreeDto filterRequest, IEnumerable<DimensionPriceDto> prices);
    }
}
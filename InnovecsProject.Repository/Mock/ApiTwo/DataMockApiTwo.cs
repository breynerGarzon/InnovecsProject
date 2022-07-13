using System.Collections.Generic;
using InnovecsProject.Model.Dto.ApiOne;

namespace InnovecsProject.Repository.Mock.ApiTwo
{
    public class DataMockApiTwo
    {
        public static IEnumerable<DimensionPriceDto> GetAllPrices()
        {
            List<DimensionPriceDto> prices = new List<DimensionPriceDto>();
            for (int iteration = 1; iteration < 100; iteration++)
            {
                prices.Add(new DimensionPriceDto() { High = iteration, Width = iteration, Length = iteration, Price = iteration * 5, Distance = iteration });
            }
            return prices;
        }
    }
}
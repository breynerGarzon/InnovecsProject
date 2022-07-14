using System.Collections.Generic;
using InnovecsProject.Model.Dto.ApiOne;

namespace InnovecsProject.Repository.Mock.ApiOne
{
    public class DataMockApiOne
    {
        public static IEnumerable<DimensionPriceDto> GetAllPrices()
        {
            List<DimensionPriceDto> prices = new List<DimensionPriceDto>();
            for (int iteration = 1; iteration < 100; iteration++)
            {
                var item = new DimensionPriceDto() { High = iteration, Width = iteration, Length = iteration, Distance = iteration };
                item.Price = item.Volumen * 5;
                prices.Add(item);
            }
            return prices;
        }
    }
}
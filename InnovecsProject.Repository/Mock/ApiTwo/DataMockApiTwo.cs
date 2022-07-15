using System.Collections.Generic;
using InnovecsProject.Model.Dto.ApiOne;

namespace InnovecsProject.Repository.Mock.ApiTwo
{
    public class DataMockApiTwo
    {
        public static IEnumerable<DimensionPriceDto> GetAllPrices()
        {
            List<DimensionPriceDto> prices = new List<DimensionPriceDto>();
            for (int iteration = 1; iteration < 80; iteration++)
            {
                var item = new DimensionPriceDto() { High = iteration, Width = iteration, Length = iteration, Distance = iteration };
                item.Price = item.Volumen * 6;
                prices.Add(item);
            }
            return prices;
        }
    }
}
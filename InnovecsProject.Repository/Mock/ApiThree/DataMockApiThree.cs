using System.Collections.Generic;
using InnovecsProject.Model.Dto.ApiOne;

namespace InnovecsProject.Repository.Mock.ApiThree
{
    public class DataMockApiThree
    {
        public static IEnumerable<DimensionPriceDto> GetAllPrices()
        {
            List<DimensionPriceDto> prices = new List<DimensionPriceDto>();
            for (int iteration = 1; iteration < 100; iteration++)
            {
                var item = new DimensionPriceDto() { High = iteration, Width = iteration, Length = iteration, Distance = iteration };
                item.Price = item.Volumen * 7;
                prices.Add(item);
            }
            return prices;
        }
    }
}
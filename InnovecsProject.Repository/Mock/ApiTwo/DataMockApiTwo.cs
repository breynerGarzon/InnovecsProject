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

            // {

            //     new DimensionPriceDto() { High = 10, Width = 15, Length = 15, Price = 16, Distance = 10 },
            //     new DimensionPriceDto() { High = 10, Width = 20, Length = 20, Price = 17, Distance = 10 },
            //     new DimensionPriceDto() { High = 15, Width = 10, Length = 10, Price = 18, Distance = 15 },
            //     new DimensionPriceDto() { High = 15, Width = 15, Length = 10, Price = 19, Distance = 15 },
            //     new DimensionPriceDto() { High = 15, Width = 20, Length = 10, Price = 20, Distance = 15 }
            // };
        }
    }
}
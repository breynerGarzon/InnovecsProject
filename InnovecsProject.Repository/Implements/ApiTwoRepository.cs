using System.Collections.Generic;
using System.Threading.Tasks;
using InnovecsProject.Model.Dto.ApiOne;
using InnovecsProject.Repository.Interface;
using InnovecsProject.Repository.Mock.ApiTwo;

namespace InnovecsProject.Repository.Implements
{
    public class ApiTwoRepository : IApiTwoRepository
    {
        public async Task<IEnumerable<DimensionPriceDto>> GetAllPrices()
        {
            return DataMockApiTwo.GetAllPrices();
        }
    }
}
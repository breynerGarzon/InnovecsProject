using System.Collections.Generic;
using System.Threading.Tasks;
using InnovecsProject.Model.Dto.ApiOne;
using InnovecsProject.Repository.Interface;
using InnovecsProject.Repository.Mock.ApiOne;

namespace InnovecsProject.Repository.Implements
{
    public class ApiOneRepository : IApiOneRepository
    {
        public async Task<IEnumerable<DimensionPriceDto>> GetAllPrices()
        {
            return DataMockApiOne.GetAllPrices();
        }
    }
}
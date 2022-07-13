using System.Collections.Generic;
using System.Threading.Tasks;
using InnovecsProject.Model.Dto.ApiOne;
using InnovecsProject.Repository.Interface;
using InnovecsProject.Repository.Mock.ApiThree;

namespace InnovecsProject.Repository.Implements
{
    public class ApiThreeRepository : IApiThreeRepository
    {
        public async Task<IEnumerable<DimensionPriceDto>> GetAllPrices()
        {
            return DataMockApiThree.GetAllPrices();
        }
    }
}
using System.Collections.Generic;
using System.Threading.Tasks;
using InnovecsProject.Model.Dto.ApiOne;

namespace InnovecsProject.Repository.Interface
{
    public interface IApiThreeRepository
    {
        Task<IEnumerable<DimensionPriceDto>> GetAllPrices();
    }
}
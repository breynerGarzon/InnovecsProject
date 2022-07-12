using System.Threading.Tasks;
using InnovecsProject.Model.Dto.BestDeal;
using InnovecsProject.Model.System;

namespace InnovecsProject.Business.Interface
{
    public interface IBeastDealServices
    {
        Task<ResponseDto<string>> GetBestDeal(FilterBestDealDto filterRequest);
    }
}
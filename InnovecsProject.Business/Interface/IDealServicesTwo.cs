using System.Threading.Tasks;
using InnovecsProject.Model.Dto.ApiTwo;
using InnovecsProject.Model.System;

namespace InnovecsProject.Business.Interface
{
    public interface IDealServicesTwo
    {
        Task<ResponseDto<object>> GettDeal(FilterApiTwoDto filterRequest);
    }
}
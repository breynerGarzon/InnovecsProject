using System.Threading.Tasks;
using InnovecsProject.Model.Dto.ApiOne;
using InnovecsProject.Model.System;

namespace InnovecsProject.Business.Interface
{
    public interface IDealServicesOne
    {
        Task<ResponseDto<OutApiOneDto>> CalculatePrice(FilterApiOneDto filterRequest);
    }
}
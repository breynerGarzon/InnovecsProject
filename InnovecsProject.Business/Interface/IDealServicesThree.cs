using System.Threading.Tasks;
using InnovecsProject.Model.Dto.ApiThree;
using InnovecsProject.Model.Dto.ApiTwo;
using InnovecsProject.Model.System;

namespace InnovecsProject.Business.Interface
{
    public interface IDealServicesThree
    {
        Task<ResponseDto<OutApiThreeDto>> GettDeal(string filterRequest);
    }
}
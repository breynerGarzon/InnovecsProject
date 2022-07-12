using System.Threading.Tasks;
using InnovecsProject.Business.Interface;
using InnovecsProject.Model.Dto.ApiTwo;
using InnovecsProject.Model.System;

namespace InnovecsProject.Business.Implements
{
    public class DealServicesThree : IDealServicesThree
    {
        public async Task<ResponseDto<OutApiThreeDto>> GettDeal(string filterRequest)
        {
            throw new System.NotImplementedException();
        }
    }
}
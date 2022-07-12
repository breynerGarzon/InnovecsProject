using System.Threading.Tasks;
using InnovecsProject.Business.Interface;
using InnovecsProject.Model.Dto.ApiTwo;
using InnovecsProject.Model.System;

namespace InnovecsProject.Business.Implements
{
    public class DealServicesTwo : IDealServicesTwo
    {
        
        public DealServicesTwo()
        {
        }

        public async Task<ResponseDto<OutApiTwoDto>> GettDeal(FilterApiTwoDto filterRequest)
        {
            throw new System.NotImplementedException();
        }
    }
}
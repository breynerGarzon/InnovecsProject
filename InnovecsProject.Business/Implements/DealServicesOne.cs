using System.Threading.Tasks;
using InnovecsProject.Business.Interface;
using InnovecsProject.Model.Dto.ApiOne;
using InnovecsProject.Model.System;

namespace InnovecsProject.Business.Implements
{
    public class DealServicesOne : IDealServicesOne
    {
        public DealServicesOne()
        {
        }

        public async Task<ResponseDto<OutApiOneDto>> GettDeal(FilterApiOneDto filterRequest)
        {
            throw new System.NotImplementedException();
        }
    }
}
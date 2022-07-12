using System.Threading.Tasks;
using InnovecsProject.Business.Interface;
using InnovecsProject.Model.Dto.ApiTwo;
using InnovecsProject.Model.System;

namespace InnovecsProject.Business.Implements
{
    public class ServicesApiTwo : IDealServicesTwo
    {
        public async Task<ResponseDto<object>> GettDeal(FilterApiTwoDto filterRequest)
        {
            throw new System.NotImplementedException();
        }
    }
}
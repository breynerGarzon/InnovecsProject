using System.Threading.Tasks;
using InnovecsProject.Business.Interface;
using InnovecsProject.Model.Dto.ApiOne;
using InnovecsProject.Model.System;

namespace InnovecsProject.Business.Implements
{
    public class ServicesApiOne : IDealServicesOne
    {
        public async Task<ResponseDto<object>> GettDeal(FilterApiOneDto filterRequest)
        {
            throw new System.NotImplementedException();
        }
    }
}
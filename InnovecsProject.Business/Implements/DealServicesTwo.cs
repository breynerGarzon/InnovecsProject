using System.Collections.Generic;
using System.Threading.Tasks;
using InnovecsProject.Business.Interface;
using InnovecsProject.Model.Dto.ApiOne;
using InnovecsProject.Model.Dto.ApiTwo;
using InnovecsProject.Model.System;
using InnovecsProject.Repository.Interface;

namespace InnovecsProject.Business.Implements
{
    public class DealServicesTwo : IDealServicesTwo
    {
        private readonly IApiTwoRepository repositoryServices;

        public DealServicesTwo(IApiTwoRepository repositoryServices)
        {
            this.repositoryServices = repositoryServices;
        }

        public async Task<ResponseDto<OutApiTwoDto>> GettDeal(FilterApiTwoDto filterRequest)
        {
            IEnumerable<DimensionPriceDto> prices = await this.repositoryServices.GetAllPrices();

            throw new System.NotImplementedException();
        }
    }
}
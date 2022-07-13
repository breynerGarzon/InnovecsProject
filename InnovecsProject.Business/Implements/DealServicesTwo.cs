using System.Collections.Generic;
using System.Threading.Tasks;
using InnovecsProject.Business.BusinessLogic.ApiTwo.Interface;
using InnovecsProject.Business.Interface;
using InnovecsProject.Business.Util;
using InnovecsProject.Business.Util.Messages;
using InnovecsProject.Business.Util.Validation;
using InnovecsProject.Model.Dto.ApiOne;
using InnovecsProject.Model.Dto.ApiTwo;
using InnovecsProject.Model.System;
using InnovecsProject.Repository.Interface;

namespace InnovecsProject.Business.Implements
{
    public class DealServicesTwo : IDealServicesTwo
    {
        private readonly IApiTwoRepository repositoryServices;
        private readonly IApiTwoBusinessLogic businessLogic;

        public DealServicesTwo(IApiTwoRepository repositoryServices, IApiTwoBusinessLogic businessLogic)
        {
            this.repositoryServices = repositoryServices;
            this.businessLogic = businessLogic;
        }

        public async Task<ResponseDto<OutApiTwoDto>> GettDeal(FilterApiTwoDto filterRequest)
        {
            IEnumerable<DimensionPriceDto> prices = await this.repositoryServices.GetAllPrices();
            int distance = this.businessLogic.CalculateDistanceInKm(filterRequest);
            int total = this.businessLogic.CalculateTotalPrice(filterRequest, prices);
            
            return Validation.IsNotZero(total) ?
                ResponseServices.Successfull(new OutApiTwoDto() { Amount = total }) :
                ResponseServices.BadRequest<OutApiTwoDto>(Messages.ErrorWithDimentions);
        }
    }
}
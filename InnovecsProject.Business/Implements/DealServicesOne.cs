using System.Collections.Generic;
using System.Threading.Tasks;
using InnovecsProject.Business.BusinessLogic.ApiOne.Interface;
using InnovecsProject.Business.Interface;
using InnovecsProject.Business.Util;
using InnovecsProject.Business.Util.Messages;
using InnovecsProject.Business.Util.Validation;
using InnovecsProject.Model.Dto.ApiOne;
using InnovecsProject.Model.System;
using InnovecsProject.Repository.Interface;

namespace InnovecsProject.Business.Implements
{
    public class DealServicesOne : IDealServicesOne
    {
        private readonly IApiOneRepository repositoryServices;
        private readonly IApiOneBusinessLogic businessLogic;

        public DealServicesOne(IApiOneRepository repositoryServices, IApiOneBusinessLogic businessLogic)
        {
            this.businessLogic = businessLogic;
            this.repositoryServices = repositoryServices;
        }

        public async Task<ResponseDto<OutApiOneDto>> GettDeal(FilterApiOneDto filterRequest)
        {
            IEnumerable<DimensionPriceDto> prices = await this.repositoryServices.GetAllPrices();
            int distance = this.businessLogic.CalculateDistanceInKm(filterRequest);
            int total = this.businessLogic.CalculateTotalPrice(filterRequest, prices);

            return Validation.IsNotZero(total) ?
                ResponseServices.Successfull(new OutApiOneDto() { Total = total }) :
                ResponseServices.BadRequest(Messages.ErrorWithDimentions);
        }
    }
}
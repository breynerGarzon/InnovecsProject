using System.Collections.Generic;
using System.Threading.Tasks;
using InnovecsProject.Business.BusinessLogic.ApiThree.Interface;
using InnovecsProject.Business.Interface;
using InnovecsProject.Business.Util;
using InnovecsProject.Business.Util.Messages;
using InnovecsProject.Business.Util.Validation;
using InnovecsProject.Model.Dto.ApiOne;
using InnovecsProject.Model.Dto.ApiThree;
using InnovecsProject.Model.Dto.ApiTwo;
using InnovecsProject.Model.System;
using InnovecsProject.Repository.Interface;

namespace InnovecsProject.Business.Implements
{
    public class DealServicesThree : IDealServicesThree
    {
        private readonly IApiThreeRepository repositoryServices;
        private readonly IApiThreeBusinessLogic businessLogic;

        public DealServicesThree(IApiThreeRepository repositoryServices, IApiThreeBusinessLogic businessLogic)
        {
            this.businessLogic = businessLogic;
            this.repositoryServices = repositoryServices;
        }

        public async Task<ResponseDto<OutApiThreeDto>> GettDeal(string filterRequest)
        {
            IEnumerable<DimensionPriceDto> prices = await this.repositoryServices.GetAllPrices();
            FilterApiThreeDto filterData = this.businessLogic.DeserializeXml(filterRequest);
            int distance = this.businessLogic.CalculateDistanceInKm(filterData);
            int total = this.businessLogic.CalculateTotalPrice(filterData, prices);

            return Validation.IsNotZero(total) ?
                ResponseServices.Successfull(new OutApiThreeDto() { Quote = total }) :
                ResponseServices.BadRequest<OutApiThreeDto>(Messages.ErrorWithDimentions);
        }
    }
}
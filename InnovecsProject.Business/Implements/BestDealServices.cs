using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using InnovecsProject.Business.Interface;
using InnovecsProject.Business.Util;
using InnovecsProject.Business.Util.Messages;
using InnovecsProject.Business.Util.Validation;
using InnovecsProject.Model.Dto.ApiOne;
using InnovecsProject.Model.Dto.ApiThree;
using InnovecsProject.Model.Dto.ApiTwo;
using InnovecsProject.Model.Dto.BestDeal;
using InnovecsProject.Model.System;
using Microsoft.Extensions.Options;

namespace InnovecsProject.Business.Implements
{
    public class BestDealServices : IBestDealServices
    {
        private readonly IDealServicesOne dealServicesOne;
        private readonly IDealServicesTwo dealServicesTwo;
        private readonly IDealServicesThree dealServicesThree;
        private readonly DealApiDto configuration;
        private readonly IHttpClientFactory clientFactory;

        public BestDealServices(
            IHttpClientFactory clientFactory,
            IDealServicesOne dealServicesOne,
            IDealServicesTwo dealServicesTwo,
            IDealServicesThree dealServicesThree,
            IOptions<DealApiDto> configuration)
        {
            this.dealServicesOne = dealServicesOne;
            this.dealServicesTwo = dealServicesTwo;
            this.dealServicesThree = dealServicesThree;
            this.clientFactory = clientFactory;
            this.configuration = configuration.Value;
        }

        public async Task<ResponseDto<string>> GetBestDeal(FilterBestDealDto filterRequest)
        {
            Task<string> responseOne = ConsumeApi.Consume<FilterApiOneDto>(this.clientFactory, $"{this.configuration.One}", HttpMethod.Post, new FilterApiOneDto(filterRequest));
            Task<string> responseTwo = ConsumeApi.Consume<FilterApiTwoDto>(this.clientFactory, $"{this.configuration.Two}", HttpMethod.Post, new FilterApiTwoDto(filterRequest));
            Task<string> responseThree = ConsumeApi.Consume<FilterApiThreeDto>(this.clientFactory, $"{this.configuration.Three}", HttpMethod.Post, new FilterApiThreeDto(filterRequest));
            Task.WaitAll(responseOne, responseTwo, responseThree);

            ResponseDto<OutApiOneDto> resultOne = ConsumeApi.ConsumeDeserialize<ResponseDto<OutApiOneDto>>(responseOne.Result);
            ResponseDto<OutApiTwoDto> resultTwo = ConsumeApi.ConsumeDeserialize<ResponseDto<OutApiTwoDto>>(responseTwo.Result);
            ResponseDto<OutApiThreeDto> resultThree = ConsumeApi.ConsumeDeserialize<ResponseDto<OutApiThreeDto>>(responseThree.Result);

            int costOne = this.QuerySuccesfull(resultOne) ? resultOne.Data.Total : 0;
            int costTwo = this.QuerySuccesfull(resultTwo) ? resultTwo.Data.Amount : 0;
            int costThree = this.QuerySuccesfull(resultThree) ? resultThree.Data.Quote : 0;

            List<DealDto> pricesByApi = new List<DealDto>();
            pricesByApi.Add(new DealDto() { Message = $"Best deal Api1 with price: {costOne}", Price = costOne });
            pricesByApi.Add(new DealDto() { Message = $"Best deal Api2 with price: {costTwo}", Price = costTwo });
            pricesByApi.Add(new DealDto() { Message = $"Best deal Api3 with price: {costThree}", Price = costThree });

            DealDto bestDeal = pricesByApi.OrderBy(item => item.Price).Where(item => item.Price > 0).FirstOrDefault();

            return Validation.IsNotNull(bestDeal) ?
                   ResponseServices.Successfull(bestDeal.Message) :
                   ResponseServices.BadRequest<string>(Messages.ErrorWithDimentions);
        }

        public bool QuerySuccesfull<T>(ResponseDto<T> response)
        {
            return response.StatusCode == System.Net.HttpStatusCode.OK;
        }
    }
}
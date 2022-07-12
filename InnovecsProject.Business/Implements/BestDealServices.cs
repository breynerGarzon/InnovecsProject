using System.Net.Http;
using System.Threading.Tasks;
using InnovecsProject.Business.Interface;
using InnovecsProject.Business.Util;
using InnovecsProject.Business.Util.Validation;
using InnovecsProject.Model.Dto.ApiOne;
using InnovecsProject.Model.Dto.ApiTwo;
using InnovecsProject.Model.Dto.BestDeal;
using InnovecsProject.Model.System;
using Microsoft.Extensions.Options;

namespace InnovecsProject.Business.Implements
{
    public class BestDealServices : IBeastDealServices
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
            Task<string> responseOne = ConsumeApi.Consume(this.clientFactory, $"{this.configuration.One}{UrlSetUp.GetApiOneUrl(filterRequest)}", HttpMethod.Get);
            Task<string> responseTwo = ConsumeApi.Consume(this.clientFactory, $"{this.configuration.Two}{UrlSetUp.GetApiTwoUrls(filterRequest)}", HttpMethod.Get);
            Task<string> responseThree = ConsumeApi.Consume(this.clientFactory, $"{this.configuration.Three}{UrlSetUp.GetApiThreeUrls(filterRequest)}", HttpMethod.Get);
            Task.WaitAll(responseOne, responseTwo, responseThree);

            ResponseDto<OutApiOneDto> resultOne = ConsumeApi.ConsumeDeserialize<ResponseDto<OutApiOneDto>>(responseOne.Result);
            ResponseDto<OutApiTwoDto> resultTwo = ConsumeApi.ConsumeDeserialize<ResponseDto<OutApiTwoDto>>(responseTwo.Result);
            ResponseDto<OutApiThreeDto> resultThree = ConsumeApi.ConsumeDeserialize<ResponseDto<OutApiThreeDto>>(responseThree.Result);

            int costOne = resultOne.Data.Total;
            int costTwo = resultTwo.Data.Amount;
            int costThree = resultThree.Data.Quote;

            if (costOne < costTwo)
            {
                if (costOne < costThree)
                    return ResponseServices.Successfull($"Best deal Api1: {costOne}");
                else
                    return ResponseServices.Successfull($"Best deal Api3: {costThree}");
            }
            else
            {
                if (costTwo < costThree)
                    return ResponseServices.Successfull($"Best deal Api2: {costTwo}");
                else
                    return ResponseServices.Successfull($"Best deal Api3: {costThree}");
            }
        }
    }
}
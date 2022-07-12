using InnovecsProject.Model.Dto.BestDeal;

namespace InnovecsProject.Business.Util.Validation
{
    public static class UrlSetUp
    {
        public static string GetApiOneUrl(FilterBestDealDto filterRequest)
        {
            string parametersQuery = $"?ContactAdrress={filterRequest.Source}";
            parametersQuery += $"&WarehouseAddress={filterRequest.Destination}";
            parametersQuery += "&";

            return parametersQuery;
        }

        public static string GetApiTwoUrls(FilterBestDealDto filterRequest)
        {
            string parametersQuery = $"?Consignee={filterRequest.Source}";
            parametersQuery += $"&Consignor={filterRequest.Destination}";
            parametersQuery += "&";

            return parametersQuery;
        }

        public static string GetApiThreeUrls(FilterBestDealDto filterRequest)
        {
            string parametersQuery = $"?Source={filterRequest.Source}";
            parametersQuery += $"&Destination={filterRequest.Destination}";
            parametersQuery += "&";

            return parametersQuery;
        }
    }
}
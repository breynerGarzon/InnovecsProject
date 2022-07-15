using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using InnovecsProject.Business.BusinessLogic.ApiThree.Interface;
using InnovecsProject.Business.Util.Validation;
using InnovecsProject.Model.Dto.ApiOne;
using InnovecsProject.Model.Dto.ApiThree;

namespace InnovecsProject.Business.BusinessLogic.ApiThree.Implements
{
    public class ApiThreeBusinessLogic : IApiThreeBusinessLogic
    {
        public int CalculateDistanceInKm(FilterApiThreeDto filterRequest)
        {
            Random distance = new Random();
            return distance.Next(1, 20);
        }

        public int CalculateTotalPrice(FilterApiThreeDto filterRequest, IEnumerable<DimensionPriceDto> prices)
        {
            int total = 0;
            int totalVolumen = filterRequest.Packages.Sum(package => package.Volumen);
            DimensionPriceDto lastVolumen;
            prices.ToList().ForEach(price =>
            {
                bool isSameVolumnen = price.Volumen == totalVolumen;
                if (isSameVolumnen)
                    total += price.Price;
            });

            if (!Validation.IsNotZero(total) && Validation.IsNotZero(totalVolumen))
            {
                lastVolumen = prices.OrderByDescending(price => price.Volumen).FirstOrDefault(price => price.Volumen <= totalVolumen);
                decimal differents = (decimal)(1 - ((decimal)lastVolumen.Volumen / (decimal)totalVolumen));
                total = differents < 0.1m ? lastVolumen.Price : 0; 
            }

            return total;
        }



        public FilterApiThreeDto DeserializeXml(string xmlStruct)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(FilterApiThreeDto));
            using (StringReader reader = new StringReader(xmlStruct))
            {
                return (FilterApiThreeDto)(serializer.Deserialize(reader));
            }
        }
    }
}
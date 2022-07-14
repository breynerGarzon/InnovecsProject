using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using InnovecsProject.Business.BusinessLogic.ApiOne.Implements;
using InnovecsProject.Business.BusinessLogic.ApiOne.Interface;
using InnovecsProject.Business.Implements;
using InnovecsProject.Business.Interface;
using InnovecsProject.Business.Util.Messages;
using InnovecsProject.Business.Util.Validation;
using InnovecsProject.Model.Dto.ApiOne;
using InnovecsProject.Model.System;
using InnovecsProject.Repository.Implements;
using InnovecsProject.Repository.Interface;
using Xunit;

namespace InnovecsProject.Test.ApiOne
{
    public class TestDealServicesOne
    {
        private IApiOneRepository GetRepositoryImplementation()
        {
            return new ApiOneRepository();
        }

        private IApiOneBusinessLogic GetLogicImplementation()
        {
            return new ApiOneBusinessLogic();
        }


        [Theory]
        [MemberData(nameof(DataShippingTestOne))]
        public async Task TestCalculateTotalPriceWithStatusCode(FilterApiOneDto requestPrice, HttpStatusCode statusWaitind)
        {
            IDealServicesOne dealServices = new DealServicesOne(this.GetRepositoryImplementation(), this.GetLogicImplementation());

            ResponseDto<OutApiOneDto> prices = await dealServices.CalculatePrice(requestPrice);
            Assert.True(prices.StatusCode == statusWaitind);
        }

        [Theory]
        [MemberData(nameof(DataShippingTestTwo))]
        public async Task TestCalculateTotalPrice(FilterApiOneDto requestPrice)
        {
            IDealServicesOne dealServices = new DealServicesOne(this.GetRepositoryImplementation(), this.GetLogicImplementation());
            int totalVolumen = 0;
            requestPrice.PackageDimensions.ToList().ForEach(p =>
            {
                totalVolumen += p.Volumen;
            });

            int priceExpected = totalVolumen * 5;

            ResponseDto<OutApiOneDto> prices = await dealServices.CalculatePrice(requestPrice);

            if (!Validation.IsNotZero(priceExpected))
                Assert.True(prices.Message.Equals(Messages.ErrorWithDimentions));
            else
                Assert.True(prices.Data.Total <= priceExpected);
        }



        public static IEnumerable<object[]> DataShippingTestOne()
        {
            return new List<object[]>
            {
                new object[] {
                    new FilterApiOneDto(){
                        ContactAdrress = "Adress false 123",
                        WarehouseAddress = "Adress false 1234",
                        PackageDimensions = new List<DimensionDto>(){
                            new DimensionDto(){High=1,Width=1, Length=1},
                            new DimensionDto(){High=2,Width=1, Length=2},
                            new DimensionDto(){High=1,Width=3, Length=3},
                        },
                    },HttpStatusCode.OK
                },
                new object[] {

                    new FilterApiOneDto(){
                        ContactAdrress = "Adress false 123",
                        WarehouseAddress = "Adress false 1234",
                        PackageDimensions = new List<DimensionDto>(){
                            // new DimensionDto(){High=1,Width=1, Length=1},
                            // new DimensionDto(){High=2,Width=1, Length=2},
                            // new DimensionDto(){High=1,Width=3, Length=3},
                        },
                    },HttpStatusCode.BadRequest
                },
                new object[] {

                    new FilterApiOneDto(){
                        ContactAdrress = "Adress false 123",
                        WarehouseAddress = "Adress false 1234",
                        PackageDimensions = new List<DimensionDto>(){
                            new DimensionDto(){High=-1,Width=1, Length=1},
                            new DimensionDto(){High=2,Width=1, Length=-2},
                            new DimensionDto(){High=1,Width=-3, Length=3},
                        },
                    },HttpStatusCode.BadRequest
                },
                new object[] {

                    new FilterApiOneDto(){
                        ContactAdrress = "Adress false 123",
                        WarehouseAddress = "Adress false 1234",
                        PackageDimensions = new List<DimensionDto>(){
                            new DimensionDto(){High=01,Width=0, Length=0},
                            new DimensionDto(){High=0,Width=0, Length=0},
                            new DimensionDto(){High=0,Width=3, Length=0},
                        },
                    },HttpStatusCode.BadRequest
                },

            };
        }

        public static IEnumerable<object[]> DataShippingTestTwo()
        {
            return new List<object[]>
            {
                new object[] {
                    new FilterApiOneDto(){
                        ContactAdrress = "Adress false 123",
                        WarehouseAddress = "Adress false 1234",
                        PackageDimensions = new List<DimensionDto>(){
                            new DimensionDto(){High=1,Width=1, Length=1},
                            new DimensionDto(){High=5,Width=5, Length=5},
                            new DimensionDto(){High=1,Width=3, Length=3},
                        },
                    },
                },
                new object[] {

                    new FilterApiOneDto(){
                        ContactAdrress = "Adress false 123",
                        WarehouseAddress = "Adress false 1234",
                        PackageDimensions = new List<DimensionDto>(){
                            // new DimensionDto(){High=1,Width=1, Length=1},
                            // new DimensionDto(){High=2,Width=1, Length=2},
                            // new DimensionDto(){High=1,Width=3, Length=3},
                        },
                    },
                },
                new object[] {

                    new FilterApiOneDto(){
                        ContactAdrress = "Adress false 123",
                        WarehouseAddress = "Adress false 1234",
                        PackageDimensions = new List<DimensionDto>(){
                            new DimensionDto(){High=-1,Width=1, Length=1},
                            new DimensionDto(){High=2,Width=1, Length=-2},
                            new DimensionDto(){High=1,Width=-3, Length=3},
                        },
                    },
                },
                new object[] {

                    new FilterApiOneDto(){
                        ContactAdrress = "Adress false 123",
                        WarehouseAddress = "Adress false 1234",
                        PackageDimensions = new List<DimensionDto>(){
                            new DimensionDto(){High=01,Width=0, Length=0},
                            new DimensionDto(){High=0,Width=0, Length=0},
                            new DimensionDto(){High=0,Width=3, Length=0},
                        },
                    },
                },

            };
        }
    }
}
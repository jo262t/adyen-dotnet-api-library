﻿using Adyen.Model.BinLookup;
using Adyen.Model.Enum;
using Adyen.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace Adyen.Test
{
    [TestClass]
    public class BinLookupTest : BaseTest
    {
        [DataTestMethod]
        [DataRow(true)]
        [DataRow(false)]
        public async Task Get3dsAvailabilitySuccessMockedTest(bool runAsync)
        {
            var client = CreateMockTestClientApiKeyBasedRequest("Mocks/binlookup/get3dsavailability-success.json");
            var binLookup = new BinLookup(client);
            var threeDsAvailabilityRequest = new ThreeDSAvailabilityRequest
            {
                MerchantAccount = "merchantAccount",
                CardNumber = "4111111111111111"
            };

            var threeDsAvailabilityResponse = runAsync ?
                await binLookup.ThreeDsAvailabilityAsync(threeDsAvailabilityRequest)
                : binLookup.ThreeDsAvailability(threeDsAvailabilityRequest);

            Assert.AreEqual("visa", threeDsAvailabilityResponse.DsPublicKeys[0].Brand);
            Assert.AreEqual("visa", threeDsAvailabilityResponse.ThreeDS2CardRangeDetails[0].BrandCode);
            Assert.AreEqual(true, threeDsAvailabilityResponse.ThreeDS1Supported);
        }

        [DataTestMethod]
        [DataRow(true)]
        [DataRow(false)]
        public async Task GetCostEstimateSuccessMockedTest(bool runAsync)
        {
            var client = CreateMockTestClientApiKeyBasedRequest("Mocks/binlookup/getcostestimate-success.json");
            var binLookup = new BinLookup(client);
            var costEstimateRequest = new CostEstimateRequest();
            var amount = new Amount
            {
                Currency = "EUR",
                Value = 1000
            };
            costEstimateRequest.Amount = amount;
            var costEstimateAssumptions = new CostEstimateAssumptions
            {
                AssumeLevel3Data = true,
                Assume3DSecureAuthenticated = true
            };
            costEstimateRequest.Assumptions = costEstimateAssumptions;
            costEstimateRequest.CardNumber = "4111111111111111";
            costEstimateRequest.MerchantAccount = "merchantAccount";
            var merchantDetails = new MerchantDetails
            {
                CountryCode = "NL",
                Mcc = "7411",
                EnrolledIn3DSecure = true
            };
            costEstimateRequest.MerchantDetails = (merchantDetails);
            costEstimateRequest.ShopperInteraction = ShopperInteraction.Ecommerce;

            var costEstimateResponse = runAsync ?
                await binLookup.CostEstimateAsync(costEstimateRequest)
                : binLookup.CostEstimate(costEstimateRequest);

            Assert.AreEqual("1111", costEstimateResponse.CardBin.Summary);
            Assert.AreEqual("Unsupported", costEstimateResponse.ResultCode);
            Assert.AreEqual("ZERO", costEstimateResponse.SurchargeType);
        }
    }
}

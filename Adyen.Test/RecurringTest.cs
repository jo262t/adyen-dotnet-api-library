using Adyen.HttpClient;
using Adyen.Model.Enum;
using Adyen.Model.Recurring;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Threading.Tasks;
using Recurring = Adyen.Model.Recurring.Recurring;

namespace Adyen.Test
{
    [TestClass]
    public class RecurringTest : BaseTest
    {

        [DataTestMethod]
        [DataRow(true)]
        [DataRow(false)]
        public async Task TestListRecurringDetails(bool runAsync)
        {
            var client = base.CreateMockTestClientRecurringRequest("Mocks/recurring/listRecurringDetails-success.json");
            var recurring = new Service.Recurring(client);
            var recurringDetailsRequest = this.CreateRecurringDetailsRequest();

            var recurringDetailsResult = runAsync ?
                await recurring.ListRecurringDetailsAsync(recurringDetailsRequest)
                : recurring.ListRecurringDetails(recurringDetailsRequest);

            Assert.AreEqual(1L, (long)recurringDetailsResult.Details.Count);

            var recurringDetail = recurringDetailsResult.Details.FirstOrDefault()?.RecurringDetail;
            Assert.AreEqual("recurringReference", recurringDetail?.RecurringDetailReference);
            Assert.AreEqual("cardAlias", recurringDetail?.Alias);
            Assert.AreEqual("1111", recurringDetail?.Card.Number);
        }

        [DataTestMethod]
        [DataRow(true)]
        [DataRow(false)]
        public async Task TestDisable(bool runAsync)
        {
            var client = base.CreateMockTestClientRecurringRequest("Mocks/recurring/disable-success.json");
            var recurring = new Service.Recurring(client);
            var disableRequest = this.CreateDisableRequest();
            
            var disableResult = runAsync ? 
                await recurring.DisableAsync(disableRequest)
                : recurring.Disable(disableRequest);

            Assert.AreEqual(1L, (long)disableResult.Details.Count);
            Assert.AreEqual("[detail-successfully-disabled]", disableResult.Response);
        }

        [DataTestMethod]
        [DataRow(true)]
        [DataRow(false)]
        public async Task TestDisable803(bool runAsync)
        {
            var client = base.CreateMockTestClientForErrors(422,"Mocks/recurring/disable-error-803.json");
            var recurring = new Service.Recurring(client);
            
            var disableRequest = this.CreateDisableRequest();

            var exception = runAsync ?
                    await Assert.ThrowsExceptionAsync<HttpClientException>(async () =>
                        await recurring.DisableAsync(disableRequest))
                : Assert.ThrowsException<HttpClientException>(() => recurring.Disable(disableRequest)); 

            Assert.AreEqual(422, exception.Code);
            Assert.AreEqual("An error occured", exception.Message);
        }

        private RecurringDetailsRequest CreateRecurringDetailsRequest()
        {
            var request = new RecurringDetailsRequest
            {
                ShopperReference = "test-123",
                MerchantAccount = "DotNetAlexandros",
                Recurring = new Recurring { Contract = Contract.Oneclick }
            };
            return request;
        }

        private DisableRequest CreateDisableRequest()
        {
            var request = new DisableRequest
            {
                ShopperReference = "test-123",
                MerchantAccount = "DotNetAlexandros"
            };
            return request;
        }

    }
}

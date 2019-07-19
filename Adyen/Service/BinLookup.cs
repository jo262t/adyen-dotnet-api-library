using Adyen.Model.BinLookup;
using Adyen.Service.Resource.BinLookup;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Adyen.Service
{
    public class BinLookup : AbstractService
    {
        private readonly Get3dsAvailability _get3dsAvailability;
        private readonly GetCostEstimate _getCostEstimate;

        public BinLookup(Client client)
            : base(client)
        {
            this._get3dsAvailability = new Get3dsAvailability(this);
            this._getCostEstimate = new GetCostEstimate(this);
        }

        public ThreeDSAvailabilityResponse ThreeDsAvailability(ThreeDSAvailabilityRequest threeDsAvailabilityRequest)
        {
            var jsonRequest = Util.JsonOperation.SerializeRequest(threeDsAvailabilityRequest);
            var jsonResponse = _get3dsAvailability.Request(jsonRequest);
            return JsonConvert.DeserializeObject<ThreeDSAvailabilityResponse>(jsonResponse);
        }

        public async Task<ThreeDSAvailabilityResponse> ThreeDsAvailabilityAsync(ThreeDSAvailabilityRequest threeDsAvailabilityRequest)
        {
            var jsonRequest = Util.JsonOperation.SerializeRequest(threeDsAvailabilityRequest);
            var jsonResponse = await _get3dsAvailability.RequestAsync(jsonRequest);
            return JsonConvert.DeserializeObject<ThreeDSAvailabilityResponse>(jsonResponse);
        }

        public CostEstimateResponse CostEstimate(CostEstimateRequest costEstimateRequest)
        {
            var jsonRequest = Util.JsonOperation.SerializeRequest(costEstimateRequest);
            var jsonResponse = _getCostEstimate.Request(jsonRequest);
            return JsonConvert.DeserializeObject<CostEstimateResponse>(jsonResponse);
        }

        public async Task<CostEstimateResponse> CostEstimateAsync(CostEstimateRequest costEstimateRequest)
        {
            var jsonRequest = Util.JsonOperation.SerializeRequest(costEstimateRequest);
            var jsonResponse = await _getCostEstimate.RequestAsync(jsonRequest);
            return JsonConvert.DeserializeObject<CostEstimateResponse>(jsonResponse);
        }
    }
}

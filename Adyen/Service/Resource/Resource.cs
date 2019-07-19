using Adyen.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Adyen.Service.Resource
{
    public class Resource
    {
        private readonly AbstractService _abstractService;
        protected string Endpoint;
        protected List<string> RequiredFields;

        public Resource(AbstractService abstractService, string endpoint, List<string> requiredFields)
        {
            _abstractService = abstractService;
            Endpoint = endpoint;
            RequiredFields = requiredFields;
        }
        
        public string Request(string json)
        {
            var clientInterface = this._abstractService.Client.HttpClient;
            var config = this._abstractService.Client.Config;
            return clientInterface.Request(this.Endpoint, json, config);
        }

        public async Task<string> RequestAsync(string json, RequestOptions requestOptions = null)
        {
            var clientInterface = this._abstractService.Client.HttpClient;
            var config = this._abstractService.Client.Config;
            return await clientInterface.RequestAsync(this.Endpoint, json, config, _abstractService.IsApiKeyRequired, requestOptions);
        }
    }
}
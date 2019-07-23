using Adyen.Model;
using System.Collections.Generic;
using System.Net.Security;
using System.Threading.Tasks;

namespace Adyen.Service
{
    public class ServiceResource
    {
        private readonly AbstractService _abstractService;
        protected string Endpoint;
       
        public ServiceResource(AbstractService abstractService, string endpoint, List<string> requiredFields)
        {
            _abstractService = abstractService;
            Endpoint = endpoint;
        }

        public string Request(string json, RequestOptions requestOptions = null)
        {
            var clientInterface = _abstractService.Client.HttpClient;
            var config = _abstractService.Client.Config;
            return clientInterface.Request(Endpoint, json, config, _abstractService.IsApiKeyRequired, requestOptions);
        }

        public async Task<string> RequestAsync(string json, RequestOptions requestOptions = null)
        {
            var clientInterface = _abstractService.Client.HttpClient;
            var config = _abstractService.Client.Config;
            return await clientInterface.RequestAsync(Endpoint, json, config,false, requestOptions);
        }

        public string Request(string json, RemoteCertificateValidationCallback remoteCertificateValidationCallback, RequestOptions requestOptions = null)
        {
            var clientInterface = _abstractService.Client.HttpClient;
            var config = _abstractService.Client.Config;
            return clientInterface.Request(Endpoint, json, config, _abstractService.IsApiKeyRequired, requestOptions, remoteCertificateValidationCallback);
        }

        public async Task<string> RequestAsync(string json, RemoteCertificateValidationCallback remoteCertificateValidationCallback, RequestOptions requestOptions = null)
        {
            var clientInterface = _abstractService.Client.HttpClient;
            var config = _abstractService.Client.Config;
            return await clientInterface.RequestAsync(Endpoint, json, config, _abstractService.IsApiKeyRequired, requestOptions, remoteCertificateValidationCallback);
        }
        
    }
}
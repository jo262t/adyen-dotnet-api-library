using Adyen.Model;
using System.Collections.Generic;
using System.Net.Security;
using System.Threading.Tasks;

namespace Adyen.HttpClient.Interfaces
{
    public interface IClient
    {
        string Request(string endpoint, string json, Config config);
        string Request(string endpoint, string json, Config config, bool isApiKeyRequired, RequestOptions requestOptions, RemoteCertificateValidationCallback remoteCertificateValidationCallback = null);
        
        Task<string> RequestAsync(string endpoint, string json, Config config, bool isApiKeyRequired, RequestOptions requestOptions, RemoteCertificateValidationCallback remoteCertificateValidationCallback = null);
        
        string Post(string endpoint, Dictionary<string, string> postParameters, Config config);
    }
}
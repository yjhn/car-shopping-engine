using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace Services.Dependencies
{
    public partial class CarNetApiClient
    {
        private readonly string _carNetApiKey;

        public CarNetApiClient(string apiKey, string carNetApiUrl, HttpClient httpClient) : this(httpClient)
        {
            _carNetApiKey = apiKey;
            BaseUrl = carNetApiUrl;
        }

        partial void PrepareRequest(HttpClient client, HttpRequestMessage request, string url)
        {
            request.Headers.Add("api-key", _carNetApiKey);
        }

        public async Task<Response> DetectVehicle(Stream image)
        {
            return await DetectAsync(null, null, null, null, null, null, null, Region.EU, image);
        }
    }

    public class ApiInfoContainer
    {
        public string ApiKey { get; set; }
        public string Url { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Server
{
    public partial class CarNetApiClient
    {
        private readonly string _carNetApiKey;

        public CarNetApiClient(string apiKey)
        {
            _carNetApiKey = apiKey;
        }

        partial void PrepareRequest(System.Net.Http.HttpClient client, System.Net.Http.HttpRequestMessage request, string url)
        {
            request.Headers.Add("api-key", _carNetApiKey);
        }

        //public async Task<IEnumerable<Car>> GetCarsByImage(string base64Image)
        //{
        //    Response response = await DetectAsync(null, null, null, null, null, null, null, Region.EU, new MemoryStream(Convert.FromBase64String(base64Image)));
        //    var detectedCars = response.Detections;

        //    // we take only the first recognized car
        //    var firstCar = detectedCars.FirstOrDefault();

        //    if(firstCar == null)
        //    {
        //        // if no cars were recognized, we return null
        //        return null;
        //    }

        //    var carData = firstCar.Mmg.First();
        //    string manufacturer = carData.Make_name;
        //    string model = carData.Model_name;
        //    // year format: <start>-<end>
        //    string[] years = carData.Years.Split('-');
        //    int startYear = Convert.ToInt32(years[0]);
        //    int endYear = Convert.ToInt32(years[1]);

        //    // nothing can be done until we have db
        //}
    }

    public class ApiKeyContainer
    {
        public string ApiKey { get; set; }
    }
}

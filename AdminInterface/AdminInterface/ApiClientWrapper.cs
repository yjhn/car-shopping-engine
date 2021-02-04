using System;
using System.Text;

namespace AdminInterface
{
    public partial class swaggerClient
    {
        private string _httpBasicAuth;

        public swaggerClient(string url) : this(url, new System.Net.Http.HttpClient())
        { }

        public void SetUser(string username, string password)
        {
            _httpBasicAuth = Convert.ToBase64String(Encoding.ASCII.GetBytes(username + ":" + password));
        }

        public void RemoveUser()
        {
            _httpBasicAuth = null;
        }

        partial void PrepareRequest(System.Net.Http.HttpClient client, System.Net.Http.HttpRequestMessage request, string url)
        {
            request.Headers.Add("Authorization", "Basic " + _httpBasicAuth);
        }
    }

    public partial class OutgoingFullUserDTO
    {
        public override string ToString()
        {
            return 
                $"----------------------------------------------\n" +
                $"    Username: {Username}\n" +
                $"        Role: {Role}\n" +
                $"       Phone: {Phone}\n" +
                $"       Email: {Email}\n" +
                $"   Liked ads: \n{LikedAds.ToString<int>()}" +
                $"Uploaded ads: \n{UploadedAds.ToString<int>()}" +
                $"     Enabled: {!Disabled}\n" +
                $"----------------------------------------------";
        }
    }

    public partial class OutgoingFullVehicleDTO
    {
        public override string ToString()
        {
            return
                $"-----------------------------------------------------------------------------\n" +
                $"                          Id: {Id}\n" +
                $"                       Price: {Price}\n" +
                $"           Uploader username: {UploaderUsername}\n" +
                $"                 Upload date: {Created}\n" +
                $"                       Brand: {Brand}\n" +
                $"                       Model: {Model}\n" +
                $"                        Used: {Used}\n" +
                $"            Date of purchase: {Purchased}\n" +
                $"                 Engine data:\n{Engine}\n" + // print all engine data: volume, hp, kw, type, fuel type
                $"                Chassis type: {ChassisType}\n" +
                $"                       Color: {Color}\n" +
                $"                Gearbox data:\n{Gearbox}\n" + // print all gearbox data: gearbox type, number of gears
                $"           Kilometers driven: {KilometersDriven}\n" +
                $"                Drive wheels: {DriveWheels}\n" +
                $"                     Defects:\n{Defects.ToString<string>()}" +
                $"         Steering wheel side: {SteeringWheelSide}\n" +
                $"             Number of doors: {NumberOfDoors}\n" +
                $"                       Seats: {Seats}\n" +
                $"Next vehicle inspection date: {NextVehicleInspection}\n" +
                $"                  Wheel size: {WheelSize}\n" +
                $"                      Weight: {Weight}\n" +
                $"              Origin country: {OriginalPurchaseCountry}\n" +
                $"                         VIN: {Vin}\n" +
                $"       Additional properties:\n{AdditionalProperties.ToString<string>()}" +
                $"                      Images: {Images.Count} (not shown)\n" +
                $"                     Comment: {Comment}\n" +
                $"                      Hidden: {Hidden}\n" +
                $"-----------------------------------------------------------------------------";
        }
    }
}

using Newtonsoft.Json;

namespace NimbleSchedule.Client.Models
{
	/// <summary>
	/// NimbleSchedule API Authentication Information class used to provide authentication information to
	/// the client during api calls.
	/// 
	/// See the sample AuthInfo.json file included in with this library on how the json is structured.
	/// 
	/// This internal class need not be accessed by the consuming assembly, as the NimbleApiClient
	/// will perform the work of this class.
	/// </summary>
    [JsonObject]
	public class AuthInfo
	{
		public string CompanyId { get; set; }
		public string ApiKey { get; set; }
		public string UserName { get; set; }
		public string Password { get; set; }
	}
}

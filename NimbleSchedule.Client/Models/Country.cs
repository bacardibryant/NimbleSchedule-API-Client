using Newtonsoft.Json;

namespace NimbleSchedule.Client.Models
{
    /// <summary>
    /// .NET Object that maps to JSON Object returned from API.
    /// </summary>
	[JsonObject]
    public class Country
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}

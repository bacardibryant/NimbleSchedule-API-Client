using Newtonsoft.Json;

namespace NimbleSchedule.Client.Models
{
    /// <summary>
    /// .NET object that maps to JSON object returned from api.
    /// </summary>
    [JsonObject]
    public class Location
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}

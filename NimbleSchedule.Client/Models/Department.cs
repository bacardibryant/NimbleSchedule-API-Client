using Newtonsoft.Json;

namespace NimbleSchedule.Client.Models
{
    [JsonObject]
    public class Department
    {
        public string Id { get; set; }
        public string Name { get; set; }

    }
}

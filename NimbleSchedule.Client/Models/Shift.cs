using Newtonsoft.Json;

namespace NimbleSchedule.Client.Models
{
    /// <summary>
    /// .NET Object that maps to the JSON Object returned from the API.
    /// </summary>
	[JsonObject]
	public class Shift
	{
		public string Id { get; set; }
		public string EmployeeId { get; set; }
		public string EmployeeName { get; set; }
		public string LocationName { get; set; }
		public string PositionName { get; set; }
		public string DepartmentName { get; set; }
		public string StartAt { get; set; }
		public string EndAt { get; set; }
		public string Color { get; set; }
		public string Title { get; set; }
		public string Notes { get; set; }
		public string IsPublished { get; set; }
	}
}
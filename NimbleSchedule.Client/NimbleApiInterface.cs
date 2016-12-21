using Newtonsoft.Json;
using NimbleSchedule.Client.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace NimbleSchedule.Client
{
    internal class NimbleApiInterface : IDisposable
	{
		private HttpClient _client = new HttpClient();
        private AuthInfo _authInfo = new AuthInfo();

        /// <summary>
        /// Constructor accepts authentication information and initializes HTTP Client.
        /// </summary>
        /// <param name="authInfo">AuthInfo object containing authentication information for nimbleschedule.com</param>
		public NimbleApiInterface(AuthInfo authInfo)
		{
            // set authentication information.
            _authInfo = authInfo;

            // set client parameters
            _client.BaseAddress = new Uri("https://app.nimbleschedule.com");
			_client.DefaultRequestHeaders.Accept.Clear();
			_client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
		}

		/// <summary>
		/// Gets the schedules from source.
		/// </summary>
		/// <returns>.NET List of schedules for selected time period.</returns>
		public async Task<List<Shift>> GetShiftsAsync(DateTime startDate, DateTime endDate)
		{

			var shifts = new List<Shift>();

			// format the dates
			var shiftStart = startDate.ToString("yyyy-MM-ddTHH:mm");
			var shiftEnd = endDate.ToString("yyyy-MM-ddTHH:mm");


			// call api async and wait for response.
			HttpResponseMessage response = await _client.GetAsync("/api/scheduledshifts/GetShifts?CompanyId=" + _authInfo.CompanyId + "&format=JSON&AuthToken=" + _authInfo.ApiKey + "&startAt=" + shiftStart + "&endAt=" + shiftEnd);

			// if an error code this will throw and exception.
			if (response.IsSuccessStatusCode)
			{
				// read json response
				string responseBody = await response.Content.ReadAsStringAsync();

				// parse json into list.
				shifts = JsonConvert.DeserializeObject<List<Shift>>(responseBody);
			}

			return shifts;
		}

        /// <summary>
        /// Get all employees for company.
        /// </summary>
        /// <returns>.NET List of employees</returns>
		public async Task<List<Employee>> GetEmployeesAsync()
		{

			var employees = new List<Employee>();

            // call api async and wait for response.
            HttpResponseMessage response = await _client.GetAsync("/api/employees?CompanyId=" + _authInfo.CompanyId + "&format=JSON&AuthToken=" + _authInfo.ApiKey);

			// if an error code this will throw and exception.
			if (response.IsSuccessStatusCode)
			{
				// read json response
				string responseBody = await response.Content.ReadAsStringAsync();

				// parse json into list.
				employees = JsonConvert.DeserializeObject<List<Employee>>(responseBody);
			}


			return employees;
		}

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                    _client.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~NimbleApiInterface() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}

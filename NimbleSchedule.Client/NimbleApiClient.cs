using NimbleSchedule.Client.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NimbleSchedule.Client
{
    public static class NimbleApiClient
	{
      
        /// <summary>
        /// Asynchronous method that calls the nimbleschedule to get the shifts for a selected date range.
        /// </summary>
        /// <param name="startDate">The beginning date.</param>
        /// <param name="endDate">The ending date.</param>
        /// <param name="authInfo">The authentication object with api credentials.</param>
        /// <returns>.NET List Collection of shifts for the selected date range.</returns>
		public static async Task<List<Shift>> GetShiftsAsync(DateTime startDate, DateTime endDate, AuthInfo authInfo)
		{
			NimbleApiInterface apiInterface = new NimbleApiInterface(authInfo);
			return await apiInterface.GetShiftsAsync(startDate, endDate);
		}

        /// <summary>
        /// Asynchronous method to the nimbleschedule api to get all employees for the company.
        /// </summary>
        /// <param name="authInfo">The authentication object with api credentials.</param>
        /// <returns>.NET List Collection of employee objects for the company.</returns>
		public static async Task<List<Employee>> GetEmployeesAsync(AuthInfo authInfo)
		{
			NimbleApiInterface apiInterface = new NimbleApiInterface(authInfo);
			return await apiInterface.GetEmployeesAsync();
		}
		
	}
}

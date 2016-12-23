using NimbleSchedule.Client.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NimbleSchedule.Client
{
    public static class NimbleApiClient
	{

        /// <summary>
        /// Asynchronous method to the nimbleschedule api to get a list of countries.
        /// </summary>
        /// <param name="authInfo">The authentication object with api credentials.</param>
        /// <returns>.NET List Collection of country objects.</returns>
		public static async Task<List<Country>> GetCountriesAsync(AuthInfo authInfo)
        {
            // call interrface within using so that dispose gets called on resources
            using (NimbleApiInterface apiInterface = new NimbleApiInterface(authInfo))
            {
                return await apiInterface.GetCountriesAsync();
            }
        }

        /// <summary>
        /// Asynchronous method to the nimbleschedule api to get a list of departments for the company.
        /// </summary>
        /// <param name="authInfo">The authentication object with api credentials.</param>
        /// <returns>.NET List Collection of department objects.</returns>
		public static async Task<List<Department>> GetDepartmentsAsync(AuthInfo authInfo)
        {
            // call interrface within using so that dispose gets called on resources
            using (NimbleApiInterface apiInterface = new NimbleApiInterface(authInfo))
            {
                return await apiInterface.GetDepartmentsAsync();
            }
        }

        /// <summary>
        /// Asynchronous method that calls the nimbleschedule to get the shifts for a selected date range.
        /// </summary>
        /// <param name="startDate">The beginning date.</param>
        /// <param name="endDate">The ending date.</param>
        /// <param name="authInfo">The authentication object with api credentials.</param>
        /// <returns>.NET List Collection of shifts for the selected date range.</returns>
        public static async Task<List<Shift>> GetShiftsAsync(DateTime startDate, DateTime endDate, AuthInfo authInfo)
		{
            // call interrface within using so that dispose gets called on resources
            using (NimbleApiInterface apiInterface = new NimbleApiInterface(authInfo))
            {
                return await apiInterface.GetShiftsAsync(startDate, endDate);
            }
		}

        /// <summary>
        /// Asynchronous method to the nimbleschedule api to get all employees for the company.
        /// </summary>
        /// <param name="authInfo">The authentication object with api credentials.</param>
        /// <returns>.NET List Collection of employee objects for the company.</returns>
		public static async Task<List<Employee>> GetEmployeesAsync(AuthInfo authInfo)
		{
            // call interrface within using so that dispose gets called on resources
            using (NimbleApiInterface apiInterface = new NimbleApiInterface(authInfo))
            {
                return await apiInterface.GetEmployeesAsync();
            }
		}

        /// <summary>
        /// Asynchronous method to the nimbleschedule api to get all locations for the company.
        /// </summary>
        /// <param name="authInfo">The authentication object with api credentials.</param>
        /// <returns>.NET List Collection of location objects for the company.</returns>
        public static async Task<List<Location>> GetLocationsAsync(AuthInfo authInfo)
        {
            // call interrface within using so that dispose gets called on resources
            using (NimbleApiInterface apiInterface = new NimbleApiInterface(authInfo))
            {
                return await apiInterface.GetLocationsAsync();
            }
        }

        /// <summary>
        /// Asynchronous method to the nimbleschedule api to get all locations that the user has access to.
        /// </summary>
        /// <param name="authInfo">The authentication object with api credentials.</param>
        /// <returns>.NET List Collection of location objects for the company.</returns>
        public static async Task<List<Location>> GetAccessibleLocationsAsync(AuthInfo authInfo)
        {
            // call interrface within using so that dispose gets called on resources
            using (NimbleApiInterface apiInterface = new NimbleApiInterface(authInfo))
            {
                return await apiInterface.GetAccessibleLocationsAsync();
            }
        }
    }
}

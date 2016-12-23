using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using NimbleSchedule.Client.Models;
using System;
using System.IO;
using System.Threading.Tasks;

namespace NimbleSchedule.Client.Tests
{
    [TestClass]
    public class NimbleClientTests
    {
        private const string configDataLocation = "App_Data/authConfig.json";
        private AuthInfo authInfo;

        /// <summary>
        /// Implemented test class constructor so that authInfo file i/o is only called once. Although in the case of test classes
        /// the constructor is called for each test method, so this would be the same as including the call in each method.
        /// However, try to stay consisted with good coding practices and keep things DRY yet with out abstracting away too much of the context
        /// so that you are still left with somewhat self-documenting code.
        /// </summary>
        public NimbleClientTests()
        {
            // read authentication information from configuration file.
            authInfo = JsonConvert.DeserializeObject<AuthInfo>(File.ReadAllText(configDataLocation));
        }

        [TestMethod]
        public async Task Client_Can_Get_Countries_Async()
        {
            // call static async method with parameter.
            var countries = await NimbleApiClient.GetCountriesAsync(authInfo);

            // assert that results were returned from the api.
            Assert.IsTrue(countries.Count > 0);
        }

        [TestMethod]
        public async Task Client_Can_Get_Departments_Async()
        {
            // call static async method with parameter.
            var departments = await NimbleApiClient.GetDepartmentsAsync(authInfo);

            // assert that results were returned from the api.
            Assert.IsTrue(departments.Count > 0);
        }

        [TestMethod]
        public async Task Client_Can_Get_Shifts_Async()
        {

            // call static async method with parameters. testing with 14 day span
            var shifts = await NimbleApiClient.GetShiftsAsync(DateTime.Today.AddDays(-14), DateTime.Today, authInfo);

            // test that results were returned from the api.
            Assert.IsTrue(shifts.Count > 0);
        }

        [TestMethod]
        public async Task Client_Can_Get_Employees_Async()
        {
            // call static async method with parameter.
            var employees = await NimbleApiClient.GetEmployeesAsync(authInfo);

            // assert that results were returned from the api.
            Assert.IsTrue(employees.Count > 0);
        }

        [TestMethod]
        public async Task Client_Can_Get_Locations_Async()
        {
            // call static async method with parameter.
            var locations = await NimbleApiClient.GetLocationsAsync(authInfo);

            // assert that results were returned from the api.
            Assert.IsTrue(locations.Count > 0);
        }

        [TestMethod]
        public async Task Client_Can_Get_Accessible_Locations_Async()
        {
            // call static async method with parameter.
            var locations = await NimbleApiClient.GetAccessibleLocationsAsync(authInfo);

            // assert that results were returned from the api.
            Assert.IsTrue(locations.Count > 0);
        }
    }
}

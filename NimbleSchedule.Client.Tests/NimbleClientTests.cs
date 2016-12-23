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
        [TestMethod]
        public async Task Client_Can_Get_Shifts_Async()
        {

            // read authentication information from configuration file.
            var authInfo = JsonConvert.DeserializeObject<AuthInfo>(File.ReadAllText(configDataLocation));

            // call static async method with parameters. testing with 14 day span
            var shifts = await NimbleApiClient.GetShiftsAsync(DateTime.Today.AddDays(-14), DateTime.Today, authInfo);

            // test that results were returned from the api.
            Assert.IsTrue(shifts.Count > 0);
        }

        [TestMethod]
        public async Task Client_Can_Get_Employees_Async()
        {
            // read authentication information from configuration file.
            var authInfo = JsonConvert.DeserializeObject<AuthInfo>(File.ReadAllText(configDataLocation));

            // call static async method with parameter.
            var employees = await NimbleApiClient.GetEmployeesAsync(authInfo);

            // assert that results were returned from the api.
            Assert.IsTrue(employees.Count > 0);
        }

        [TestMethod]
        public async Task Client_Can_Get_Locations_Async()
        {
            // read authentication information from configuration file.
            var authInfo = JsonConvert.DeserializeObject<AuthInfo>(File.ReadAllText(configDataLocation));

            // call static async method with parameter.
            var locations = await NimbleApiClient.GetLocationsAsync(authInfo);

            // assert that results were returned from the api.
            Assert.IsTrue(locations.Count > 0);
        }
    }
}

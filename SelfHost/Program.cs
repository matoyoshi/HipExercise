using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Jil;
using Microsoft.Owin.Hosting;
using Newtonsoft.Json;
using SelfHost.Contracts;
using SelfHost.Models;

namespace SelfHost
{
    class Program
    {
        static void Main(string[] args)
        {
            string baseAddress = "http://localhost:9000/";

            // Start OWIN host 
            using (WebApp.Start<Startup>(url: baseAddress))
            {
                // Create HttpCient and make a request to api/values 
                HttpClient client = new HttpClient();
                var id = 1;
                var response = client.GetAsync(baseAddress + $"api/vehicles/getLocation?id={id}").Result;
                Console.WriteLine($"Location of Vehicle {id} = {response.Content.ReadAsStringAsync().Result}");

                var location = new LocationModel() {Longitude = 7, Lattitude = 3};
                Console.WriteLine($"Update Vehicle {id} location to ({location.Lattitude},{location.Longitude})");
                var jsonObject = JSON.Serialize(new UpdateVehicleLocationRequest()
                {
                    Location = location,
                    VehicleId = id
                });
                var content = new StringContent(jsonObject.ToString(), Encoding.UTF8, "application/json");
                client.PostAsync(baseAddress + $"api/vehicles/updateVehicleLocation", content).Wait();

                response = client.GetAsync(baseAddress + $"api/vehicles/getLocation?id={id}").Result;
                Console.WriteLine($"Location of Vehicle {id} = {response.Content.ReadAsStringAsync().Result}");
                Console.WriteLine("");
                Console.WriteLine($"Press any key to close webApi");
                Console.ReadLine();
            }
        }
    }
}

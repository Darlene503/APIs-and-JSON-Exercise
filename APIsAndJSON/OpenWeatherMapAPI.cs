using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace APIsAndJSON
{
    

        public static class OpenWeatherMapAPI
        {
        public static void GetTemp()
        {
            var apiKeyObk = File.ReadAllText("appsettings.json");

            var apiKey = JObject.Parse(apiKeyObk).GetValue("api-key").ToString();

                Console.Write("Enter Zip: ");

                var zip = Console.ReadLine();

            var url = $"https://api.openweathermap.org/data/2.5/weather?zip={zip}&appid={apiKey}&units=imperial";

                var client = new HttpClient();

                var response = client.GetStringAsync(url).Result;

                var weatherObj = JObject.Parse(response);

                Console.WriteLine(value: $"Temp: {weatherObj["main"]["temp"]}");


            }

        }
}























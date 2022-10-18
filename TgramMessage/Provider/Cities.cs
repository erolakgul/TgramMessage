using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TgramMessage.Provider
{
    public class Cities
    {
        public Cities()
        {

        }

        public async Task<string> GetCities(string country)
        {
            string body =String.Empty;

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://countries-cities.p.rapidapi.com/location/country/"+ country + "/city/list?format=json"),
                Headers =
                     {
                         { "X-RapidAPI-Key", "SIGN-UP-FOR-KEY" },
                         { "X-RapidAPI-Host", "countries-cities.p.rapidapi.com" },
                     },
            };

            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                body = await response.Content.ReadAsStringAsync();
                Console.WriteLine(body);
            }
            return body;
        }
    }
}

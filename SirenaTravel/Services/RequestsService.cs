using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

using Newtonsoft.Json;

using SirenaTravel.Models;

namespace SirenaTravel.Services
{
    public class RequestsService
    {
        HttpClient client;
        enum ApiName
        {
            GetAirportInfo,
        }

        Dictionary<ApiName, string> ApiDictionary { get; }

        public RequestsService()
        {
            client = new HttpClient();
            ApiDictionary = new Dictionary<ApiName, string>();
            ApiDictionary.Add(ApiName.GetAirportInfo, @"https://places-dev.cteleport.com/airports/");
        }

        public async Task<Airport> GetAirportData(string iata)
        {
            var api = ApiDictionary[ApiName.GetAirportInfo];
            var uri = new Uri(string.Concat(api, iata));
            var response = await client.GetAsync(uri);

            if (!response.IsSuccessStatusCode)
                return null;

            var jsonString = response.Content.ReadAsStringAsync();
            jsonString.Wait();

            return JsonConvert.DeserializeObject<Airport>(jsonString.Result);
        }
    }
}
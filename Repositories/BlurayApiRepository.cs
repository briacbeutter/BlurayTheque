using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using WebApplication.DTOs;

namespace WebApplication.Repositories
{
    public class BlurayApiRepository
    {
        public List<BlurayApi> GetBluRays(string baseUrl)
        {
            HttpClient client = new HttpClient();
            List <BlurayApi> result = new List<BlurayApi>();
            try
            {
                HttpResponseMessage response = client.GetAsync($"{baseUrl}/BluRays").Result;
                response.EnsureSuccessStatusCode();
                string responseBody = response.Content.ReadAsStringAsync().Result;
                result = JsonConvert.DeserializeObject<List<BlurayApi>>(responseBody);
            }
            finally
            {
                client.Dispose();
            }
            return result;
        }
    }
}
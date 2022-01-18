using System;
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
                var text = baseUrl + "/Blurays";
                HttpResponseMessage response = client.GetAsync(text).Result;
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
        
        public void EmprunterBluray(string baseUrl, int idBluray)
        {
            HttpClient client = new HttpClient();
            try
            {
                HttpResponseMessage response = client.PostAsync(baseUrl + "/Blurays/"+ idBluray + "/Emprunt",new StringContent("")).Result;
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException requestException)
            {
                Console.Write(requestException.StackTrace);
            }
            finally
            {
                client.Dispose();
            }
        }
        
        public void RendreBluray(string baseUrl, int idBluray)
        {
            HttpClient client = new HttpClient();
            try
            {
                HttpResponseMessage response = client.DeleteAsync(baseUrl + "/Blurays/"+ idBluray).Result;
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException requestException)
            {
                Console.Write(requestException.StackTrace);
            }
            finally
            {
                client.Dispose();
            }
        }
    }
}
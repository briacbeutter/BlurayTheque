using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using WebApplication.DTOs;

//TODO Consulter => afficher les acteurs 0
//TODO revoir affichage durée/version 0

//TODO Appel API rendu bluray 3
//TODO affichage rendu Bluray dans index button 2


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
                Console.WriteLine(text);
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
                Console.WriteLine($"{baseUrl}/Blurays/{idBluray}/Emprunt");
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
    }
}
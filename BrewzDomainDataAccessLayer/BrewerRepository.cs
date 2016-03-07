using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BrewzDomain.Classes;
using BrewzDomain.DataLayer;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace BrewzDomainDataAccessLayer
{
    public class BrewerRepository : IBrewerRepository
    {
        private BrewzContext db = new BrewzContext();

        public BrewerRepository()
        {
        }
        public Brewer GetBrewerById(int id)
        {
            var httpClient = new HttpClient();

            try
            {
                // Try to get data online
                string brewzUrl = Settings.ONLINEBASEEURL + "/api/Brewers/" + id;
                var uri = new Uri(brewzUrl);
                var response = Task.Run(() => httpClient.GetAsync(uri)).Result;
                response.EnsureSuccessStatusCode();
                var result = Task.Run(() => response.Content.ReadAsStringAsync()).Result;
                return JsonConvert.DeserializeObject<Brewer>(result);
            }
            catch (Exception ex)
            {
                // Error retrieving data online, getting data locally
                string brewzUrl = Settings.OFFLINEBASEURL + "/api/Brewers/" + id;
                var uri = new Uri(brewzUrl);
                var response = Task.Run(() => httpClient.GetAsync(uri)).Result;
                response.EnsureSuccessStatusCode();
                var result = Task.Run(() => response.Content.ReadAsStringAsync()).Result;
                return JsonConvert.DeserializeObject<Brewer>(result);
            }
        }

        public List<Brewer> GetBrewers()
        {
            var httpClient = new HttpClient();

            try
            {
                // Try to get data online
                string brewzUrl = Settings.ONLINEBASEEURL + "/api/Brewers";
                var uri = new Uri(brewzUrl);
                var response = Task.Run(() => httpClient.GetAsync(uri)).Result;
                response.EnsureSuccessStatusCode();
                var result = Task.Run(() => response.Content.ReadAsStringAsync()).Result;
                return JsonConvert.DeserializeObject<List<Brewer>>(result);
            }
            catch (Exception ex)
            {
                // Error retrieving data online, getting data locally
                string brewzUrl = Settings.OFFLINEBASEURL + "/api/Brewers";
                var uri = new Uri(brewzUrl);
                var response = Task.Run(() => httpClient.GetAsync(uri)).Result;
                response.EnsureSuccessStatusCode();
                var result = Task.Run(() => response.Content.ReadAsStringAsync()).Result;
                return JsonConvert.DeserializeObject<List<Brewer>>(result);
            }
        }
      
        public HttpResponseMessage SaveReview(Review review)
        {
            HttpClient client = new HttpClient();

            // Try to update data online
            string reviewUrl = Settings.ONLINEBASEEURL;
            client.BaseAddress = new Uri(reviewUrl);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = client.PostAsJsonAsync("/api/Reviews/", review).Result;
            if (response.IsSuccessStatusCode)
            {
                return response.EnsureSuccessStatusCode();
            }
            else
            {
                // Try to update data locally
                client = new HttpClient();
                reviewUrl = Settings.OFFLINEBASEURL;
                client.BaseAddress = new Uri(reviewUrl);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                response = client.PostAsJsonAsync("/api/Reviews/", review).Result;
                return response.EnsureSuccessStatusCode();
            }
        }
    }
}

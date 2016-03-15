using BrewzApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace BrewzApp.Services
{
    public class BrewzDataService
    {
        public List<Brewer> GetBrewers()
        {
            IEnumerable<Brewer> brewers = Enumerable.Empty<Brewer>();
            HttpClient httpClient = new HttpClient();

            try
            {
                string brewzUrl = "http://brewzonline.azurewebsites.net/api/Brewers";
                var uri = new Uri(brewzUrl);
                var response = Task.Run(() => httpClient.GetAsync(uri)).Result;
                if (response.IsSuccessStatusCode)
                {
                    var json = Task.Run(() => response.Content.ReadAsStringAsync()).Result;
                    brewers = JsonConvert.DeserializeObject<List<Brewer>>(json);
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return brewers.ToList();
        }

        public Brewer GetBrewerById(int brewerId)
        {
            HttpClient httpClient = new HttpClient();
            Brewer brewer = new Brewer();
            try
            {
                string brewzUrl = "http://brewzonline.azurewebsites.net/api/Brewers/" + brewerId;
                var uri = new Uri(brewzUrl);
                var response = Task.Run(() => httpClient.GetAsync(uri)).Result;
                if (response.IsSuccessStatusCode)
                {
                    var json = Task.Run(() => response.Content.ReadAsStringAsync()).Result;
                    brewer = JsonConvert.DeserializeObject<Brewer>(json);
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return brewer;
        }

        public HttpResponseMessage CreateReview(Review review)
        {
            HttpClient httpClient = new HttpClient();
            string reviewUrl = "http://brewzonline.azurewebsites.net/";

            httpClient.BaseAddress = new Uri(reviewUrl);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = httpClient.PostAsJsonAsync("/api/Reviews/", review).Result;

            return response;
        }
    }
}

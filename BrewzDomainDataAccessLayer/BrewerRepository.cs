using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrewzDomain.Classes;
using BrewzDomain.DataLayer;
using System.Data.Entity;
using BrewzRestfullWebService.Controllers;
using System.Net.Http;
using Newtonsoft.Json;

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
            return db.Brewers.Find(id);
        }

        public List<Brewer> GetBrewers()
        {
            var httpClient = new HttpClient();
            string brewzUrl = Settings.BASEURL + "/api/Brewers";
            var uri = new Uri(brewzUrl);

            var response = Task.Run(() => httpClient.GetAsync(uri)).Result;
            response.EnsureSuccessStatusCode();
            var result = Task.Run(() => response.Content.ReadAsStringAsync()).Result;
            return JsonConvert.DeserializeObject<List<Brewer>>(result);
        }
    }
}

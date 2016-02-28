using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrewzDomain.JsonClasses;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace BrewzDomain.DataLayer.Services
{
    class JsonDataService : IJsonDataService
    {
        public List<BrewerJson> InitializeBrewers()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://opendata.visitflanders.org/tourist/activities/breweries.json");
            request.Method = "GET";
            request.ContentType = "application/json; charset=UTF-8";
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new Exception(String.Format("Server error (HTTP {0}: {1}).", response.StatusCode, response.StatusDescription));
                }

                StreamReader stream = new StreamReader(response.GetResponseStream());
                string result = stream.ReadToEnd();

                List<BrewerJson> brewerJsonList = (List<BrewerJson>)JsonConvert.DeserializeObject(result, typeof(List<BrewerJson>));
                return brewerJsonList;
            }
        }
    }
}

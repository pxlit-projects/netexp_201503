using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using BrewzDomain.Classes;
using System.IO;
using Newtonsoft.Json;
using BrewzDomain.DataLayer;
using System.Linq;

namespace BrewzRestfullWebService.Controllers
{
    public class InitializeBrewersController : ApiController
    {
        private BrewzContext db = new BrewzContext();
        private BrewersController controller = new BrewersController();

        public IHttpActionResult getInitialzeBrewers()
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

                // Map each BrewerJson to Brewer
                foreach (var brewerJson in brewerJsonList)
                {
                    Brewer brewer = mapBrewer(brewerJson);
                    brewer.address = mapAddress(brewerJson);
                    brewer.communication = mapCommunication(brewerJson);

                    Brewer brewerFromDb = db.brewers.FirstOrDefault(b => b.name == brewer.name);
                    if (brewerFromDb == null)
                    {
                        // Brewer doesnt exist so post a new one.
                        controller.PostBrewer(brewer);
                    }
                    else
                    {
                        // Brewer already exists so update brewer.
                        controller.PutBrewer(brewerFromDb.brewerId, brewer);
                    }
                }
                return Ok();
            }
        }

        private Brewer mapBrewer(BrewerJson brewerJson)
        {
            Brewer brewer = new Brewer();
            brewer.name = brewerJson.name;
            brewer.descriptionNl = brewerJson.descriptionNl;
            brewer.descriptionEn = brewerJson.descriptionEn;
            brewer.openingTimesNl = brewerJson.openingTimesNl;
            brewer.openingTimesEn = brewerJson.openingTimesEn;
            brewer.individualsJoinGroupsNl = brewerJson.individualsJoinGroupsNl;
            brewer.individualsJoinGroupsEn = brewerJson.individualsJoinGroupsEn;
            brewer.imagesUrl = brewerJson.imagesUrl;
            brewer.videoUrl = brewerJson.videoUrl;
            brewer.topFermentation = brewerJson.topFermentation;
            brewer.bottomFermentation = brewerJson.bottomFermentation;
            brewer.spontaneousFermentation = brewerJson.spontaneousFermentation;
            brewer.mixedFermentation = brewerJson.mixedFermentation;
            brewer.descriptionNl = brewerJson.descriptionNl;
            brewer.descriptionNl = brewerJson.descriptionNl;
            return brewer;
        }

        private Address mapAddress(BrewerJson brewerJson)
        {
            Address address = new Address();
            address.street = brewerJson.street;
            address.houseNumber = brewerJson.houseNumber;
            address.city = brewerJson.cityName;
            address.province = brewerJson.province;
            address.postalCode = brewerJson.postalCode;
            return address;
        }

        private Communications mapCommunication(BrewerJson brewerJson)
        {
            Communications communication = new Communications();
            communication.email = brewerJson.email;
            communication.phone = brewerJson.phone;
            communication.mobile = brewerJson.mobile;
            communication.fax = brewerJson.fax;
            communication.website = brewerJson.website;
            return communication;
        }
    }
}
using Newtonsoft.Json;

namespace BrewzDomain.Classes
{
    public class BrewerJson
    {
        public string name { get; set; }

        public string street { get; set; }

        [JsonProperty("house_number")]
        public string houseNumber { get; set; }

        [JsonProperty("box_number")]
        public string boxNumber { get; set; }

        [JsonProperty("postal_ code")]
        public string postalCode { get; set; }

        [JsonProperty("city_name")]
        public string cityName { get; set; }

        public string province { get; set; }

        public string phone { get; set; }

        public string mobile { get; set; }

        public string fax { get; set; }

        [JsonProperty("e-mail")]
        public string email { get; set; }

        [JsonProperty("Website")]
        public string website { get; set; }

        [JsonProperty("description_nl")]
        public string descriptionNl { get; set; }

        [JsonProperty("description_en")]
        public string descriptionEn { get; set; }

        [JsonProperty("opening_times_nl")]
        public string openingTimesNl { get; set; }

        [JsonProperty("opening_times_en")]
        public string openingTimesEn { get; set; }

        [JsonProperty("Possibility for individuals to join groups_nl")]
        public string individualsJoinGroupsNl { get; set; }

        [JsonProperty("Possibility for individuals to join groups_en")]
        public string individualsJoinGroupsEn { get; set; }

        public string imagesUrl { get; set; }

        public string videoUrl { get; set; }

        [JsonProperty("Top Fermentation")]
        public string topFermentation { get; set; }

        [JsonProperty("Bottom Fermentation")]
        public string bottomFermentation { get; set; }

        [JsonProperty("Sponaneuous Fermentation")]
        public string spontaneousFermentation { get; set; }

        [JsonProperty("Mixed Fermentation")]
        public string mixedFermentation { get; set; }
        
    }
}

using Newtonsoft.Json;

namespace BrewzDomain.JsonClasses
{
    public class BrewerJson
    {
        public string Name { get; set; }

        public string Street { get; set; }

        [JsonProperty("house_number")]
        public string HouseNumber { get; set; }

        [JsonProperty("box_number")]
        public string BoxNumber { get; set; }

        [JsonProperty("postal_ code")]
        public string PostalCode { get; set; }

        [JsonProperty("city_name")]
        public string CityName { get; set; }

        public string Province { get; set; }

        public string Phone { get; set; }

        public string Mobile { get; set; }

        public string Fax { get; set; }

        [JsonProperty("e-mail")]
        public string Email { get; set; }

        [JsonProperty("Website")]
        public string Website { get; set; }

        [JsonProperty("description_nl")]
        public string DescriptionNl { get; set; }

        [JsonProperty("description_en")]
        public string DescriptionEn { get; set; }

        [JsonProperty("opening_times_nl")]
        public string OpeningTimesNl { get; set; }

        [JsonProperty("opening_times_en")]
        public string OpeningTimesEn { get; set; }

        [JsonProperty("Possibility for individuals to join groups_nl")]
        public string IndividualsJoinGroupsNl { get; set; }

        [JsonProperty("Possibility for individuals to join groups_en")]
        public string IndividualsJoinGroupsEn { get; set; }

        public string ImagesUrl { get; set; }

        public string VideoUrl { get; set; }

        [JsonProperty("Top Fermentation")]
        public string TopFermentation { get; set; }

        [JsonProperty("Bottom Fermentation")]
        public string BottomFermentation { get; set; }

        [JsonProperty("Sponaneuous Fermentation")]
        public string SpontaneousFermentation { get; set; }

        [JsonProperty("Mixed Fermentation")]
        public string MixedFermentation { get; set; }

    }
}

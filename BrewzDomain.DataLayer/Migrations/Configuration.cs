namespace BrewzDomain.DataLayer.Migrations
{
    using Classes;
    using JsonClasses;
    using Services;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<BrewzDomain.DataLayer.BrewzContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(BrewzDomain.DataLayer.BrewzContext context)
        {
            JsonDataService dataService = new JsonDataService();
            List<BrewerJson> brewerJsonList = dataService.InitializeBrewers();
            List<Brewer> brewerList = new List<Brewer>();

            // Map each BrewerJson to Brewer
            foreach (var brewerJson in brewerJsonList)
            {
                Brewer brewer = MapBrewer(brewerJson);
                brewer.Address = MapAddress(brewerJson);
                brewer.Communication = MapCommunication(brewerJson);
                Review review = new Review();
                review.Brewer = brewer;
                review.ReviewComment = "Eerste review";
                review.ReviewDate = DateTime.Now;
                review.ReviewScore = 6;
                brewer.Reviews.Add(review);
                brewerList.Add(brewer);
            }
            brewerList.ForEach(b => context.Brewers.AddOrUpdate(p => p.Name, b));
            
            User user = new User();
            user.FirstName = "Bill";
            user.LastName = "Gates";
            user.Email = "bill.gates@hotmail.com";
            context.Users.AddOrUpdate(u => u.Email, user);
            context.SaveChanges();
        }

        private Brewer MapBrewer(BrewerJson brewerJson)
        {
            Brewer brewer = new Brewer();
            brewer.Name = brewerJson.Name;
            brewer.DescriptionNl = brewerJson.DescriptionNl;
            brewer.DescriptionEn = brewerJson.DescriptionEn;
            brewer.OpeningTimesNl = brewerJson.OpeningTimesNl;
            brewer.OpeningTimesEn = brewerJson.OpeningTimesEn;
            brewer.IndividualsJoinGroupsNl = brewerJson.IndividualsJoinGroupsNl;
            brewer.IndividualsJoinGroupsEn = brewerJson.IndividualsJoinGroupsEn;
            brewer.ImagesUrl = brewerJson.ImagesUrl;
            brewer.VideoUrl = brewerJson.VideoUrl;
            brewer.TopFermentation = brewerJson.TopFermentation;
            brewer.BottomFermentation = brewerJson.BottomFermentation;
            brewer.SpontaneousFermentation = brewerJson.SpontaneousFermentation;
            brewer.MixedFermentation = brewerJson.MixedFermentation;
            brewer.DescriptionNl = brewerJson.DescriptionNl;
            brewer.DescriptionEn = brewerJson.DescriptionEn;
            return brewer;
        }

        private Address MapAddress(BrewerJson brewerJson)
        {
            Address address = new Address();
            address.Street = brewerJson.Street;
            address.HouseNumber = brewerJson.HouseNumber;
            address.City = brewerJson.CityName;
            address.Province = brewerJson.Province;
            address.PostalCode = brewerJson.PostalCode;
            return address;
        }

        private Communications MapCommunication(BrewerJson brewerJson)
        {
            Communications communication = new Communications();
            communication.Email = brewerJson.Email;
            communication.Phone = brewerJson.Phone;
            communication.Mobile = brewerJson.Mobile;
            communication.Fax = brewerJson.Fax;
            communication.Website = brewerJson.Website;
            return communication;
        }
    }
}

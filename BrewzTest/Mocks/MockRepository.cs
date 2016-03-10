using BrewzDomainDataAccessLayer;
using System;
using System.Collections.Generic;
using BrewzDomain.Classes;
using System.Linq;

namespace BrewzTest.Mocks
{
    public class MockRepository : IBrewerRepository
    {
        private List<Brewer> brewers;

        public MockRepository()
        {
            brewers = LoadMockBrewers();
        }

        public Brewer GetBrewerById(int id)
        {
            return brewers.Where(b => b.BrewerId == id).FirstOrDefault();
        }

        public List<Brewer> GetBrewers()
        {
            return brewers;
        }

        public System.Net.Http.HttpResponseMessage SaveReview(Review review)
        {
            throw new NotImplementedException();
        }

        private List<Brewer> LoadMockBrewers()
        {
            return new List<Brewer>()
            {
                new Brewer()
                {
                    BrewerId = 1,
                    Name = "Jupiler",
                    DescriptionEn = "Belgiums premium beer no.1",
                    IndividualsJoinGroupsEn = "Only on weekdays"
                },
                new Brewer()
                {
                    BrewerId = 2,
                    Name = "Stella Artois",
                    DescriptionEn = "Belgiums premium beer no.2",
                    IndividualsJoinGroupsEn = "Only in the weekend"
                },
                new Brewer()
                {
                    BrewerId = 3,
                    Name = "Palm",
                    DescriptionEn = "Belgiums premium beer no.3",
                    IndividualsJoinGroupsEn = "All days"
                },
            };
        }
    }
}

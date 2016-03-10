using BrewzDomainDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using BrewzDomain.Classes;
using System.Net.Http;

namespace BrewzTests.Mocks
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

        public HttpResponseMessage SaveReview(Review review)
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
                    DescriptionEn = "Jupiler, Belgiums premium beer",
                    IndividualsJoinGroupsEn = "Only in weekends"
                },
                 new Brewer()
                {
                    BrewerId = 2,
                    Name = "Palm",
                    DescriptionEn = "Palm, Belgiums premium beer",
                    IndividualsJoinGroupsEn = "Always"
                },
                  new Brewer()
                {
                    BrewerId = 3,
                    Name = "Stella",
                    DescriptionEn = "Stella, Belgiums premium beer",
                    IndividualsJoinGroupsEn = "Only on weekendays"
                }
            };
        }
    }
}

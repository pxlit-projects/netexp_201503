using BrewzWPF.Services;
using System;
using System.Collections.Generic;
using BrewzDomain.Classes;
using System.Net.Http;
using BrewzDomainDataAccessLayer;

namespace BrewzTests.Mocks
{
    public class MockBrewerDataService : IBrewerDataService
    {
        private IBrewerRepository repository;

        public MockBrewerDataService(IBrewerRepository repository)
        {
            this.repository = repository;
        }

        public List<Brewer> GetAllBrewers()
        {
            return repository.GetBrewers();
        }

        public Brewer GetBrewer(int brewerId)
        {
            Brewer brewer = repository.GetBrewerById(brewerId);
            return brewer;
        }

        public HttpResponseMessage SaveReview(Review review)
        {
            throw new NotImplementedException();
        }
    }
}

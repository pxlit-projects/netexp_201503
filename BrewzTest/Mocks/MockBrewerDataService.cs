using BrewzWPF.Services;
using System;
using System.Collections.Generic;
using BrewzDomain.Classes;
using System.Net.Http;
using BrewzDomainDataAccessLayer;

namespace BrewzTest.Mocks
{
    class MockBrewerDataService : IBrewerDataService
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
            return repository.GetBrewerById(brewerId);
        }

        public HttpResponseMessage SaveReview(Review review)
        {
            throw new NotImplementedException();
        }
    }
}

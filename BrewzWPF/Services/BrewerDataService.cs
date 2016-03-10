using BrewzDomain.Classes;
using BrewzDomainDataAccessLayer;
using System.Collections.Generic;
using System.Net.Http;

namespace BrewzWPF.Services
{
    public class BrewerDataService : IBrewerDataService
    {
        IBrewerRepository repository;

        public BrewerDataService(IBrewerRepository repository)
        {
            this.repository = repository;
        }

        public List<Brewer> GetAllBrewers()
        {
            return repository.GetBrewers();
        }

        public Brewer GetBrewer(int id)
        {
            return repository.GetBrewerById(id);
        }
        
        public HttpResponseMessage SaveReview(Review review)
        {
            return repository.SaveReview(review);
        }
    }
}

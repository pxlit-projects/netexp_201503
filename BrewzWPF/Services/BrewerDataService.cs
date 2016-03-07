using BrewzDomain.Classes;
using BrewzDomainDataAccessLayer;
using System.Collections.Generic;
using System.Net.Http;

namespace BrewzWPF.Services
{
    class BrewerDataService : IBrewerDataService
    {
        IBrewerRepository repository = new BrewerRepository();

        public BrewerDataService()
        {

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

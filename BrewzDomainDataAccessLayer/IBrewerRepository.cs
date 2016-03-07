using BrewzDomain.Classes;
using System.Collections.Generic;
using System.Net.Http;

namespace BrewzDomainDataAccessLayer
{
    public interface IBrewerRepository
    {
        Brewer GetBrewerById(int id);
        List<Brewer> GetBrewers();

        HttpResponseMessage SaveReview(Review review);
    }
}

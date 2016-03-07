using BrewzDomain.Classes;
using System.Collections.Generic;
using System.Net.Http;

namespace BrewzWPF.Services
{
    public interface IBrewerDataService
    {
        Brewer GetBrewer(int brewerId);

        List<Brewer> GetAllBrewers();

        HttpResponseMessage SaveReview(Review review);

    }
}

using BrewzDomain.Classes;
using BrewzDomainDataAccessLayer;
using System.Collections.Generic;

namespace BrewzWPF.Services
{
    class BrewerDataService : IDataService
    {
        IBrewerRepository repository = new BrewerRepository();

        public BrewerDataService()
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
    }
}

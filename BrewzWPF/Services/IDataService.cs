using BrewzDomain.Classes;
using System.Collections.Generic;

namespace BrewzWPF.Services
{
    public interface IDataService
    {
        Brewer GetBrewer(int brewerId);

        List<Brewer> GetAllBrewers();

    }
}

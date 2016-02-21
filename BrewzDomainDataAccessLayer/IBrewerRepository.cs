using BrewzDomain.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrewzDomainDataAccessLayer
{
    public interface IBrewerRepository
    {
        Brewer GetBrewerById(int id);
        List<Brewer> GetBrewers();
    }
}

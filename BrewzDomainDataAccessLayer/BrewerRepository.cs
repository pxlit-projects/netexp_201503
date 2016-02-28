using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrewzDomain.Classes;
using BrewzDomain.DataLayer;
using System.Data.Entity;
using BrewzRestfullWebService.Controllers;

namespace BrewzDomainDataAccessLayer
{
    public class BrewerRepository : IBrewerRepository
    {
        private BrewzContext db = new BrewzContext();
        private static List<Brewer> brewers;

        public BrewerRepository()
        {
        }
        public Brewer GetBrewerById(int id)
        {
            return db.Brewers.Find(id);
        }

        public List<Brewer> GetBrewers()
        {
            DbSet<Brewer> brewersDbSet = db.brewers;
            List<Brewer> brewersList = brewersDbSet.ToList();
            if (brewersList.Count == 0)
            {
                InitializeBrewersController initialize = new InitializeBrewersController();
                initialize.GetInitialzeBrewers();
                brewersList = brewersDbSet.ToList();
            }
            return brewersList;
        }
    }
}

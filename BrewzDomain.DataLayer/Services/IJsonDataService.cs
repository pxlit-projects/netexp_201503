using BrewzDomain.JsonClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrewzDomain.DataLayer.Services
{
    interface IJsonDataService
    {
        List<BrewerJson> InitializeBrewers();
    }
}

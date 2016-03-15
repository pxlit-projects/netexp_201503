using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrewzApp.Models
{
    public class Brewer
    {
        public Brewer()
        {
            Reviews = new List<Review>();
            Communication = new Communications();
            Address = new Address();
        }

        public int BrewerId { get; set; }

        public string Name { get; set; }

        public string DescriptionNl { get; set; }

        public string DescriptionEn { get; set; }

        public string OpeningTimesNl { get; set; }

        public string OpeningTimesEn { get; set; }

        public string IndividualsJoinGroupsNl { get; set; }

        public string IndividualsJoinGroupsEn { get; set; }

        public string ImagesUrl { get; set; }

        public string VideoUrl { get; set; }

        public string TopFermentation { get; set; }

        public string BottomFermentation { get; set; }

        public string SpontaneousFermentation { get; set; }

        public string MixedFermentation { get; set; }

        public List<Review> Reviews { get; set; }

        public Communications Communication { get; set; }

        public Address Address { get; set; }
    }
}

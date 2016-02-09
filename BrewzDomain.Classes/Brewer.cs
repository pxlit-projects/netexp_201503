using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BrewzDomain.Classes
{
    public class Brewer
    {
        public int brewerId { get; set; }

        public string name { get; set; }

        public string descriptionNl { get; set; }

        public string descriptionEn { get; set; }

        public string openingTimesNl { get; set; }

        public string openingTimesEn { get; set; }

        public string individualsJoinGroupsNl { get; set; }

        public string individualsJoinGroupsEn { get; set; }

        public string imagesUrl { get; set; }

        public string videoUrl { get; set; }

        public string topFermentation { get; set; }

        public string bottomFermentation { get; set; }

        public string spontaneousFermentation { get; set; }

        public string mixedFermentation { get; set; }
        
        public List<Review> reviews { get; set; }

        [Required]
        public Communications communication { get; set; }
        
        [Required]
        public Address address { get; set; }

    }
}

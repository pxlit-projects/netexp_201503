using System;

namespace BrewzDomain.Classes
{
    public class Review
    {
        public int reviewId { get; set; }

        public DateTime reviewDate { get; set; }

        public int reviewScore { get; set; }

        public string reviewComment { get; set; }
    }
}

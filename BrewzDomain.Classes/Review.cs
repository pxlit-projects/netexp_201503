using System;

namespace BrewzDomain.Classes
{
    public class Review
    {
        public int ReviewId { get; set; }

        public DateTime ReviewDate { get; set; }

        public int ReviewScore { get; set; }

        public string ReviewComment { get; set; }
    }
}

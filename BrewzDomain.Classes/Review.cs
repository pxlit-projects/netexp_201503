using System;

namespace BrewzDomain.Classes
{
    public class Review
    {
        public int ReviewId { get; set; }

        public DateTime ReviewDate { get; set; }

        public int ReviewScore { get; set; }

        public string ReviewComment { get; set; }

        public int BrewerId { get; set; }

        public Brewer Brewer { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }
     
    }
}

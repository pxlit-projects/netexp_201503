using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrewzApp.Models
{
    public class Review
    {
        public int ReviewId { get; set; }

        public DateTime ReviewDate { get; set; }

        public int ReviewScore { get; set; }

        public string ReviewComment { get; set; }

        public int BrewerId { get; set; }

        public int UserId { get; set; }
    }
}

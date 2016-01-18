using System.Collections.Generic;

namespace BrewzDomain.Classes
{
    public class User
    {
        public int userId { get; set; }

        public string firstName { get; set; }

        public string lastName { get; set; }

        public string login { get; set; }

        public string email { get; set; }

        public string password { get; set; }

        public List<Review> reviews { get; set; }
    }
}

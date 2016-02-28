using System.Collections.Generic;

namespace BrewzDomain.Classes
{
    public class User
    {
        public int UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
        
        public string Email { get; set; }
        
        public List<Review> Reviews { get; set; }
    }
}

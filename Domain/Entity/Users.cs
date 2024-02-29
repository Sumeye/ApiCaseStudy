using Microsoft.AspNetCore.Identity;

namespace Domain.Entity
{
    public class Users:IdentityUser
    {
        public string Name { get; set; }
        public string SurName { get; set; }

        public string City { get; set; }
    }
}

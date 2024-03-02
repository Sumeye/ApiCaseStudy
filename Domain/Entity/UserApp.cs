using Microsoft.AspNetCore.Identity;

namespace Domain.Entity
{
    public class UserApp:IdentityUser
    {
        public string Name { get; set; }
        public string SurName { get; set; }
       
    }
}

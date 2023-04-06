using Microsoft.AspNetCore.Identity;

namespace PrzedszkoleAdmin.Models
{
    public class UserDetailsViewModel
    {
        public IdentityUser User { get; set; }
        public IList<string> Roles { get; set; }
    }
}

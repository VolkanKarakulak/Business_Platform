using Microsoft.AspNetCore.Identity;

namespace Business_Platform.Model.Identity
{
    public class AppRole : IdentityRole<long>
    {
        public AppRole(string name) : base(name) { }
    }
}

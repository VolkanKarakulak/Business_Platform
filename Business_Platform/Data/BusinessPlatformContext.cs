using Business_Platform.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Business_Platform.Data
{
    public class BusinessPlatformContext : IdentityDbContext<AppUser, AppRole, long>
    {
        public BusinessPlatformContext(DbContextOptions<BusinessPlatformContext> options)
            : base(options)
        {
        }
    }
}

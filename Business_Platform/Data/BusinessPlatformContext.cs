using Business_Platform.Model;
using Business_Platform.Model.BaseModel;
using Business_Platform.Model.Clothing;
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

        public DbSet<BaseBranchModel>? BaseBranches { get; set; }
        public DbSet<BaseCompanyModel>? BaseCompanys { get; set; }
        public DbSet<BaseProductModel>? BaseProducts { get; set; }
        public DbSet<CompanyCategory>? CompanyCategories { get; set; }
        public DbSet<State>? States { get; set; }
        public DbSet<Like>? Likes { get; set; }
        public DbSet<ClothingCompany>? ClothingCompanies { get; set; }
        public DbSet<ClothingCompanyBranch>? ClothingCompanyBranches { get; set;}
        public DbSet<ClothingProductOffer>? ClothingOffers { get; set; }
        public DbSet<ClothingProduct>? ClothingProducts { get; set;}
        public DbSet<ClothingProductComment>? ClothingProductComments { get; set; }
        public DbSet<ClothingType>? ClothingTypes { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<AppUser>().HasOne(u => u.State).WithMany().OnDelete(DeleteBehavior.NoAction);

            //modelBuilder.Entity<ClothingOffer>().HasOne(u => u.States).WithMany().OnDelete(DeleteBehavior.NoAction);

            //modelBuilder.Entity<Food>().HasOne(u => u.State).WithMany().OnDelete(DeleteBehavior.NoAction);

            //modelBuilder.Entity<Category>().HasOne(u => u.State).WithMany().OnDelete(DeleteBehavior.NoAction);

            //modelBuilder.Entity<RestaurantUser>().HasOne(u => u.Restaurant).WithMany().OnDelete(DeleteBehavior.NoAction);

            //modelBuilder.Entity<RestaurantUser>().HasKey(r => new { r.UserId, r.RestaurantId });

            base.OnModelCreating(modelBuilder);
        }

    }
}

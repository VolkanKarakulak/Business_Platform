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
        public DbSet<CompanyCategory>? CompanyCategories { get; set; }
        public DbSet<State>? States { get; set; }
        //public DbSet<Like>? Likes { get; set; }
        public DbSet<ClothingCompany>? ClothingCompanies { get; set; }
        public DbSet<ClothingCompanyBranch>? ClothingCompanyBranches { get; set;}
        public DbSet<ClothingProductOffer>? ClothingProductOffers { get; set; }
        public DbSet<ClothingProduct>? ClothingProducts { get; set;}
        public DbSet<ClothingProductComment>? ClothingProductComments { get; set; }
        public DbSet<ClothingType>? ClothingTypes { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<ClothingCompanyBranch>().HasOne(u => u.State).WithMany().OnDelete(DeleteBehavior.NoAction);

            //modelBuilder.Entity<ClothingProductOffer>().HasOne(u => u.).WithMany().OnDelete(DeleteBehavior.NoAction);
            //modelBuilder.Entity<ClothingCompany>()
            // .HasMany(cc => cc.Products)
            // .WithOne()
            // .HasForeignKey(cp => cp.ClothingCompanyId)
            // .OnDelete(DeleteBehavior.NoAction);

            //modelBuilder.Entity<ClothingCompany>()
            //.HasMany(cc => cc.Offers)
            //.WithOne()
            //.HasForeignKey(co => co.ClothingCompanyId)
            //.OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ClothingProductOffer>().HasOne(u => u.AppUser).WithMany().HasForeignKey(u => u.UserId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<ClothingCompany>().HasOne(u =>u.State).WithMany().OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<ClothingProduct>().HasOne(u => u.State).WithMany().OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<ClothingCompBranchUser>().HasKey(u => new { u.UserId, u.ClothingCompanyBranchId });
            modelBuilder.Entity<ClothingCompBranchUser>().HasOne(u => u.ClothingCompanyBranch).WithMany().OnDelete(DeleteBehavior.NoAction);

           

            base.OnModelCreating(modelBuilder);
        }

    }
}

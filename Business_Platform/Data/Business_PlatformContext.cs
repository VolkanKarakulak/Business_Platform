using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Business_Platform.Model.Office;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Business_Platform.Model.Identity;
using Business_Platform.Model.Food;

namespace Business_Platform.Data
{
    public class Business_PlatformContext : IdentityDbContext<AppUser, AppRole, long>
    {
        public Business_PlatformContext (DbContextOptions<Business_PlatformContext> options)
            : base(options)
        {
        }

        public DbSet<OfficeCompany> OfficeCompanies { get; set; } = default!;
        public DbSet<Model.CompanyCategory>? CompanyCategories { get; set; }
        public DbSet<Model.State>? States { get; set; }
        public DbSet<OfficeCompanyBranch>? OfficeCompanyBranches { get; set; }
        public DbSet<OfficeProduct>? OfficeProducts { get; set; }
        public DbSet<OfficeProdBranchProduct>? OfficeProdBranchProducts { get; set; }
        public DbSet<OfficeProductOffer>? OfficeProductOffers { get; set; }
        public DbSet<Model.MainCompany>? MainCompanies { get; set; }
        public DbSet<ManageOffer>? ManageOffers { get; set; }
        public DbSet<Model.Like>? Likes { get; set; }
        public DbSet<FoodCategory>? FoodCategories { get; set; }
        public DbSet<FoodCompany>? FoodCompanies { get; set; }
        public DbSet<RestaurantBranch>? RestaurantBranches { get; set; }
        public DbSet<RestaurantBranchComment>? RestaurantBranchComments { get; set; }
        public DbSet<RestaurantBranchUser>? RestaurantBranchUsers { get; set; }
        public DbSet<RestaurantFood>? RestaurantFoods { get; set; }
        public DbSet<RestaurantBranchFood>? RestaurantBranchFoods { get; set; }
        public DbSet<OfficeProductComment>? OfficeProductComment { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //modelBuilder.Entity<OfficeProductOffer>().HasOne(u => u.).WithMany().OnDelete(DeleteBehavior.NoAction);
            //modelBuilder.Entity<OfficeCompany>()
            // .HasMany(cc => cc.Products)
            // .WithOne()
            // .HasForeignKey(cp => cp.OfficeCompanyId)
            // .OnDelete(DeleteBehavior.NoAction);

            //modelBuilder.Entity<OfficeCompany>()
            //.HasMany(cc => cc.Offers)
            //.WithOne()
            //.HasForeignKey(co => co.OfficeCompanyId)
            //.OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<OfficeCompany>().HasOne(u => u.State).WithMany().OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<OfficeProduct>().HasOne(u => u.State).WithMany().OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<OfficeCompanyBranch>().HasOne(u => u.State).WithMany().OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<OfficeCompBranchUser>().HasOne(u => u.OfficeCompanyBranch).WithMany().OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<OfficeCompBranchUser>().HasKey(u => new { u.UserId, u.OfficeCompanyBranchId });
            modelBuilder.Entity<OfficeProdBranchProduct>().HasOne(opbp => opbp.OfficeCompany).WithMany(oc => oc.ProductsBranchProducts).HasForeignKey(opbp => opbp.OfficeCompanyId);
            modelBuilder.Entity<RestaurantBranchUser>().HasOne(u => u.RestaurantBranch).WithMany().OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<RestaurantBranchUser>().HasKey(u => new { u.AppUserId, u.RestaurantBranchId });

            base.OnModelCreating(modelBuilder);
        }

    }
}

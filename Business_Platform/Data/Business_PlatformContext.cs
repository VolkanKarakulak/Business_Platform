using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Business_Platform.Model.Clothing;
using Business_Platform.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Business_Platform.Data
{
    public class Business_PlatformContext : IdentityDbContext<AppUser, AppRole, long>
    {
        public Business_PlatformContext (DbContextOptions<Business_PlatformContext> options)
            : base(options)
        {
        }

        public DbSet<Business_Platform.Model.Clothing.ClothingCompany> ClothingCompanies { get; set; } = default!;

        public DbSet<Business_Platform.Model.CompanyCategory>? CompanyCategories { get; set; }

        public DbSet<Business_Platform.Model.State>? States { get; set; }

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
            modelBuilder.Entity<ClothingCompany>().HasOne(u => u.State).WithMany().OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<ClothingProduct>().HasOne(u => u.State).WithMany().OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<ClothingCompBranchUser>().HasKey(u => new { u.UserId, u.ClothingCompanyBranchId });
            modelBuilder.Entity<ClothingCompBranchUser>().HasOne(u => u.ClothingCompanyBranch).WithMany().OnDelete(DeleteBehavior.NoAction);



            base.OnModelCreating(modelBuilder);
        }
    }
}

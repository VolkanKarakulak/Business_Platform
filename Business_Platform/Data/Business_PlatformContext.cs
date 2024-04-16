using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Business_Platform.Model.Office;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Business_Platform.Model.Identity;

namespace Business_Platform.Data
{
    public class Business_PlatformContext : IdentityDbContext<AppUser, AppRole, long>
    {
        public Business_PlatformContext (DbContextOptions<Business_PlatformContext> options)
            : base(options)
        {
        }

        public DbSet<Business_Platform.Model.Office.OfficeCompany> OfficeCompanies { get; set; } = default!;
        public DbSet<Business_Platform.Model.CompanyCategory>? CompanyCategories { get; set; }
        public DbSet<Business_Platform.Model.State>? States { get; set; }
        public DbSet<Business_Platform.Model.Office.OfficeStock>? OfficeStocks { get; set; }
        public DbSet<Business_Platform.Model.Office.OfficeCompanyBranch>? OfficeCompanyBranches { get; set; }
        public DbSet<Business_Platform.Model.Office.OfficeProduct>? OfficeProducts { get; set; }
        public DbSet<Business_Platform.Model.Office.OfficeProdBranchProduct>? OfficeProdBranchProducts { get; set; }
        public DbSet<Business_Platform.Model.Office.OfficeProductOffer>? OfficeProductOffers { get; set; }
        public DbSet<Business_Platform.Model.Office.ManageOffer>? ManageOffers { get; set; }


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
           //modelBuilder.Entity<OfferAdmin>().HasKey(a => new { a.OfficeProductOfferId, a.OfficeCompBranchUserId });
            


            base.OnModelCreating(modelBuilder);
        }
    }
}

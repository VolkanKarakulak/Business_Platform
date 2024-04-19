using Business_Platform.Model.Identity;
using Business_Platform.Model;
using Microsoft.AspNetCore.Identity;
using System.Drawing.Drawing2D;
using Microsoft.EntityFrameworkCore;
using Business_Platform.Model.Office;

namespace Business_Platform.Data
{
    public class Initializer
    {
        public Initializer(Business_PlatformContext? context, RoleManager<AppRole>? roleManager, UserManager<AppUser>? userManager)
        {
            State state;
            AppRole appRole;
            AppUser appUser;
            MainCompany? mainCompany = null;
            OfficeCompany? officeCompany = null;
            OfficeCompanyBranch? officeCompanyBranch = null;
            CompanyCategory? companyCategory = null;
           

            if (context != null)
            {
                context.Database.Migrate();
                if (context.States?.Count() == 0)
                {
                    state = new State();
                    state.Id = 0;
                    state.Name = "Deleted";
                    context.States.Add(state);
                    state = new State();
                    state.Id = 1;
                    state.Name = "Active";
                    context.States.Add(state);
                    state = new State();
                    state.Id = 2;
                    state.Name = "Passive";
                    context.States.Add(state);
                }
                context.SaveChanges();
                if (context.MainCompanies?.Count() == 0)
                {
                    mainCompany = new MainCompany();
                    mainCompany.Address = "adres";
                    mainCompany.EMail = "abc@def.com";
                    mainCompany.Name = "MainCompany";
                    mainCompany.PostalCode = "12345";
                    mainCompany.RegisterDate = DateTime.Today;
                    mainCompany.StateId = 1;
                    context.MainCompanies.Add(mainCompany);
                }
                context.SaveChanges();
                if (context.CompanyCategories?.Count() == 0)
                {
                    companyCategory = new CompanyCategory();
                    companyCategory.Name = "OfficeProductCompany";
                    companyCategory.Description = "OfficeProducts";
                    context.CompanyCategories.Add(companyCategory);
                    companyCategory = new CompanyCategory();
                    companyCategory.Name = "FoodCompany";
                    companyCategory.Description = "Foods";
                    context.CompanyCategories.Add(companyCategory);
                }
                context.SaveChanges();

                if (context.OfficeCompanies?.Count() == 0)
                {
                    if (companyCategory != null)
                    {
                        officeCompany = new OfficeCompany();
                        officeCompany.Address = "adres";
                        officeCompany.EMail = "abc@def.com";
                        officeCompany.Name = "OfficeCompany";
                        officeCompany.PostalCode = "12345";
                        officeCompany.RegisterDate = DateTime.Today;
                        officeCompany.StateId = 1;
                        officeCompany.CompanyCategoryId = companyCategory.Id;
                        context.OfficeCompanies.Add(officeCompany);
                    }
                }
                context.SaveChanges();

                if (context.OfficeCompanyBranches?.Count() == 0)
                {
                    if(officeCompany != null)
                    {
                        officeCompanyBranch = new OfficeCompanyBranch();
                        officeCompanyBranch.Address = "adres";
                        officeCompanyBranch.EMail = "abc@def.com";
                        officeCompanyBranch.Name = "OfficeCompany";
                        officeCompanyBranch.PostalCode = "12345";
                        officeCompanyBranch.RegisterDate = DateTime.Today;
                        officeCompanyBranch.StateId = 1;
                        officeCompanyBranch.OfficeCompanyId = officeCompany.Id;
                        context.OfficeCompanyBranches.Add(officeCompanyBranch);
                    }                  
                }
                context.SaveChanges();

                if (roleManager != null)
                {
                    if (roleManager.Roles.Count() == 0)
                    {
                        appRole = new AppRole("MainCompanyAdmin");
                        roleManager.CreateAsync(appRole).Wait();
                        appRole = new AppRole("OfficeCompanyAdmin");
                        roleManager.CreateAsync(appRole).Wait();
                        appRole = new AppRole("BranchAdmin");
                        roleManager.CreateAsync(appRole).Wait();
                    }
                }
                if (userManager != null)
                {
                    if (userManager.Users.Count() == 0)
                    {
                        if (mainCompany != null)
                        {
                            appUser = new AppUser();
                            appUser.UserName = "MainAdmin";
                            appUser.MainCompanyId = mainCompany.Id;
                            appUser.Name = "MainAdmin";
                            appUser.Email = "abc@def.com";
                            appUser.PhoneNumber = "1112223344";
                            appUser.RegisterDate = DateTime.Today;
                            appUser.StateId = 1;
                            userManager.CreateAsync(appUser, "MainAdmin123!").Wait();
                            userManager.AddToRoleAsync(appUser, "MainCompanyAdmin").Wait();
                        }
                        
                        if (officeCompany != null)
                        {
                                appUser = new AppUser();
                                appUser.UserName = "OfficeCompanyAdmin";
                                appUser.OfficeCompanyId = officeCompany.Id;
                                appUser.Name = "OfficeCompanyAdmin";
                                appUser.Email = "abcd@def.com";
                                appUser.PhoneNumber = "1112223345";
                                appUser.RegisterDate = DateTime.Today;
                                appUser.StateId = 1;
                                userManager.CreateAsync(appUser, "OfficeCompanyAdmin123!").Wait();
                                userManager.AddToRoleAsync(appUser, "OfficeCompanyAdmin").Wait();
                            
                        }
                     
                        if (officeCompanyBranch != null)
                        {
                                appUser = new AppUser();
                                appUser.UserName = "BranchAdmin";
                                appUser.OfficeCompanyBranchId = officeCompanyBranch.Id;
                                appUser.OfficeCompanyId = officeCompany!.Id;
                                appUser.MainCompanyId = mainCompany!.Id;
                                appUser.Name = "BranchAdmin";
                                appUser.Email = "abce@def.com";
                                appUser.PhoneNumber = "1112223346";
                                appUser.RegisterDate = DateTime.Today;
                                appUser.StateId = 1;
                                userManager.CreateAsync(appUser, "BranchAdmin123!").Wait();
                                userManager.AddToRoleAsync(appUser, "BranchAdmin").Wait();
                            
                        }
                        context.SaveChanges();
                    }
                }
            }
        }
    }
}

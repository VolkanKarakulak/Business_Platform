using Business_Platform.Data;
using Business_Platform.Model.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Business_Platform
{
    public class Program
    {
        
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<Business_PlatformContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("Business_PlatformContext") ?? throw new InvalidOperationException("Connection string 'Business_PlatformContext' not found.")));

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddDbContext<Business_PlatformContext>(options =>
               options.UseSqlServer(builder.Configuration.GetConnectionString("WatchMeContext") ?? throw new InvalidOperationException("Connection string 'WatchMeContext' not found.")));

            builder.Services.AddIdentity<AppUser, AppRole>().AddDefaultTokenProviders()
                .AddEntityFrameworkStores<Business_PlatformContext>();

             builder.Services.AddControllers().AddNewtonsoftJson(opt =>
            {
                opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddAuthentication();
            builder.Services.AddAuthorization();
            builder.Services.AddSwaggerGen();

            //builder.Services.AddAuthorization(options => options.AddPolicy("OfficeBranchAdmin", policy => policy.RequireClaim("OfficeCompanyBranchId")));

            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("OfficeBranchAdminPolicy", policy =>
                {
                    policy.RequireRole("OfficeBranchAdmin"); 
                    policy.RequireClaim("OfficeCompanyId");
                    policy.RequireClaim("OfficeBranchId");
                    policy.RequireClaim("CompanyCategoryId");
                });
            });


            builder.Services.AddAuthorization(options => options.AddPolicy("OfficeCompanyAdmin", policy => policy.RequireClaim("OfficeCompanyId")));

            //builder.Services.AddAuthorization(options =>
            //{
            //    options.AddPolicy("OfficeBranchAdmin", policy =>
            //    {
            //        policy.RequireClaim("OfficeCompanyBranchId");
            //    });
            //});
            //builder.Services.AddAuthorization(options =>
            //{
            //    options.AddPolicy("FoodCompanyAdmin", policy =>
            //    {
            //        policy.RequireClaim("RestaurantBranchId");
            //        policy.RequireClaim("FoodCompanyAdmin");
            //    });
            //});

            builder.Services.AddAuthorization(options => options.AddPolicy("RestBranchAdmin", policy => policy.RequireClaim("RestaurantBranchId")));

            builder.Services.AddScoped<RoleManager<AppRole>>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            Business_PlatformContext? context = app.Services.CreateScope().ServiceProvider.GetService<Business_PlatformContext>();
            RoleManager<AppRole>? roleManager = app.Services.CreateScope().ServiceProvider.GetService<RoleManager<AppRole>>();
            UserManager<AppUser>? userManager = app.Services.CreateScope().ServiceProvider.GetService<UserManager<AppUser>>();
            Initializer dBInitializer = new Initializer(context, roleManager, userManager);

            app.Run();
        }
    }
}
